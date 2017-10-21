/*
 *  Pkcs11Admin - GUI tool for administration of PKCS#11 enabled devices
 *  Copyright (c) 2014-2017 Jaroslav Imrich <jimrich@jimrich.sk>
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License version 3 
 *  as published by the Free Software Foundation.
 *  
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using Net.Pkcs11Admin.Configuration;
using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Net.Pkcs11Admin
{
    public class Pkcs11Slot : IDisposable
    {
        private bool _disposed = false;

        private Slot _slot = null;

        private Session _authenticatedSession = null;

        #region Properties

        public Pkcs11SlotInfo SlotInfo
        {
            get;
            private set;
        }

        public Exception SlotInfoException
        {
            get;
            private set;
        }

        public Pkcs11TokenInfo TokenInfo
        {
            get;
            private set;
        }

        public Exception TokenInfoException
        {
            get;
            private set;
        }

        public Pkcs11SessionInfo SessionInfo
        {
            get;
            private set;
        }

        public Exception SessionInfoException
        {
            get;
            private set;
        }

        public List<Pkcs11MechanismInfo> Mechanisms
        {
            get;
            private set;
        }

        public Exception MechanismsException
        {
            get;
            private set;
        }

        public List<Pkcs11HwFeatureInfo> HwFeatures
        {
            get;
            private set;
        }

        public Exception HwFeaturesException
        {
            get;
            private set;
        }

        public List<Pkcs11DataObjectInfo> DataObjects
        {
            get;
            private set;
        }

        public Exception DataObjectsException
        {
            get;
            private set;
        }

        public List<Pkcs11CertificateInfo> Certificates
        {
            get;
            private set;
        }

        public Exception CertificatesException
        {
            get;
            private set;
        }

        public List<Pkcs11KeyInfo> Keys
        {
            get;
            private set;
        }

        public Exception KeysException
        {
            get;
            private set;
        }

        public List<Pkcs11DomainParamsInfo> DomainParams
        {
            get;
            private set;
        }

        public Exception DomainParamsException
        {
            get;
            private set;
        }

        #endregion

        #region Constructor

        public Pkcs11Slot(Slot slot)
        {
            _slot = slot;

            Reload(true);
        }

        #endregion

        #region Slot information gathering

        private void MarkSlotAsUsable()
        {
            SlotInfo = null;
            SlotInfoException = null;

            TokenInfo = null;
            TokenInfoException = null;

            SessionInfo = null;
            SessionInfoException = null;

            Mechanisms = null;
            MechanismsException = null;

            HwFeatures = null;
            HwFeaturesException = null;

            DataObjects = null;
            DataObjectsException = null;

            Certificates = null;
            CertificatesException = null;

            Keys = null;
            KeysException = null;

            DomainParams = null;
            DomainParamsException = null;
        }

        private void MarkSlotAsUnusable(Exception ex, bool isSlotInfoException = false, bool isTokenInfoException = false, bool isSessionInfoException = false)
        {
            if (isSlotInfoException)
            {
                SlotInfo = null;
                SlotInfoException = ex;
            }

            if (isSlotInfoException || isTokenInfoException)
            {
                TokenInfo = null;
                TokenInfoException = ex;
            }

            if (isSlotInfoException || isTokenInfoException || isSessionInfoException)
            {
                SessionInfo = null;
                SessionInfoException = ex;
            }

            Mechanisms = null;
            MechanismsException = ex;

            HwFeatures = null;
            HwFeaturesException = ex;

            DataObjects = null;
            DataObjectsException = ex;

            Certificates = null;
            CertificatesException = ex;

            Keys = null;
            KeysException = ex;

            DomainParams = null;
            DomainParamsException = ex;
        }

        public void Reload()
        {
            Reload(false);
        }

        private void Reload(bool onlySlotInfo)
        {
            if (this._disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            MarkSlotAsUsable();

            try
            {
                SlotInfo = ReadSlotInfo();
                SlotInfoException = null;
            }
            catch (Exception ex)
            {
                // TODO - Log exception

                // In order to keep the code sane consider slot unusable if C_GetSlotInfo fails
                MarkSlotAsUnusable(ex, isSlotInfoException: true);
                return;
            }

            if (onlySlotInfo)
                return;

            try
            {
                if (!SlotInfo.TokenPresent)
                    throw new TokenNotPresentException();

                TokenInfo = ReadTokenInfo();
                TokenInfoException = null;
            }
            catch (Exception ex)
            {
                // TODO - Log exception

                // In order to keep the code sane consider slot unusable if C_GetTokenInfo fails
                MarkSlotAsUnusable(ex, isTokenInfoException: true);
                return;
            }

            try
            {
                SessionInfo = ReadSessionInfo();
                SessionInfoException = null;
            }
            catch (Exception ex)
            {
                // TODO - Log exception

                // In order to keep the code sane consider slot unusable if C_GetSessionInfo fails
                MarkSlotAsUnusable(ex, isSessionInfoException: true);
                return;
            }

            try
            {
                Mechanisms = ReadMechanisms();
                MechanismsException = null;
            }
            catch (Exception ex)
            {
                // TODO - Log exception

                Mechanisms = null;
                MechanismsException = ex;
            }

            try
            {
                HwFeatures = ReadHwFeatures();
                HwFeaturesException = null;
            }
            catch (Exception ex)
            {
                // TODO - Log exception

                HwFeatures = null;
                HwFeaturesException = ex;
            }

            try
            {
                DataObjects = ReadDataObjects();
                DataObjectsException = null;
            }
            catch (Exception ex)
            {
                // TODO - Log exception

                DataObjects = null;
                DataObjectsException = ex;
            }

            try
            {
                Certificates = ReadCertificates();
                CertificatesException = null;
            }
            catch (Exception ex)
            {
                // TODO - Log exception

                Certificates = null;
                CertificatesException = ex;
            }

            try
            {
                Keys = ReadKeys();
                KeysException = null;
            }
            catch (Exception ex)
            {
                // TODO - Log exception

                Keys = null;
                KeysException = ex;
            }

            try
            {
                DomainParams = ReadDomainParams();
                DomainParamsException = null;
            }
            catch (Exception ex)
            {
                // TODO - Log exception

                DomainParams = null;
                DomainParamsException = ex;
            }
        }

        private Pkcs11SlotInfo ReadSlotInfo()
        {
            return new Pkcs11SlotInfo(_slot.GetSlotInfo());
        }

        private Pkcs11TokenInfo ReadTokenInfo()
        {
            return new Pkcs11TokenInfo(_slot.GetTokenInfo());
        }

        private Pkcs11SessionInfo ReadSessionInfo()
        {
            using (Session session = _slot.OpenSession(SessionType.ReadWrite))
                return new Pkcs11SessionInfo(session.GetSessionInfo(), TokenInfo.ProtectedAuthenticationPath);
        }

        private List<Pkcs11MechanismInfo> ReadMechanisms()
        {
            List<Pkcs11MechanismInfo> mechanisms = new List<Pkcs11MechanismInfo>();
            foreach (CKM mechanism in _slot.GetMechanismList())
            {
                MechanismInfo mechanismInfo = _slot.GetMechanismInfo(mechanism);
                mechanisms.Add(new Pkcs11MechanismInfo(mechanism, mechanismInfo));
            }

            return mechanisms;
        }

        private List<Pkcs11HwFeatureInfo> ReadHwFeatures()
        {
            List<Pkcs11HwFeatureInfo> infos = new List<Pkcs11HwFeatureInfo>();

            using (Session session = _slot.OpenSession(SessionType.ReadWrite))
            {
                List<ObjectAttribute> searchTemplate = new List<ObjectAttribute>();
                searchTemplate.Add(new ObjectAttribute(CKA.CKA_CLASS, CKO.CKO_HW_FEATURE));

                List<ObjectHandle> foundObjects = session.FindAllObjects(searchTemplate);
                foreach (ObjectHandle foundObject in foundObjects)
                {
                    // Read attributes required for sane object presentation
                    List<ulong> attributes = new List<ulong>();
                    attributes.Add((ulong)CKA.CKA_HW_FEATURE_TYPE);

                    List<ObjectAttribute> requiredAttributes = session.GetAttributeValue(foundObject, attributes);

                    // Read attributes configured for specific object class and type
                    attributes = new List<ulong>();
                    foreach (ClassAttribute classAttribute in Pkcs11Admin.Instance.Config.HwFeatureAttributes.CommonAttributes)
                        attributes.Add(classAttribute.Value);
                    ulong featureType = requiredAttributes[0].GetValueAsUlong();
                    if (Pkcs11Admin.Instance.Config.HwFeatureAttributes.TypeSpecificAttributes.ContainsKey(featureType))
                        foreach (ClassAttribute classAttribute in Pkcs11Admin.Instance.Config.HwFeatureAttributes.TypeSpecificAttributes[featureType])
                            attributes.Add(classAttribute.Value);

                    List<ObjectAttribute> configuredAttributes = session.GetAttributeValue(foundObject, attributes);

                    // Read object storage size
                    ulong? storageSize = ReadObjectSize(session, foundObject);

                    // Construct info object
                    Pkcs11HwFeatureInfo info = new Pkcs11HwFeatureInfo(foundObject, configuredAttributes, storageSize)
                    {
                        CkaHwFeatureType = requiredAttributes[0].GetValueAsUlong()
                    };

                    infos.Add(info);
                }
            }

            return infos;
        }

        private List<Pkcs11DataObjectInfo> ReadDataObjects()
        {
            List<Pkcs11DataObjectInfo> infos = new List<Pkcs11DataObjectInfo>();

            using (Session session = _slot.OpenSession(SessionType.ReadWrite))
            {
                List<ObjectAttribute> searchTemplate = new List<ObjectAttribute>();
                searchTemplate.Add(new ObjectAttribute(CKA.CKA_CLASS, CKO.CKO_DATA));

                List<ObjectHandle> foundObjects = session.FindAllObjects(searchTemplate);
                foreach (ObjectHandle foundObject in foundObjects)
                {
                    // Read attributes required for sane object presentation
                    List<ulong> attributes = new List<ulong>();
                    attributes.Add((ulong)CKA.CKA_PRIVATE);
                    attributes.Add((ulong)CKA.CKA_LABEL);
                    attributes.Add((ulong)CKA.CKA_APPLICATION);

                    List<ObjectAttribute> requiredAttributes = session.GetAttributeValue(foundObject, attributes);

                    // Read attributes configured for specific object class
                    attributes = new List<ulong>();
                    foreach (ClassAttribute classAttribute in Pkcs11Admin.Instance.Config.DataObjectAttributes.CommonAttributes)
                        attributes.Add(classAttribute.Value);

                    List<ObjectAttribute> configuredAttributes = session.GetAttributeValue(foundObject, attributes);

                    // Read object storage size
                    ulong? storageSize = ReadObjectSize(session, foundObject);

                    // Construct info object
                    Pkcs11DataObjectInfo info = new Pkcs11DataObjectInfo(foundObject, configuredAttributes, storageSize)
                    {
                        CkaPrivate = requiredAttributes[0].GetValueAsBool(),
                        CkaLabel = requiredAttributes[1].GetValueAsString(),
                        CkaApplication = requiredAttributes[2].GetValueAsString(),
                        StorageSize = storageSize
                    };

                    infos.Add(info);
                }
            }

            return infos;
        }

        private List<Pkcs11CertificateInfo> ReadCertificates()
        {
            List<Pkcs11CertificateInfo> infos = new List<Pkcs11CertificateInfo>();

            using (Session session = _slot.OpenSession(SessionType.ReadWrite))
            {
                List<ObjectAttribute> searchTemplate = new List<ObjectAttribute>();
                searchTemplate.Add(new ObjectAttribute(CKA.CKA_CLASS, CKO.CKO_CERTIFICATE));

                List<ObjectHandle> foundObjects = session.FindAllObjects(searchTemplate);
                foreach (ObjectHandle foundObject in foundObjects)
                {
                    // Read attributes required for sane object presentation
                    List<ulong> attributes = new List<ulong>();
                    attributes.Add((ulong)CKA.CKA_PRIVATE);
                    attributes.Add((ulong)CKA.CKA_CERTIFICATE_TYPE);
                    attributes.Add((ulong)CKA.CKA_LABEL);
                    attributes.Add((ulong)CKA.CKA_ID);
                    attributes.Add((ulong)CKA.CKA_VALUE);

                    List<ObjectAttribute> requiredAttributes = session.GetAttributeValue(foundObject, attributes);

                    // Read attributes configured for specific object class and type
                    attributes = new List<ulong>();
                    foreach (ClassAttribute classAttribute in Pkcs11Admin.Instance.Config.CertificateAttributes.CommonAttributes)
                        attributes.Add(classAttribute.Value);
                    ulong certType = requiredAttributes[1].GetValueAsUlong();
                    if (Pkcs11Admin.Instance.Config.CertificateAttributes.TypeSpecificAttributes.ContainsKey(certType))
                        foreach (ClassAttribute classAttribute in Pkcs11Admin.Instance.Config.CertificateAttributes.TypeSpecificAttributes[certType])
                            attributes.Add(classAttribute.Value);

                    List<ObjectAttribute> configuredAttributes = session.GetAttributeValue(foundObject, attributes);

                    // Read object storage size
                    ulong? storageSize = ReadObjectSize(session, foundObject);

                    // Construct info object
                    Pkcs11CertificateInfo info = new Pkcs11CertificateInfo(foundObject, configuredAttributes, storageSize)
                    {
                        CkaPrivate = requiredAttributes[0].GetValueAsBool(),
                        CkaCertificateType = requiredAttributes[1].GetValueAsUlong(),
                        CkaLabel = requiredAttributes[2].GetValueAsString(),
                        CkaId = requiredAttributes[3].GetValueAsByteArray(),
                        CkaValue = requiredAttributes[4].GetValueAsByteArray()
                    };

                    infos.Add(info);
                }
            }

            return infos;
        }

        private List<Pkcs11KeyInfo> ReadKeys(CKO objectClass, ClassAttributesDefinition keyAttributes)
        {
            List<Pkcs11KeyInfo> infos = new List<Pkcs11KeyInfo>();

            using (Session session = _slot.OpenSession(SessionType.ReadWrite))
            {
                List<ObjectAttribute> searchTemplate = new List<ObjectAttribute>();
                searchTemplate.Add(new ObjectAttribute(CKA.CKA_CLASS, objectClass));

                List<ObjectHandle> foundObjects = session.FindAllObjects(searchTemplate);
                foreach (ObjectHandle foundObject in foundObjects)
                {
                    // Read attributes required for sane object presentation
                    List<ulong> attributes = new List<ulong>();
                    attributes.Add((ulong)CKA.CKA_PRIVATE);
                    attributes.Add((ulong)CKA.CKA_KEY_TYPE);
                    attributes.Add((ulong)CKA.CKA_LABEL);
                    attributes.Add((ulong)CKA.CKA_ID);

                    List<ObjectAttribute> requiredAttributes = session.GetAttributeValue(foundObject, attributes);

                    // Read attributes configured for specific object class and type
                    attributes = new List<ulong>();
                    foreach (ClassAttribute classAttribute in keyAttributes.CommonAttributes)
                        attributes.Add(classAttribute.Value);
                    ulong keyType = requiredAttributes[1].GetValueAsUlong();
                    if (keyAttributes.TypeSpecificAttributes.ContainsKey(keyType))
                        foreach (ClassAttribute classAttribute in keyAttributes.TypeSpecificAttributes[keyType])
                            attributes.Add(classAttribute.Value);

                    List<ObjectAttribute> configuredAttributes = session.GetAttributeValue(foundObject, attributes);

                    // Read object storage size
                    ulong? storageSize = ReadObjectSize(session, foundObject);

                    // Construct info object
                    Pkcs11KeyInfo info = new Pkcs11KeyInfo(foundObject, configuredAttributes, storageSize)
                    {
                        CkaPrivate = requiredAttributes[0].GetValueAsBool(),
                        CkaClass = (ulong)objectClass,
                        CkaKeyType = requiredAttributes[1].GetValueAsUlong(),
                        CkaLabel = requiredAttributes[2].GetValueAsString(),
                        CkaId = requiredAttributes[3].GetValueAsByteArray()
                    };

                    infos.Add(info);
                }
            }

            return infos;
        }

        private List<Pkcs11KeyInfo> ReadKeys()
        {
            List<Pkcs11KeyInfo> infos = new List<Pkcs11KeyInfo>();

            infos.AddRange(ReadKeys(CKO.CKO_PRIVATE_KEY, Pkcs11Admin.Instance.Config.PrivateKeyAttributes));
            infos.AddRange(ReadKeys(CKO.CKO_PUBLIC_KEY, Pkcs11Admin.Instance.Config.PublicKeyAttributes));
            infos.AddRange(ReadKeys(CKO.CKO_SECRET_KEY, Pkcs11Admin.Instance.Config.SecretKeyAttributes));
            // TODO - This is not good enough because some libraries may still return error for unknown object classes
            if (0 <= StringUtils.CompareCkVersions(Pkcs11Admin.Instance.Library.Info.CryptokiVersion, "2.20"))
                infos.AddRange(ReadKeys(CKO.CKO_OTP_KEY, Pkcs11Admin.Instance.Config.OtpKeyAttributes));

            return infos;
        }

        private List<Pkcs11DomainParamsInfo> ReadDomainParams()
        {
            List<Pkcs11DomainParamsInfo> infos = new List<Pkcs11DomainParamsInfo>();

            using (Session session = _slot.OpenSession(SessionType.ReadWrite))
            {
                List<ObjectAttribute> searchTemplate = new List<ObjectAttribute>();
                searchTemplate.Add(new ObjectAttribute(CKA.CKA_CLASS, CKO.CKO_DOMAIN_PARAMETERS));

                List<ObjectHandle> foundObjects = session.FindAllObjects(searchTemplate);
                foreach (ObjectHandle foundObject in foundObjects)
                {
                    // Read attributes required for sane object presentation
                    List<ulong> attributes = new List<ulong>();
                    attributes.Add((ulong)CKA.CKA_PRIVATE);
                    attributes.Add((ulong)CKA.CKA_KEY_TYPE);
                    attributes.Add((ulong)CKA.CKA_LABEL);

                    List<ObjectAttribute> requiredAttributes = session.GetAttributeValue(foundObject, attributes);

                    // Read attributes configured for specific object class and type
                    attributes = new List<ulong>();
                    foreach (ClassAttribute classAttribute in Pkcs11Admin.Instance.Config.DomainParamsAttributes.CommonAttributes)
                        attributes.Add(classAttribute.Value);
                    ulong keyType = requiredAttributes[1].GetValueAsUlong();
                    if (Pkcs11Admin.Instance.Config.DomainParamsAttributes.TypeSpecificAttributes.ContainsKey(keyType))
                        foreach (ClassAttribute classAttribute in Pkcs11Admin.Instance.Config.DomainParamsAttributes.TypeSpecificAttributes[keyType])
                            attributes.Add(classAttribute.Value);

                    List<ObjectAttribute> configuredAttributes = session.GetAttributeValue(foundObject, attributes);

                    // Read object storage size
                    ulong? storageSize = ReadObjectSize(session, foundObject);

                    // Construct info object
                    Pkcs11DomainParamsInfo info = new Pkcs11DomainParamsInfo(foundObject, configuredAttributes, storageSize)
                    {
                        CkaPrivate = requiredAttributes[0].GetValueAsBool(),
                        CkaKeyType = requiredAttributes[1].GetValueAsUlong(),
                        CkaLabel = requiredAttributes[2].GetValueAsString()
                    };

                    infos.Add(info);
                }
            }

            return infos;
        }

        private ulong? ReadObjectSize(Session session, ObjectHandle objectHandle)
        {
            ulong? size = null;

            try
            {
                size = session.GetObjectSize(objectHandle);
            }
            catch
            {

            }

            return size;
        }

        private Dictionary<CKM, List<CKK>> GetKnownKeyGenerationMechanisms(TypeAttributes typeSpecificAttributes)
        {
            Dictionary<CKM, List<CKK>> knownMechanisms = new Dictionary<CKM, List<CKK>>();

            foreach (KeyValuePair<ulong, ClassAttributes> typeAttributes in typeSpecificAttributes)
            {
                CKK keyType = (CKK)typeAttributes.Key;
                CKM? mechanism = typeAttributes.Value.KeyGenerationMechanism;
                if (mechanism != null)
                {
                    if (!knownMechanisms.ContainsKey(mechanism.Value))
                        knownMechanisms.Add(mechanism.Value, new List<CKK>() { keyType });
                    else
                        knownMechanisms[mechanism.Value].Add(keyType);
                }
            }

            return knownMechanisms;
        }

        public List<CKK> GetGeneratableAsymmetricKeyTypes()
        {
            HashSet<CKK> keyTypes = new HashSet<CKK>();

            Dictionary<CKM, List<CKK>> knownMechanisms = GetKnownKeyGenerationMechanisms(Pkcs11Admin.Instance.Config.PrivateKeyAttributes.TypeSpecificAttributes);
            
            foreach (Pkcs11MechanismInfo mechanismInfo in Mechanisms)
            {
                if (mechanismInfo.GenerateKeyPair && knownMechanisms.ContainsKey(mechanismInfo.Mechanism))
                {
                    foreach (CKK keyType in knownMechanisms[mechanismInfo.Mechanism])
                    {
                        if (!keyTypes.Contains(keyType))
                            keyTypes.Add(keyType);
                    }
                }
            }

            return new List<CKK>(keyTypes);
        }

        public List<CKK> GetGeneratableSymmetricKeyTypes()
        {
            HashSet<CKK> keyTypes = new HashSet<CKK>();

            Dictionary<CKM, List<CKK>> knownMechanisms = GetKnownKeyGenerationMechanisms(Pkcs11Admin.Instance.Config.SecretKeyAttributes.TypeSpecificAttributes);

            foreach (Pkcs11MechanismInfo mechanismInfo in Mechanisms)
            {
                if (mechanismInfo.Generate && knownMechanisms.ContainsKey(mechanismInfo.Mechanism))
                {
                    foreach (CKK keyType in knownMechanisms[mechanismInfo.Mechanism])
                    {
                        if (!keyTypes.Contains(keyType))
                            keyTypes.Add(keyType);
                    }
                }
            }

            return new List<CKK>(keyTypes);
        }

        #endregion

        public void InitToken(string soPin, string label)
        {
            if (this._disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (_authenticatedSession != null)
                throw new Exception("Authenticated session exists");

            _slot.InitToken(soPin, label);
        }

        public void Login(CKU userType, string pin)
        {
            if (this._disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (_authenticatedSession != null)
                throw new Exception("Authenticated session already exists");

            _authenticatedSession = _slot.OpenSession(SessionType.ReadWrite);

            try
            {
                _authenticatedSession.Login(userType, pin);
            }
            catch (Exception)
            {
                _authenticatedSession.Dispose();
                _authenticatedSession = null;
                throw;
            }
        }

        public void ChangePin(string oldPin, string newPin)
        {
            if (this._disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (_authenticatedSession == null)
                throw new Exception("Authenticated session does not exist");

            using (Session session = _slot.OpenSession(SessionType.ReadWrite))
                session.SetPin(oldPin, newPin);
        }

        public void InitPin(string pin)
        {
            if (this._disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (_authenticatedSession == null)
                throw new Exception("Authenticated session does not exist");

            using (Session session = _slot.OpenSession(SessionType.ReadWrite))
                session.InitPin(pin);
        }

        public void Logout()
        {
            if (this._disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (_authenticatedSession == null)
                throw new Exception("Authenticated session does not exist");

            try
            {
                _authenticatedSession.Logout();
            }
            finally
            {
                _authenticatedSession.Dispose();
                _authenticatedSession = null;
            }
        }

        public void SaveObjectAttributes(Pkcs11ObjectInfo objectInfo, List<ObjectAttribute> objectAttributes)
        {
            if (this._disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (objectInfo == null)
                throw new ArgumentNullException("objectInfo");

            if (objectAttributes == null)
                throw new ArgumentNullException("objectAttributes");

            using (Session session = _slot.OpenSession(SessionType.ReadWrite))
                session.SetAttributeValue(objectInfo.ObjectHandle, objectAttributes);
        }

        public List<ObjectAttribute> LoadObjectAttributes(Pkcs11ObjectInfo objectInfo, List<ulong> attributes)
        {
            if (this._disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (objectInfo == null)
                throw new ArgumentNullException("objectInfo");

            if (attributes == null)
                throw new ArgumentNullException("objectAttributes");

            using (Session session = _slot.OpenSession(SessionType.ReadWrite))
                return session.GetAttributeValue(objectInfo.ObjectHandle, attributes);
        }

        public void DeleteObject(Pkcs11ObjectInfo objectInfo)
        {
            if (this._disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (objectInfo == null)
                throw new ArgumentNullException("objectInfo");

            using (Session session = _slot.OpenSession(SessionType.ReadWrite))
                session.DestroyObject(objectInfo.ObjectHandle);
        }

        public void CreateObject(List<ObjectAttribute> objectAttributes)
        {
            if (objectAttributes == null)
                throw new ArgumentNullException("objectAttributes");

            using (Session session = _slot.OpenSession(SessionType.ReadWrite))
                session.CreateObject(objectAttributes);
        }

        public List<Tuple<ObjectAttribute, ClassAttribute>> ImportDataObject(string fileName, byte[] fileContent)
        {
            List<Tuple<ObjectAttribute, ClassAttribute>> objectAttributes = StringUtils.GetCreateDefaultAttributes(Pkcs11Admin.Instance.Config.DataObjectAttributes, null);

            bool ckaLabelFound = false;
            bool ckaValueFound = false;

            for (int i = 0; i < objectAttributes.Count; i++)
            {
                ObjectAttribute objectAttribute = objectAttributes[i].Item1;
                ClassAttribute classAttribute = objectAttributes[i].Item2;

                if (objectAttribute.Type == (ulong)CKA.CKA_LABEL)
                {
                    objectAttributes[i] = new Tuple<ObjectAttribute, ClassAttribute>(new ObjectAttribute(CKA.CKA_LABEL, fileName), classAttribute);
                    ckaLabelFound = true;
                }
                else if (objectAttribute.Type == (ulong)CKA.CKA_VALUE)
                {
                    objectAttributes[i] = new Tuple<ObjectAttribute, ClassAttribute>(new ObjectAttribute(CKA.CKA_VALUE, fileContent), classAttribute);
                    ckaValueFound = true;
                }
            }

            if (!ckaLabelFound)
                throw new Exception("TODO - ClassAttributeNotFoundException");

            if (!ckaValueFound)
                throw new Exception("TODO - ClassAttributeNotFoundException");

            return objectAttributes;
        }

        public void ExportDataObject(Pkcs11DataObjectInfo objectInfo, out string fileName, out byte[] fileContent)
        {
            if (this._disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (objectInfo == null)
                throw new ArgumentNullException("objectInfo");

            using (Session session = _slot.OpenSession(SessionType.ReadWrite))
            {
                List<ulong> attributes = new List<ulong>();
                attributes.Add((ulong)CKA.CKA_LABEL);
                attributes.Add((ulong)CKA.CKA_VALUE);

                List<ObjectAttribute> objectAttributes = session.GetAttributeValue(objectInfo.ObjectHandle, attributes);

                fileName = objectAttributes[0].GetValueAsString();
                fileName = (!string.IsNullOrEmpty(fileName)) ? Utils.NormalizeFileName(fileName) : "data_object";
                fileContent = objectAttributes[1].GetValueAsByteArray();
            }
        }

        public List<Tuple<ObjectAttribute, ClassAttribute>> ImportCertificate(string fileName, byte[] fileContent)
        {
            X509CertificateParser x509CertificateParser = new X509CertificateParser();
            X509Certificate x509Certificate = x509CertificateParser.ReadCertificate(fileContent);

            List<Tuple<ObjectAttribute, ClassAttribute>> objectAttributes = StringUtils.GetCreateDefaultAttributes(Pkcs11Admin.Instance.Config.CertificateAttributes, (ulong)CKC.CKC_X_509);

            for (int i = 0; i < objectAttributes.Count; i++)
            {
                ObjectAttribute objectAttribute = objectAttributes[i].Item1;
                ClassAttribute classAttribute = objectAttributes[i].Item2;

                if (objectAttribute.Type == (ulong)CKA.CKA_LABEL)
                {
                    string label = fileName;
                    Dictionary<string, List<string>> subject = Utils.ParseX509Name(x509Certificate.SubjectDN);
                    if (subject.ContainsKey(X509ObjectIdentifiers.CommonName.Id) && (subject[X509ObjectIdentifiers.CommonName.Id].Count > 0))
                        label = subject[X509ObjectIdentifiers.CommonName.Id][0];

                    objectAttributes[i] = new Tuple<ObjectAttribute, ClassAttribute>(new ObjectAttribute(CKA.CKA_LABEL, label), classAttribute);
                }
                else if (objectAttribute.Type == (ulong)CKA.CKA_START_DATE)
                {
                    objectAttributes[i] = new Tuple<ObjectAttribute, ClassAttribute>(new ObjectAttribute(CKA.CKA_START_DATE, x509Certificate.NotBefore), classAttribute);
                }
                else if (objectAttribute.Type == (ulong)CKA.CKA_END_DATE)
                {
                    objectAttributes[i] = new Tuple<ObjectAttribute, ClassAttribute>(new ObjectAttribute(CKA.CKA_END_DATE, x509Certificate.NotAfter), classAttribute);
                }
                else if (objectAttribute.Type == (ulong)CKA.CKA_SUBJECT)
                {
                    objectAttributes[i] = new Tuple<ObjectAttribute, ClassAttribute>(new ObjectAttribute(CKA.CKA_SUBJECT, x509Certificate.SubjectDN.GetDerEncoded()), classAttribute);
                }
                else if (objectAttribute.Type == (ulong)CKA.CKA_ID)
                {
                    byte[] thumbPrint = null;
                    using (SHA1Managed sha1Managed = new SHA1Managed())
                        thumbPrint = sha1Managed.ComputeHash(x509Certificate.GetEncoded());

                    objectAttributes[i] = new Tuple<ObjectAttribute, ClassAttribute>(new ObjectAttribute(CKA.CKA_ID, thumbPrint), classAttribute);
                }
                else if (objectAttribute.Type == (ulong)CKA.CKA_ISSUER)
                {
                    objectAttributes[i] = new Tuple<ObjectAttribute, ClassAttribute>(new ObjectAttribute(CKA.CKA_ISSUER, x509Certificate.IssuerDN.GetDerEncoded()), classAttribute);
                }
                else if (objectAttribute.Type == (ulong)CKA.CKA_SERIAL_NUMBER)
                {
                    objectAttributes[i] = new Tuple<ObjectAttribute, ClassAttribute>(new ObjectAttribute(CKA.CKA_SERIAL_NUMBER, new DerInteger(x509Certificate.SerialNumber).GetDerEncoded()), classAttribute);
                }
                else if (objectAttribute.Type == (ulong)CKA.CKA_VALUE)
                {
                    objectAttributes[i] = new Tuple<ObjectAttribute, ClassAttribute>(new ObjectAttribute(CKA.CKA_VALUE, x509Certificate.GetEncoded()), classAttribute);
                }
            }

            return objectAttributes;
        }

        public void ExportCertificate(Pkcs11CertificateInfo objectInfo, out string fileName, out byte[] fileContent)
        {
            if (this._disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (objectInfo == null)
                throw new ArgumentNullException("objectInfo");

            fileName = (!string.IsNullOrEmpty(objectInfo.CkaLabel)) ? Utils.NormalizeFileName(objectInfo.CkaLabel + ".cer") : "certificate.cer";
            fileContent = objectInfo.CkaValue;
        }

        public void GenerateSymmetricKey(CKK keyType, List<ObjectAttribute> objectAttributes)
        {
            if (objectAttributes == null)
                throw new ArgumentNullException("objectAttributes");

            if (!Pkcs11Admin.Instance.Config.SecretKeyAttributes.TypeSpecificAttributes.ContainsKey((ulong)keyType))
                throw new Exception("Unsupported key type");

            CKM? mechanismType = Pkcs11Admin.Instance.Config.SecretKeyAttributes.TypeSpecificAttributes[(ulong)keyType].KeyGenerationMechanism;
            if (mechanismType == null)
                throw new Exception("Key generation mechanism not specified");

            using (Session session = _slot.OpenSession(SessionType.ReadWrite))
            using (Mechanism mechanism = new Mechanism(mechanismType.Value))
                session.GenerateKey(mechanism, objectAttributes);
        }

        public void GenerateAsymmetricKeyPair(CKK keyType, List<ObjectAttribute> privateKeyObjectAttributes, List<ObjectAttribute> publicKeyObjectAttributes)
        {
            if (privateKeyObjectAttributes == null)
                throw new ArgumentNullException("privateKeyObjectAttributes");

            if (publicKeyObjectAttributes == null)
                throw new ArgumentNullException("publicKeyObjectAttributes");

            if (!Pkcs11Admin.Instance.Config.PrivateKeyAttributes.TypeSpecificAttributes.ContainsKey((ulong)keyType))
                throw new Exception("Unsupported key type");

            CKM? mechanismType = Pkcs11Admin.Instance.Config.PrivateKeyAttributes.TypeSpecificAttributes[(ulong)keyType].KeyGenerationMechanism;
            if (mechanismType == null)
                throw new Exception("Key generation mechanism not specified");

            ObjectHandle privateKeyHandle = null;
            ObjectHandle publicKeyHandle = null;

            using (Session session = _slot.OpenSession(SessionType.ReadWrite))
            using (Mechanism mechanism = new Mechanism(mechanismType.Value))
                session.GenerateKeyPair(mechanism, publicKeyObjectAttributes, privateKeyObjectAttributes, out publicKeyHandle, out privateKeyHandle);
        }

        private AsymmetricKeyParameter GetPubKeyParams(Pkcs11KeyInfo privKeyInfo, Pkcs11KeyInfo pubKeyInfo)
        {
            if (privKeyInfo != null && privKeyInfo.CkaKeyType != (ulong)CKK.CKK_RSA)
                throw new Exception("Unsupported key type");

            if (pubKeyInfo != null && pubKeyInfo.CkaKeyType != (ulong)CKK.CKK_RSA)
                throw new Exception("Unsupported key type");

            Pkcs11KeyInfo rsaKeyInfo = (privKeyInfo != null) ? privKeyInfo : pubKeyInfo;

            using (Session session = _slot.OpenSession(SessionType.ReadWrite))
            {
                List<ObjectAttribute> attributes = session.GetAttributeValue(rsaKeyInfo.ObjectHandle, new List<CKA> { CKA.CKA_MODULUS, CKA.CKA_PUBLIC_EXPONENT });
                BigInteger modulus = new BigInteger(1, attributes[0].GetValueAsByteArray());
                BigInteger publicExponent = new BigInteger(1, attributes[1].GetValueAsByteArray());
                return new RsaKeyParameters(false, modulus, publicExponent);
            }
        }

        public void GenerateCsr(Pkcs11KeyInfo privKeyInfo, Pkcs11KeyInfo pubKeyInfo, DnEntry[] dnEntries, HashAlgorithm hashAlgorithm, out string fileName, out byte[] fileContent)
        {
            string signatureAlgorithmOid = hashAlgorithm.SignatureAlgorithmOid[(CKK)privKeyInfo.CkaKeyType];
            X509Name x509Name = Utils.CreateX509Name(dnEntries);
            AsymmetricKeyParameter publicKeyParameters = GetPubKeyParams(privKeyInfo, pubKeyInfo);

            Pkcs10CertificationRequestDelaySigned pkcs10 = new Pkcs10CertificationRequestDelaySigned(signatureAlgorithmOid, x509Name, publicKeyParameters, null);

            byte[] dataToSign = pkcs10.GetDataToSign();
            byte[] digest = hashAlgorithm.ComputeDigest(dataToSign);
            byte[] digestInfo = Utils.CreateDigestInfo(digest, hashAlgorithm.Oid);
            byte[] signature = null;

            using (Session session = _slot.OpenSession(SessionType.ReadWrite))
            using (Mechanism mechanism = new Mechanism(CKM.CKM_RSA_PKCS))
                signature = session.Sign(mechanism, privKeyInfo.ObjectHandle, digestInfo);

            pkcs10.SignRequest(new DerBitString(signature));
            byte[] csr = pkcs10.GetDerEncoded();

            fileName = (!string.IsNullOrEmpty(privKeyInfo.CkaLabel)) ? Utils.NormalizeFileName(privKeyInfo.CkaLabel + ".csr") : "pkcs10.csr";
            fileContent = csr;
        }

        public bool IsVulnerableToROCA(Pkcs11CertificateInfo certificateInfo)
        {
            X509CertificateParser x509CertificateParser = new X509CertificateParser();
            X509Certificate x509Certificate = x509CertificateParser.ReadCertificate(certificateInfo.CkaValue);
            RsaKeyParameters rsaKeyParameters = x509Certificate.GetPublicKey() as RsaKeyParameters;
            return RocaVulnerabilityTester.IsVulnerable(rsaKeyParameters);
        }

        public bool IsVulnerableToROCA(Pkcs11KeyInfo keyInfo)
        {
            RsaKeyParameters rsaKeyParameters = null;

            if (keyInfo.CkaClass == (ulong)CKO.CKO_PRIVATE_KEY && keyInfo.CkaKeyType == (ulong)CKK.CKK_RSA)
                rsaKeyParameters = GetPubKeyParams(keyInfo, null) as RsaKeyParameters;
            else if (keyInfo.CkaClass == (ulong)CKO.CKO_PUBLIC_KEY && keyInfo.CkaKeyType == (ulong)CKK.CKK_RSA)
                rsaKeyParameters = GetPubKeyParams(null, keyInfo) as RsaKeyParameters;
            else
                throw new Exception("Unsupported key type");

            return RocaVulnerabilityTester.IsVulnerable(rsaKeyParameters);
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    // Dispose managed objects

                    if (_authenticatedSession != null)
                    {
                        _authenticatedSession.Dispose();
                        _authenticatedSession = null;
                    }
                }

                // Dispose unmanaged objects

                _disposed = true;
            }
        }

        ~Pkcs11Slot()
        {
            Dispose(false);
        }

        #endregion
    }
}

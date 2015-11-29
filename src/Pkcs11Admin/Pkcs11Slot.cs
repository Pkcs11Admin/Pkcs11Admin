/*
 *  Pkcs11Admin - GUI tool for administration of PKCS#11 enabled devices
 *  Copyright (c) 2014-2015 Jaroslav Imrich <jimrich@jimrich.sk>
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
using System;
using System.Collections.Generic;

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
            using (Session session = _slot.OpenSession(false))
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

            using (Session session = _slot.OpenSession(true))
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

            using (Session session = _slot.OpenSession(true))
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

            using (Session session = _slot.OpenSession(true))
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

            using (Session session = _slot.OpenSession(true))
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

            using (Session session = _slot.OpenSession(true))
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

            _authenticatedSession = _slot.OpenSession(false);

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

            using (Session session = _slot.OpenSession(false))
                session.SetPin(oldPin, newPin);
        }

        public void InitPin(string pin)
        {
            if (this._disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (_authenticatedSession == null)
                throw new Exception("Authenticated session does not exist");

            using (Session session = _slot.OpenSession(false))
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

            using (Session session = _slot.OpenSession(false))
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

            using (Session session = _slot.OpenSession(true))
                return session.GetAttributeValue(objectInfo.ObjectHandle, attributes);
        }

        public void DeleteObject(Pkcs11ObjectInfo objectInfo)
        {
            if (this._disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (objectInfo == null)
                throw new ArgumentNullException("objectInfo");

            using (Session session = _slot.OpenSession(false))
                session.DestroyObject(objectInfo.ObjectHandle);
        }

        public void CreateObject(List<ObjectAttribute> objectAttributes)
        {
            if (objectAttributes == null)
                throw new ArgumentNullException("objectAttributes");

            using (Session session = _slot.OpenSession(false))
                session.CreateObject(objectAttributes);
        }

        public List<Tuple<ObjectAttribute, ClassAttribute>> ImportDataObject(string fileName, byte[] fileContent)
        {
            List<Tuple<ObjectAttribute, ClassAttribute>> objectAttributes = StringUtils.GetDefaultAttributes(Pkcs11Admin.Instance.Config.DataObjectAttributes, null);

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

        public void ExportDataObject(Pkcs11ObjectInfo objectInfo, out string fileName, out byte[] fileContent)
        {
            if (this._disposed)
                throw new ObjectDisposedException(this.GetType().FullName);

            if (objectInfo == null)
                throw new ArgumentNullException("objectInfo");

            using (Session session = _slot.OpenSession(true))
            {
                List<ulong> attributes = new List<ulong>();
                attributes.Add((ulong)CKA.CKA_LABEL);
                attributes.Add((ulong)CKA.CKA_VALUE);

                List<ObjectAttribute> objectAttributes = session.GetAttributeValue(objectInfo.ObjectHandle, attributes);

                fileName = objectAttributes[0].GetValueAsString();
                fileContent = objectAttributes[1].GetValueAsByteArray();
            }
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

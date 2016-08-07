/*
 *  Pkcs11Admin - GUI tool for administration of PKCS#11 enabled devices
 *  Copyright (c) 2014-2016 Jaroslav Imrich <jimrich@jimrich.sk>
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

using Net.Pkcs11Interop.Common;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace Net.Pkcs11Admin.Configuration
{
    [DataContract(Namespace = Pkcs11AdminConfig.Namespace)]
    public class Pkcs11AdminConfig
    {
        internal const string Namespace = @"http://pkcs11admin.net/configuration/1.0.0/";

        [DataMember(Order = 1, IsRequired = true)]
        public AttributeDefinitions AttributeDefinitions
        {
            get;
            set;
        }

        [DataMember(Order = 2, IsRequired = true)]
        public EnumDefinitions EnumDefinitions
        {
            get;
            set;
        }

        [DataMember(Order = 3, IsRequired = true)]
        public ClassAttributesDefinition HwFeatureAttributes
        {
            get;
            set;
        }

        [DataMember(Order = 4, IsRequired = true)]
        public ClassAttributesDefinition DataObjectAttributes
        {
            get;
            set;
        }

        [DataMember(Order = 5, IsRequired = true)]
        public ClassAttributesDefinition CertificateAttributes
        {
            get;
            set;
        }

        [DataMember(Order = 6, IsRequired = true)]
        public ClassAttributesDefinition PrivateKeyAttributes
        {
            get;
            set;
        }

        [DataMember(Order = 7, IsRequired = true)]
        public ClassAttributesDefinition PublicKeyAttributes
        {
            get;
            set;
        }

        [DataMember(Order = 8, IsRequired = true)]
        public ClassAttributesDefinition SecretKeyAttributes
        {
            get;
            set;
        }

        [DataMember(Order = 9, IsRequired = true)]
        public ClassAttributesDefinition OtpKeyAttributes
        {
            get;
            set;
        }

        [DataMember(Order = 10, IsRequired = true)]
        public ClassAttributesDefinition DomainParamsAttributes
        {
            get;
            set;
        }

        [DataMember(Order = 11, IsRequired = true)]
        public DnEntryDefinitions DnEntryDefinitions
        {
            get;
            set;
        }

        public static Pkcs11AdminConfig Load(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");

            using (FileStream fileStream = new FileStream(path, FileMode.Open))
                return XmlSerializer.Deserialize<Pkcs11AdminConfig>(fileStream);
        }

        public static void Save(string path, Pkcs11AdminConfig pkcs11AdminConfig)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");

            if (pkcs11AdminConfig == null)
                throw new ArgumentNullException("pkcs11AdminConfig");

            using (FileStream fileStream = new FileStream(path, FileMode.Create))
                XmlSerializer.Serialize(pkcs11AdminConfig, fileStream);
        }

        public static Pkcs11AdminConfig GetDefault()
        {
            Pkcs11AdminConfig cfg = new Pkcs11AdminConfig();

            #region Pkcs11Attributes

            cfg.AttributeDefinitions = new AttributeDefinitions();
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_CLASS, new AttributeDefinition() { Name = "CKA_CLASS", Value = (ulong)CKA.CKA_CLASS, Description = "Object class (type)", Type = AttributeType.ULong, Enum = "CKO" });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_TOKEN, new AttributeDefinition() { Name = "CKA_TOKEN", Value = (ulong)CKA.CKA_TOKEN, Description = "True if object is a token object; false if object is a session object", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_PRIVATE, new AttributeDefinition() { Name = "CKA_PRIVATE", Value = (ulong)CKA.CKA_PRIVATE, Description = "True if object is a private object; false if object is a public object", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_LABEL, new AttributeDefinition() { Name = "CKA_LABEL", Value = (ulong)CKA.CKA_LABEL, Description = "Description of the object", Type = AttributeType.String });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_APPLICATION, new AttributeDefinition() { Name = "CKA_APPLICATION", Value = (ulong)CKA.CKA_APPLICATION, Description = "Description of the application that manages the object", Type = AttributeType.String });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_VALUE, new AttributeDefinition() { Name = "CKA_VALUE", Value = (ulong)CKA.CKA_VALUE, Description = "Value of the object", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_OBJECT_ID, new AttributeDefinition() { Name = "CKA_OBJECT_ID", Value = (ulong)CKA.CKA_OBJECT_ID, Description = "DER-encoding of the object identifier indicating the data object type", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_CERTIFICATE_TYPE, new AttributeDefinition() { Name = "CKA_CERTIFICATE_TYPE", Value = (ulong)CKA.CKA_CERTIFICATE_TYPE, Description = "Type of certificate", Type = AttributeType.ULong, Enum = "CKC" });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_ISSUER, new AttributeDefinition() { Name = "CKA_ISSUER", Value = (ulong)CKA.CKA_ISSUER, Description = "DER-encoding of the certificate issuer name", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_SERIAL_NUMBER, new AttributeDefinition() { Name = "CKA_SERIAL_NUMBER", Value = (ulong)CKA.CKA_SERIAL_NUMBER, Description = "DER-encoding of the certificate serial number", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_AC_ISSUER, new AttributeDefinition() { Name = "CKA_AC_ISSUER", Value = (ulong)CKA.CKA_AC_ISSUER, Description = "DER-encoding of the attribute certificate's issuer field", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_OWNER, new AttributeDefinition() { Name = "CKA_OWNER", Value = (ulong)CKA.CKA_OWNER, Description = "DER-encoding of the attribute certificate's subject field", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_ATTR_TYPES, new AttributeDefinition() { Name = "CKA_ATTR_TYPES", Value = (ulong)CKA.CKA_ATTR_TYPES, Description = "BER-encoding of a sequence of object identifier values corresponding to the attribute types contained in the certificate", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_TRUSTED, new AttributeDefinition() { Name = "CKA_TRUSTED", Value = (ulong)CKA.CKA_TRUSTED, Description = "The certificate can be trusted for the application that it was created", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_CERTIFICATE_CATEGORY, new AttributeDefinition() { Name = "CKA_CERTIFICATE_CATEGORY", Value = (ulong)CKA.CKA_CERTIFICATE_CATEGORY, Description = "Categorization of the certificate: 0 = unspecified (default value), 1 = token user, 2 = authority, 3 = other entity", Type = AttributeType.ULong }); // TODO - Enum?
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_JAVA_MIDP_SECURITY_DOMAIN, new AttributeDefinition() { Name = "CKA_JAVA_MIDP_SECURITY_DOMAIN", Value = (ulong)CKA.CKA_JAVA_MIDP_SECURITY_DOMAIN, Description = "Java MIDP security domain: 0 = unspecified (default value), 1 = manufacturer, 2 = operator, 3 = third party", Type = AttributeType.ULong }); // TODO - Enum?
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_URL, new AttributeDefinition() { Name = "CKA_URL", Value = (ulong)CKA.CKA_URL, Description = "If not empty this attribute gives the URL where the complete certificate can be obtained", Type = AttributeType.String });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_HASH_OF_SUBJECT_PUBLIC_KEY, new AttributeDefinition() { Name = "CKA_HASH_OF_SUBJECT_PUBLIC_KEY", Value = (ulong)CKA.CKA_HASH_OF_SUBJECT_PUBLIC_KEY, Description = "SHA-1 hash of the subject public key", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_HASH_OF_ISSUER_PUBLIC_KEY, new AttributeDefinition() { Name = "CKA_HASH_OF_ISSUER_PUBLIC_KEY", Value = (ulong)CKA.CKA_HASH_OF_ISSUER_PUBLIC_KEY, Description = "SHA-1 hash of the issuer public key", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_CHECK_VALUE, new AttributeDefinition() { Name = "CKA_CHECK_VALUE", Value = (ulong)CKA.CKA_CHECK_VALUE, Description = "Checksum", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_KEY_TYPE, new AttributeDefinition() { Name = "CKA_KEY_TYPE", Value = (ulong)CKA.CKA_KEY_TYPE, Description = "Type of key", Type = AttributeType.ULong, Enum = "CKK" });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_SUBJECT, new AttributeDefinition() { Name = "CKA_SUBJECT", Value = (ulong)CKA.CKA_SUBJECT, Description = "DER-encoding of the key subject name", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_ID, new AttributeDefinition() { Name = "CKA_ID", Value = (ulong)CKA.CKA_ID, Description = "Key identifier for public/private key pair", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_SENSITIVE, new AttributeDefinition() { Name = "CKA_SENSITIVE", Value = (ulong)CKA.CKA_SENSITIVE, Description = "True if key is sensitive", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_ENCRYPT, new AttributeDefinition() { Name = "CKA_ENCRYPT", Value = (ulong)CKA.CKA_ENCRYPT, Description = "True if key supports encryption", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_DECRYPT, new AttributeDefinition() { Name = "CKA_DECRYPT", Value = (ulong)CKA.CKA_DECRYPT, Description = "True if key supports decryption", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_WRAP, new AttributeDefinition() { Name = "CKA_WRAP", Value = (ulong)CKA.CKA_WRAP, Description = "True if key supports wrapping (i.e., can be used to wrap other keys)", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_UNWRAP, new AttributeDefinition() { Name = "CKA_UNWRAP", Value = (ulong)CKA.CKA_UNWRAP, Description = "True if key supports unwrapping (i.e., can be used to unwrap other keys)", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_SIGN, new AttributeDefinition() { Name = "CKA_SIGN", Value = (ulong)CKA.CKA_SIGN, Description = "True if key supports signatures (i.e., authentication codes) where the signature is an appendix to the data", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_SIGN_RECOVER, new AttributeDefinition() { Name = "CKA_SIGN_RECOVER", Value = (ulong)CKA.CKA_SIGN_RECOVER, Description = "True if key supports signatures where the data can be recovered from the signature", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_VERIFY, new AttributeDefinition() { Name = "CKA_VERIFY", Value = (ulong)CKA.CKA_VERIFY, Description = "True if key supports verification (i.e., of authentication codes) where the signature is an appendix to the data", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_VERIFY_RECOVER, new AttributeDefinition() { Name = "CKA_VERIFY_RECOVER", Value = (ulong)CKA.CKA_VERIFY_RECOVER, Description = "True if key supports verification where the data is recovered from the signature", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_DERIVE, new AttributeDefinition() { Name = "CKA_DERIVE", Value = (ulong)CKA.CKA_DERIVE, Description = "True if key supports key derivation (i.e., if other keys can be derived from this one)", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_START_DATE, new AttributeDefinition() { Name = "CKA_START_DATE", Value = (ulong)CKA.CKA_START_DATE, Description = "Start date for the certificate/key", Type = AttributeType.DateTime });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_END_DATE, new AttributeDefinition() { Name = "CKA_END_DATE", Value = (ulong)CKA.CKA_END_DATE, Description = "End date for the certificate/key", Type = AttributeType.DateTime });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_MODULUS, new AttributeDefinition() { Name = "CKA_MODULUS", Value = (ulong)CKA.CKA_MODULUS, Description = "Modulus n", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_MODULUS_BITS, new AttributeDefinition() { Name = "CKA_MODULUS_BITS", Value = (ulong)CKA.CKA_MODULUS_BITS, Description = "Length in bits of modulus n", Type = AttributeType.ULong });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_PUBLIC_EXPONENT, new AttributeDefinition() { Name = "CKA_PUBLIC_EXPONENT", Value = (ulong)CKA.CKA_PUBLIC_EXPONENT, Description = "Public exponent e", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_PRIVATE_EXPONENT, new AttributeDefinition() { Name = "CKA_PRIVATE_EXPONENT", Value = (ulong)CKA.CKA_PRIVATE_EXPONENT, Description = "Private exponent d", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_PRIME_1, new AttributeDefinition() { Name = "CKA_PRIME_1", Value = (ulong)CKA.CKA_PRIME_1, Description = "Prime p", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_PRIME_2, new AttributeDefinition() { Name = "CKA_PRIME_2", Value = (ulong)CKA.CKA_PRIME_2, Description = "Prime q", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_EXPONENT_1, new AttributeDefinition() { Name = "CKA_EXPONENT_1", Value = (ulong)CKA.CKA_EXPONENT_1, Description = "Private exponent d modulo p-1", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_EXPONENT_2, new AttributeDefinition() { Name = "CKA_EXPONENT_2", Value = (ulong)CKA.CKA_EXPONENT_2, Description = "Private exponent d modulo q-1", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_COEFFICIENT, new AttributeDefinition() { Name = "CKA_COEFFICIENT", Value = (ulong)CKA.CKA_COEFFICIENT, Description = "CRT coefficient q^-1 mod p", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_PRIME, new AttributeDefinition() { Name = "CKA_PRIME", Value = (ulong)CKA.CKA_PRIME, Description = "Prime p (512 to 1024 bits, in steps of 64 bits)", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_SUBPRIME, new AttributeDefinition() { Name = "CKA_SUBPRIME", Value = (ulong)CKA.CKA_SUBPRIME, Description = "Subprime q (160 bits)", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_BASE, new AttributeDefinition() { Name = "CKA_BASE", Value = (ulong)CKA.CKA_BASE, Description = "Base g", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_PRIME_BITS, new AttributeDefinition() { Name = "CKA_PRIME_BITS", Value = (ulong)CKA.CKA_PRIME_BITS, Description = "Length of the prime value", Type = AttributeType.ULong });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_SUBPRIME_BITS, new AttributeDefinition() { Name = "CKA_SUBPRIME_BITS", Value = (ulong)CKA.CKA_SUBPRIME_BITS, Description = "Length of the subprime value", Type = AttributeType.ULong });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_VALUE_BITS, new AttributeDefinition() { Name = "CKA_VALUE_BITS", Value = (ulong)CKA.CKA_VALUE_BITS, Description = "Length in bits of private value x", Type = AttributeType.ULong });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_VALUE_LEN, new AttributeDefinition() { Name = "CKA_VALUE_LEN", Value = (ulong)CKA.CKA_VALUE_LEN, Description = "Length in bytes of key value", Type = AttributeType.ULong });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_EXTRACTABLE, new AttributeDefinition() { Name = "CKA_EXTRACTABLE", Value = (ulong)CKA.CKA_EXTRACTABLE, Description = "True if key is extractable and can be wrapped", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_LOCAL, new AttributeDefinition() { Name = "CKA_LOCAL", Value = (ulong)CKA.CKA_LOCAL, Description = "True only if key was either generated locally (i.e., on the token) or created as a copy of a key which had its CKA_LOCAL attribute set to true", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_NEVER_EXTRACTABLE, new AttributeDefinition() { Name = "CKA_NEVER_EXTRACTABLE", Value = (ulong)CKA.CKA_NEVER_EXTRACTABLE, Description = "True if key has never had the CKA_EXTRACTABLE attribute set to true", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_ALWAYS_SENSITIVE, new AttributeDefinition() { Name = "CKA_ALWAYS_SENSITIVE", Value = (ulong)CKA.CKA_ALWAYS_SENSITIVE, Description = "True if key has always had the CKA_SENSITIVE attribute set to true", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_KEY_GEN_MECHANISM, new AttributeDefinition() { Name = "CKA_KEY_GEN_MECHANISM", Value = (ulong)CKA.CKA_KEY_GEN_MECHANISM, Description = "Identifier of the mechanism used to generate the key material", Type = AttributeType.ULong, Enum = "CKM" });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_MODIFIABLE, new AttributeDefinition() { Name = "CKA_MODIFIABLE", Value = (ulong)CKA.CKA_MODIFIABLE, Description = "True if object can be modified", Type = AttributeType.Bool });
            // Note: CKA_ECDSA_PARAMS is deprecated in v2.11, CKA_EC_PARAMS is preferred.
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_EC_PARAMS, new AttributeDefinition() { Name = "CKA_EC_PARAMS", Value = (ulong)CKA.CKA_EC_PARAMS, Description = "DER-encoding of an ANSI X9.62 Parameters value", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_EC_POINT, new AttributeDefinition() { Name = "CKA_EC_POINT", Value = (ulong)CKA.CKA_EC_POINT, Description = "DER-encoding of ANSI X9.62 ECPoint value Q", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_SECONDARY_AUTH, new AttributeDefinition() { Name = "CKA_SECONDARY_AUTH", Value = (ulong)CKA.CKA_SECONDARY_AUTH, Description = "True if the key requires a secondary authentication to take place before its use it allowed", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_AUTH_PIN_FLAGS, new AttributeDefinition() { Name = "CKA_AUTH_PIN_FLAGS", Value = (ulong)CKA.CKA_AUTH_PIN_FLAGS, Description = "Mask indicating the current state of the secondary authentication PIN", Type = AttributeType.ULong });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_ALWAYS_AUTHENTICATE, new AttributeDefinition() { Name = "CKA_ALWAYS_AUTHENTICATE", Value = (ulong)CKA.CKA_ALWAYS_AUTHENTICATE, Description = "If true, the user has to supply the PIN for each use (sign or decrypt) with the key", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_WRAP_WITH_TRUSTED, new AttributeDefinition() { Name = "CKA_WRAP_WITH_TRUSTED", Value = (ulong)CKA.CKA_WRAP_WITH_TRUSTED, Description = "True if the key can only be wrapped with a wrapping key that has CKA_TRUSTED set to true", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)(CKF.CKF_ARRAY_ATTRIBUTE | 0x00000211), new AttributeDefinition() { Name = "CKA_WRAP_TEMPLATE", Value = (ulong)(CKF.CKF_ARRAY_ATTRIBUTE | 0x00000211), Description = "The attribute template to match against any keys wrapped using this wrapping key. Keys that do not match cannot be wrapped.", Type = AttributeType.AttributeArray });
            cfg.AttributeDefinitions.Add((ulong)(CKF.CKF_ARRAY_ATTRIBUTE | 0x00000212), new AttributeDefinition() { Name = "CKA_UNWRAP_TEMPLATE", Value = (ulong)(CKF.CKF_ARRAY_ATTRIBUTE | 0x00000212), Description = "The attribute template to apply to any keys unwrapped using this wrapping key. Any user supplied template is applied after this template as if the object has already been created.", Type = AttributeType.AttributeArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_OTP_FORMAT, new AttributeDefinition() { Name = "CKA_OTP_FORMAT", Value = (ulong)CKA.CKA_OTP_FORMAT, Description = "Format of OTP values produced with this key: CK_OTP_FORMAT_DECIMAL = Decimal, CK_OTP_FORMAT_HEXADECIMAL = Hexadecimal, CK_OTP_FORMAT_ALPHANUMERIC = Alphanumeric, CK_OTP_FORMAT_BINARY = Only binary values", Type = AttributeType.ULong }); // TODO - Enum?
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_OTP_LENGTH, new AttributeDefinition() { Name = "CKA_OTP_LENGTH", Value = (ulong)CKA.CKA_OTP_LENGTH, Description = "Default length of OTP values (in the CKA_OTP_FORMAT) produced with this key", Type = AttributeType.ULong });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_OTP_TIME_INTERVAL, new AttributeDefinition() { Name = "CKA_OTP_TIME_INTERVAL", Value = (ulong)CKA.CKA_OTP_TIME_INTERVAL, Description = "Interval between OTP values produced with this key, in seconds", Type = AttributeType.ULong });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_OTP_USER_FRIENDLY_MODE, new AttributeDefinition() { Name = "CKA_OTP_USER_FRIENDLY_MODE", Value = (ulong)CKA.CKA_OTP_USER_FRIENDLY_MODE, Description = "Set to true when the token is capable of returning OTPs suitable for human consumption", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_OTP_CHALLENGE_REQUIREMENT, new AttributeDefinition() { Name = "CKA_OTP_CHALLENGE_REQUIREMENT", Value = (ulong)CKA.CKA_OTP_CHALLENGE_REQUIREMENT, Description = "Parameter requirements when generating or verifying OTP values with this key: CK_OTP_PARAM_MANDATORY = A challenge must be supplied. CK_OTP_PARAM_OPTIONAL = A challenge may be supplied but need not be. CK_OTP_PARAM_IGNORED = A challenge, if supplied, will be ignored.", Type = AttributeType.ULong }); // TODO - Enum?
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_OTP_TIME_REQUIREMENT, new AttributeDefinition() { Name = "CKA_OTP_TIME_REQUIREMENT", Value = (ulong)CKA.CKA_OTP_TIME_REQUIREMENT, Description = "Parameter requirements when generating or verifying OTP values with this key: CK_OTP_PARAM_MANDATORY = A time value must be supplied. CK_OTP_PARAM_OPTIONAL = A time value may be supplied but need not be. CK_OTP_PARAM_IGNORED = A time value, if supplied, will be ignored.", Type = AttributeType.ULong }); // TODO - Enum?
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_OTP_COUNTER_REQUIREMENT, new AttributeDefinition() { Name = "CKA_OTP_COUNTER_REQUIREMENT", Value = (ulong)CKA.CKA_OTP_COUNTER_REQUIREMENT, Description = "Parameter requirements when generating or verifying OTP values with this key: CK_OTP_PARAM_MANDATORY = A counter value must be supplied. CK_OTP_PARAM_OPTIONAL = A counter value may be supplied but need not be. CK_OTP_PARAM_IGNORED = A counter value, if supplied, will be ignored.", Type = AttributeType.ULong }); // TODO - Enum?
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_OTP_PIN_REQUIREMENT, new AttributeDefinition() { Name = "CKA_OTP_PIN_REQUIREMENT", Value = (ulong)CKA.CKA_OTP_PIN_REQUIREMENT, Description = "Parameter requirements when generating or verifying OTP values with this key: CK_OTP_PARAM_MANDATORY = A PIN value must be supplied. CK_OTP_PARAM_OPTIONAL = A PIN value may be supplied but need not be. CK_OTP_PARAM_IGNORED = A PIN value, if supplied, will be ignored.", Type = AttributeType.ULong }); // TODO - Enum?
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_OTP_COUNTER, new AttributeDefinition() { Name = "CKA_OTP_COUNTER", Value = (ulong)CKA.CKA_OTP_COUNTER, Description = "Value of the associated internal counter", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_OTP_TIME, new AttributeDefinition() { Name = "CKA_OTP_TIME", Value = (ulong)CKA.CKA_OTP_TIME, Description = "Value of the associated internal UTC time in the form YYYYMMDDhhmmss", Type = AttributeType.String });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_OTP_USER_IDENTIFIER, new AttributeDefinition() { Name = "CKA_OTP_USER_IDENTIFIER", Value = (ulong)CKA.CKA_OTP_USER_IDENTIFIER, Description = "Text string that identifies a user associated with the OTP key (may be used to enhance the user experience)", Type = AttributeType.String });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_OTP_SERVICE_IDENTIFIER, new AttributeDefinition() { Name = "CKA_OTP_SERVICE_IDENTIFIER", Value = (ulong)CKA.CKA_OTP_SERVICE_IDENTIFIER, Description = "Text string that identifies a service that may validate OTPs generated by this key", Type = AttributeType.String });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_OTP_SERVICE_LOGO, new AttributeDefinition() { Name = "CKA_OTP_SERVICE_LOGO", Value = (ulong)CKA.CKA_OTP_SERVICE_LOGO, Description = "Logotype image that identifies a service that may validate OTPs generated by this key", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_OTP_SERVICE_LOGO_TYPE, new AttributeDefinition() { Name = "CKA_OTP_SERVICE_LOGO_TYPE", Value = (ulong)CKA.CKA_OTP_SERVICE_LOGO_TYPE, Description = "MIME type of the CKA_OTP_SERVICE_LOGO attribute value", Type = AttributeType.String });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_HW_FEATURE_TYPE, new AttributeDefinition() { Name = "CKA_HW_FEATURE_TYPE", Value = (ulong)CKA.CKA_HW_FEATURE_TYPE, Description = "Hardware feature (type)", Type = AttributeType.ULong, Enum = "CKH" });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_RESET_ON_INIT, new AttributeDefinition() { Name = "CKA_RESET_ON_INIT", Value = (ulong)CKA.CKA_RESET_ON_INIT, Description = "The value of the counter will reset to a previously returned value if the token is initialized", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_HAS_RESET, new AttributeDefinition() { Name = "CKA_HAS_RESET", Value = (ulong)CKA.CKA_HAS_RESET, Description = "The value of the counter has been reset at least once at some point in time", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_PIXEL_X, new AttributeDefinition() { Name = "CKA_PIXEL_X", Value = (ulong)CKA.CKA_PIXEL_X, Description = "Screen resolution (in pixels) in X-axis", Type = AttributeType.ULong });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_PIXEL_Y, new AttributeDefinition() { Name = "CKA_PIXEL_Y", Value = (ulong)CKA.CKA_PIXEL_Y, Description = "Screen resolution (in pixels) in Y-axis", Type = AttributeType.ULong });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_RESOLUTION, new AttributeDefinition() { Name = "CKA_RESOLUTION", Value = (ulong)CKA.CKA_RESOLUTION, Description = "DPI (pixels per inch)", Type = AttributeType.ULong });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_CHAR_ROWS, new AttributeDefinition() { Name = "CKA_CHAR_ROWS", Value = (ulong)CKA.CKA_CHAR_ROWS, Description = "Number of character rows for character-oriented displays", Type = AttributeType.ULong });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_CHAR_COLUMNS, new AttributeDefinition() { Name = "CKA_CHAR_COLUMNS", Value = (ulong)CKA.CKA_CHAR_COLUMNS, Description = "Number of character columns for character-oriented displays", Type = AttributeType.ULong });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_COLOR, new AttributeDefinition() { Name = "CKA_COLOR", Value = (ulong)CKA.CKA_COLOR, Description = "Color support", Type = AttributeType.Bool });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_BITS_PER_PIXEL, new AttributeDefinition() { Name = "CKA_BITS_PER_PIXEL", Value = (ulong)CKA.CKA_BITS_PER_PIXEL, Description = "The number of bits of color or grayscale information per pixel", Type = AttributeType.ULong });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_CHAR_SETS, new AttributeDefinition() { Name = "CKA_CHAR_SETS", Value = (ulong)CKA.CKA_CHAR_SETS, Description = "String indicating supported character sets, as defined by IANA MIBenum sets (www.iana.org). Supported character sets are separated with \";\" e.g. a token supporting iso-8859-1 and us-ascii would set the attribute value to \"4;3\".", Type = AttributeType.String });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_ENCODING_METHODS, new AttributeDefinition() { Name = "CKA_ENCODING_METHODS", Value = (ulong)CKA.CKA_ENCODING_METHODS, Description = "String indicating supported content transfer encoding methods, as defined by IANA (www.iana.org). Supported methods are separated with \";\" e.g. a token supporting 7bit, 8bit and base64 could set the attribute value to \"7bit;8bit;base64\".", Type = AttributeType.String });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_MIME_TYPES, new AttributeDefinition() { Name = "CKA_MIME_TYPES", Value = (ulong)CKA.CKA_MIME_TYPES, Description = "String indicating supported (presentable) MIME-types, as defined by IANA (www.iana.org). Supported types are separated with \";\" e.g. a token supporting MIME types \"a/b\", \"a/c\" and \"a/d\" would set the attribute value to \"a/b;a/c;a/d\".", Type = AttributeType.String });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_MECHANISM_TYPE, new AttributeDefinition() { Name = "CKA_MECHANISM_TYPE", Value = (ulong)CKA.CKA_MECHANISM_TYPE, Description = "The type of mechanism object", Type = AttributeType.ULong, Enum = "CKM" });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_REQUIRED_CMS_ATTRIBUTES, new AttributeDefinition() { Name = "CKA_REQUIRED_CMS_ATTRIBUTES", Value = (ulong)CKA.CKA_REQUIRED_CMS_ATTRIBUTES, Description = "Attributes the token always will include in the set of CMS signed attributes", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_DEFAULT_CMS_ATTRIBUTES, new AttributeDefinition() { Name = "CKA_DEFAULT_CMS_ATTRIBUTES", Value = (ulong)CKA.CKA_DEFAULT_CMS_ATTRIBUTES, Description = "Attributes the token will include in the set of CMS signed attributes in the absence of any attributes specified by the application", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)CKA.CKA_SUPPORTED_CMS_ATTRIBUTES, new AttributeDefinition() { Name = "CKA_SUPPORTED_CMS_ATTRIBUTES", Value = (ulong)CKA.CKA_SUPPORTED_CMS_ATTRIBUTES, Description = "Attributes the token may include in the set of CMS signed attributes upon request by the application", Type = AttributeType.ByteArray });
            cfg.AttributeDefinitions.Add((ulong)(CKF.CKF_ARRAY_ATTRIBUTE | 0x00000600), new AttributeDefinition() { Name = "CKA_ALLOWED_MECHANISMS", Value = (ulong)(CKF.CKF_ARRAY_ATTRIBUTE | 0x00000600), Description = "A list of mechanisms allowed to be used with this key", Type = AttributeType.ULongArray }); // TODO - List<CKM> / List<ulong>

            #endregion

            #region Enumerations

            #region CKM

            EnumDefinition ckmEnum = new EnumDefinition();
            ckmEnum.Add((ulong)CKM.CKM_RSA_PKCS_KEY_PAIR_GEN, new EnumMember() { Name = "CKM_RSA_PKCS_KEY_PAIR_GEN", Value = (ulong)CKM.CKM_RSA_PKCS_KEY_PAIR_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RSA_PKCS, new EnumMember() { Name = "CKM_RSA_PKCS", Value = (ulong)CKM.CKM_RSA_PKCS, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RSA_9796, new EnumMember() { Name = "CKM_RSA_9796", Value = (ulong)CKM.CKM_RSA_9796, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RSA_X_509, new EnumMember() { Name = "CKM_RSA_X_509", Value = (ulong)CKM.CKM_RSA_X_509, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_MD2_RSA_PKCS, new EnumMember() { Name = "CKM_MD2_RSA_PKCS", Value = (ulong)CKM.CKM_MD2_RSA_PKCS, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_MD5_RSA_PKCS, new EnumMember() { Name = "CKM_MD5_RSA_PKCS", Value = (ulong)CKM.CKM_MD5_RSA_PKCS, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA1_RSA_PKCS, new EnumMember() { Name = "CKM_SHA1_RSA_PKCS", Value = (ulong)CKM.CKM_SHA1_RSA_PKCS, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RIPEMD128_RSA_PKCS, new EnumMember() { Name = "CKM_RIPEMD128_RSA_PKCS", Value = (ulong)CKM.CKM_RIPEMD128_RSA_PKCS, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RIPEMD160_RSA_PKCS, new EnumMember() { Name = "CKM_RIPEMD160_RSA_PKCS", Value = (ulong)CKM.CKM_RIPEMD160_RSA_PKCS, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RSA_PKCS_OAEP, new EnumMember() { Name = "CKM_RSA_PKCS_OAEP", Value = (ulong)CKM.CKM_RSA_PKCS_OAEP, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RSA_X9_31_KEY_PAIR_GEN, new EnumMember() { Name = "CKM_RSA_X9_31_KEY_PAIR_GEN", Value = (ulong)CKM.CKM_RSA_X9_31_KEY_PAIR_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RSA_X9_31, new EnumMember() { Name = "CKM_RSA_X9_31", Value = (ulong)CKM.CKM_RSA_X9_31, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA1_RSA_X9_31, new EnumMember() { Name = "CKM_SHA1_RSA_X9_31", Value = (ulong)CKM.CKM_SHA1_RSA_X9_31, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RSA_PKCS_PSS, new EnumMember() { Name = "CKM_RSA_PKCS_PSS", Value = (ulong)CKM.CKM_RSA_PKCS_PSS, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA1_RSA_PKCS_PSS, new EnumMember() { Name = "CKM_SHA1_RSA_PKCS_PSS", Value = (ulong)CKM.CKM_SHA1_RSA_PKCS_PSS, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DSA_KEY_PAIR_GEN, new EnumMember() { Name = "CKM_DSA_KEY_PAIR_GEN", Value = (ulong)CKM.CKM_DSA_KEY_PAIR_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DSA, new EnumMember() { Name = "CKM_DSA", Value = (ulong)CKM.CKM_DSA, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DSA_SHA1, new EnumMember() { Name = "CKM_DSA_SHA1", Value = (ulong)CKM.CKM_DSA_SHA1, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DH_PKCS_KEY_PAIR_GEN, new EnumMember() { Name = "CKM_DH_PKCS_KEY_PAIR_GEN", Value = (ulong)CKM.CKM_DH_PKCS_KEY_PAIR_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DH_PKCS_DERIVE, new EnumMember() { Name = "CKM_DH_PKCS_DERIVE", Value = (ulong)CKM.CKM_DH_PKCS_DERIVE, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_X9_42_DH_KEY_PAIR_GEN, new EnumMember() { Name = "CKM_X9_42_DH_KEY_PAIR_GEN", Value = (ulong)CKM.CKM_X9_42_DH_KEY_PAIR_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_X9_42_DH_DERIVE, new EnumMember() { Name = "CKM_X9_42_DH_DERIVE", Value = (ulong)CKM.CKM_X9_42_DH_DERIVE, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_X9_42_DH_HYBRID_DERIVE, new EnumMember() { Name = "CKM_X9_42_DH_HYBRID_DERIVE", Value = (ulong)CKM.CKM_X9_42_DH_HYBRID_DERIVE, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_X9_42_MQV_DERIVE, new EnumMember() { Name = "CKM_X9_42_MQV_DERIVE", Value = (ulong)CKM.CKM_X9_42_MQV_DERIVE, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA256_RSA_PKCS, new EnumMember() { Name = "CKM_SHA256_RSA_PKCS", Value = (ulong)CKM.CKM_SHA256_RSA_PKCS, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA384_RSA_PKCS, new EnumMember() { Name = "CKM_SHA384_RSA_PKCS", Value = (ulong)CKM.CKM_SHA384_RSA_PKCS, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA512_RSA_PKCS, new EnumMember() { Name = "CKM_SHA512_RSA_PKCS", Value = (ulong)CKM.CKM_SHA512_RSA_PKCS, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA256_RSA_PKCS_PSS, new EnumMember() { Name = "CKM_SHA256_RSA_PKCS_PSS", Value = (ulong)CKM.CKM_SHA256_RSA_PKCS_PSS, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA384_RSA_PKCS_PSS, new EnumMember() { Name = "CKM_SHA384_RSA_PKCS_PSS", Value = (ulong)CKM.CKM_SHA384_RSA_PKCS_PSS, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA512_RSA_PKCS_PSS, new EnumMember() { Name = "CKM_SHA512_RSA_PKCS_PSS", Value = (ulong)CKM.CKM_SHA512_RSA_PKCS_PSS, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA224_RSA_PKCS, new EnumMember() { Name = "CKM_SHA224_RSA_PKCS", Value = (ulong)CKM.CKM_SHA224_RSA_PKCS, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA224_RSA_PKCS_PSS, new EnumMember() { Name = "CKM_SHA224_RSA_PKCS_PSS", Value = (ulong)CKM.CKM_SHA224_RSA_PKCS_PSS, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RC2_KEY_GEN, new EnumMember() { Name = "CKM_RC2_KEY_GEN", Value = (ulong)CKM.CKM_RC2_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RC2_ECB, new EnumMember() { Name = "CKM_RC2_ECB", Value = (ulong)CKM.CKM_RC2_ECB, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RC2_CBC, new EnumMember() { Name = "CKM_RC2_CBC", Value = (ulong)CKM.CKM_RC2_CBC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RC2_MAC, new EnumMember() { Name = "CKM_RC2_MAC", Value = (ulong)CKM.CKM_RC2_MAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RC2_MAC_GENERAL, new EnumMember() { Name = "CKM_RC2_MAC_GENERAL", Value = (ulong)CKM.CKM_RC2_MAC_GENERAL, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RC2_CBC_PAD, new EnumMember() { Name = "CKM_RC2_CBC_PAD", Value = (ulong)CKM.CKM_RC2_CBC_PAD, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RC4_KEY_GEN, new EnumMember() { Name = "CKM_RC4_KEY_GEN", Value = (ulong)CKM.CKM_RC4_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RC4, new EnumMember() { Name = "CKM_RC4", Value = (ulong)CKM.CKM_RC4, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DES_KEY_GEN, new EnumMember() { Name = "CKM_DES_KEY_GEN", Value = (ulong)CKM.CKM_DES_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DES_ECB, new EnumMember() { Name = "CKM_DES_ECB", Value = (ulong)CKM.CKM_DES_ECB, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DES_CBC, new EnumMember() { Name = "CKM_DES_CBC", Value = (ulong)CKM.CKM_DES_CBC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DES_MAC, new EnumMember() { Name = "CKM_DES_MAC", Value = (ulong)CKM.CKM_DES_MAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DES_MAC_GENERAL, new EnumMember() { Name = "CKM_DES_MAC_GENERAL", Value = (ulong)CKM.CKM_DES_MAC_GENERAL, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DES_CBC_PAD, new EnumMember() { Name = "CKM_DES_CBC_PAD", Value = (ulong)CKM.CKM_DES_CBC_PAD, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DES2_KEY_GEN, new EnumMember() { Name = "CKM_DES2_KEY_GEN", Value = (ulong)CKM.CKM_DES2_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DES3_KEY_GEN, new EnumMember() { Name = "CKM_DES3_KEY_GEN", Value = (ulong)CKM.CKM_DES3_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DES3_ECB, new EnumMember() { Name = "CKM_DES3_ECB", Value = (ulong)CKM.CKM_DES3_ECB, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DES3_CBC, new EnumMember() { Name = "CKM_DES3_CBC", Value = (ulong)CKM.CKM_DES3_CBC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DES3_MAC, new EnumMember() { Name = "CKM_DES3_MAC", Value = (ulong)CKM.CKM_DES3_MAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DES3_MAC_GENERAL, new EnumMember() { Name = "CKM_DES3_MAC_GENERAL", Value = (ulong)CKM.CKM_DES3_MAC_GENERAL, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DES3_CBC_PAD, new EnumMember() { Name = "CKM_DES3_CBC_PAD", Value = (ulong)CKM.CKM_DES3_CBC_PAD, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CDMF_KEY_GEN, new EnumMember() { Name = "CKM_CDMF_KEY_GEN", Value = (ulong)CKM.CKM_CDMF_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CDMF_ECB, new EnumMember() { Name = "CKM_CDMF_ECB", Value = (ulong)CKM.CKM_CDMF_ECB, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CDMF_CBC, new EnumMember() { Name = "CKM_CDMF_CBC", Value = (ulong)CKM.CKM_CDMF_CBC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CDMF_MAC, new EnumMember() { Name = "CKM_CDMF_MAC", Value = (ulong)CKM.CKM_CDMF_MAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CDMF_MAC_GENERAL, new EnumMember() { Name = "CKM_CDMF_MAC_GENERAL", Value = (ulong)CKM.CKM_CDMF_MAC_GENERAL, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CDMF_CBC_PAD, new EnumMember() { Name = "CKM_CDMF_CBC_PAD", Value = (ulong)CKM.CKM_CDMF_CBC_PAD, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DES_OFB64, new EnumMember() { Name = "CKM_DES_OFB64", Value = (ulong)CKM.CKM_DES_OFB64, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DES_OFB8, new EnumMember() { Name = "CKM_DES_OFB8", Value = (ulong)CKM.CKM_DES_OFB8, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DES_CFB64, new EnumMember() { Name = "CKM_DES_CFB64", Value = (ulong)CKM.CKM_DES_CFB64, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DES_CFB8, new EnumMember() { Name = "CKM_DES_CFB8", Value = (ulong)CKM.CKM_DES_CFB8, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_MD2, new EnumMember() { Name = "CKM_MD2", Value = (ulong)CKM.CKM_MD2, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_MD2_HMAC, new EnumMember() { Name = "CKM_MD2_HMAC", Value = (ulong)CKM.CKM_MD2_HMAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_MD2_HMAC_GENERAL, new EnumMember() { Name = "CKM_MD2_HMAC_GENERAL", Value = (ulong)CKM.CKM_MD2_HMAC_GENERAL, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_MD5, new EnumMember() { Name = "CKM_MD5", Value = (ulong)CKM.CKM_MD5, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_MD5_HMAC, new EnumMember() { Name = "CKM_MD5_HMAC", Value = (ulong)CKM.CKM_MD5_HMAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_MD5_HMAC_GENERAL, new EnumMember() { Name = "CKM_MD5_HMAC_GENERAL", Value = (ulong)CKM.CKM_MD5_HMAC_GENERAL, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA_1, new EnumMember() { Name = "CKM_SHA_1", Value = (ulong)CKM.CKM_SHA_1, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA_1_HMAC, new EnumMember() { Name = "CKM_SHA_1_HMAC", Value = (ulong)CKM.CKM_SHA_1_HMAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA_1_HMAC_GENERAL, new EnumMember() { Name = "CKM_SHA_1_HMAC_GENERAL", Value = (ulong)CKM.CKM_SHA_1_HMAC_GENERAL, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RIPEMD128, new EnumMember() { Name = "CKM_RIPEMD128", Value = (ulong)CKM.CKM_RIPEMD128, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RIPEMD128_HMAC, new EnumMember() { Name = "CKM_RIPEMD128_HMAC", Value = (ulong)CKM.CKM_RIPEMD128_HMAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RIPEMD128_HMAC_GENERAL, new EnumMember() { Name = "CKM_RIPEMD128_HMAC_GENERAL", Value = (ulong)CKM.CKM_RIPEMD128_HMAC_GENERAL, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RIPEMD160, new EnumMember() { Name = "CKM_RIPEMD160", Value = (ulong)CKM.CKM_RIPEMD160, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RIPEMD160_HMAC, new EnumMember() { Name = "CKM_RIPEMD160_HMAC", Value = (ulong)CKM.CKM_RIPEMD160_HMAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RIPEMD160_HMAC_GENERAL, new EnumMember() { Name = "CKM_RIPEMD160_HMAC_GENERAL", Value = (ulong)CKM.CKM_RIPEMD160_HMAC_GENERAL, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA256, new EnumMember() { Name = "CKM_SHA256", Value = (ulong)CKM.CKM_SHA256, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA256_HMAC, new EnumMember() { Name = "CKM_SHA256_HMAC", Value = (ulong)CKM.CKM_SHA256_HMAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA256_HMAC_GENERAL, new EnumMember() { Name = "CKM_SHA256_HMAC_GENERAL", Value = (ulong)CKM.CKM_SHA256_HMAC_GENERAL, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA224, new EnumMember() { Name = "CKM_SHA224", Value = (ulong)CKM.CKM_SHA224, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA224_HMAC, new EnumMember() { Name = "CKM_SHA224_HMAC", Value = (ulong)CKM.CKM_SHA224_HMAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA224_HMAC_GENERAL, new EnumMember() { Name = "CKM_SHA224_HMAC_GENERAL", Value = (ulong)CKM.CKM_SHA224_HMAC_GENERAL, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA384, new EnumMember() { Name = "CKM_SHA384", Value = (ulong)CKM.CKM_SHA384, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA384_HMAC, new EnumMember() { Name = "CKM_SHA384_HMAC", Value = (ulong)CKM.CKM_SHA384_HMAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA384_HMAC_GENERAL, new EnumMember() { Name = "CKM_SHA384_HMAC_GENERAL", Value = (ulong)CKM.CKM_SHA384_HMAC_GENERAL, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA512, new EnumMember() { Name = "CKM_SHA512", Value = (ulong)CKM.CKM_SHA512, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA512_HMAC, new EnumMember() { Name = "CKM_SHA512_HMAC", Value = (ulong)CKM.CKM_SHA512_HMAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA512_HMAC_GENERAL, new EnumMember() { Name = "CKM_SHA512_HMAC_GENERAL", Value = (ulong)CKM.CKM_SHA512_HMAC_GENERAL, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SECURID_KEY_GEN, new EnumMember() { Name = "CKM_SECURID_KEY_GEN", Value = (ulong)CKM.CKM_SECURID_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SECURID, new EnumMember() { Name = "CKM_SECURID", Value = (ulong)CKM.CKM_SECURID, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_HOTP_KEY_GEN, new EnumMember() { Name = "CKM_HOTP_KEY_GEN", Value = (ulong)CKM.CKM_HOTP_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_HOTP, new EnumMember() { Name = "CKM_HOTP", Value = (ulong)CKM.CKM_HOTP, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_ACTI, new EnumMember() { Name = "CKM_ACTI", Value = (ulong)CKM.CKM_ACTI, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_ACTI_KEY_GEN, new EnumMember() { Name = "CKM_ACTI_KEY_GEN", Value = (ulong)CKM.CKM_ACTI_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CAST_KEY_GEN, new EnumMember() { Name = "CKM_CAST_KEY_GEN", Value = (ulong)CKM.CKM_CAST_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CAST_ECB, new EnumMember() { Name = "CKM_CAST_ECB", Value = (ulong)CKM.CKM_CAST_ECB, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CAST_CBC, new EnumMember() { Name = "CKM_CAST_CBC", Value = (ulong)CKM.CKM_CAST_CBC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CAST_MAC, new EnumMember() { Name = "CKM_CAST_MAC", Value = (ulong)CKM.CKM_CAST_MAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CAST_MAC_GENERAL, new EnumMember() { Name = "CKM_CAST_MAC_GENERAL", Value = (ulong)CKM.CKM_CAST_MAC_GENERAL, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CAST_CBC_PAD, new EnumMember() { Name = "CKM_CAST_CBC_PAD", Value = (ulong)CKM.CKM_CAST_CBC_PAD, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CAST3_KEY_GEN, new EnumMember() { Name = "CKM_CAST3_KEY_GEN", Value = (ulong)CKM.CKM_CAST3_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CAST3_ECB, new EnumMember() { Name = "CKM_CAST3_ECB", Value = (ulong)CKM.CKM_CAST3_ECB, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CAST3_CBC, new EnumMember() { Name = "CKM_CAST3_CBC", Value = (ulong)CKM.CKM_CAST3_CBC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CAST3_MAC, new EnumMember() { Name = "CKM_CAST3_MAC", Value = (ulong)CKM.CKM_CAST3_MAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CAST3_MAC_GENERAL, new EnumMember() { Name = "CKM_CAST3_MAC_GENERAL", Value = (ulong)CKM.CKM_CAST3_MAC_GENERAL, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CAST3_CBC_PAD, new EnumMember() { Name = "CKM_CAST3_CBC_PAD", Value = (ulong)CKM.CKM_CAST3_CBC_PAD, FriendlyName = "", Description = "TODO" });
            // Note: CKM_CAST5_KEY_GEN is deprecated in v2.11, CKM_CAST128_KEY_GEN is preferred.
            ckmEnum.Add((ulong)CKM.CKM_CAST128_KEY_GEN, new EnumMember() { Name = "CKM_CAST128_KEY_GEN", Value = (ulong)CKM.CKM_CAST128_KEY_GEN, FriendlyName = "", Description = "TODO" });
            // Note: CKM_CAST5_ECB is deprecated in v2.11, CKM_CAST128_ECB is preferred.
            ckmEnum.Add((ulong)CKM.CKM_CAST128_ECB, new EnumMember() { Name = "CKM_CAST128_ECB", Value = (ulong)CKM.CKM_CAST128_ECB, FriendlyName = "", Description = "TODO" });
            // Note: CKM_CAST5_CBC is deprecated in v2.11, CKM_CAST128_CBC is preferred.
            ckmEnum.Add((ulong)CKM.CKM_CAST128_CBC, new EnumMember() { Name = "CKM_CAST128_CBC", Value = (ulong)CKM.CKM_CAST128_CBC, FriendlyName = "", Description = "TODO" });
            // Note: CKM_CAST5_MAC is deprecated in v2.11, CKM_CAST128_MAC is preferred.
            ckmEnum.Add((ulong)CKM.CKM_CAST128_MAC, new EnumMember() { Name = "CKM_CAST128_MAC", Value = (ulong)CKM.CKM_CAST128_MAC, FriendlyName = "", Description = "TODO" });
            // Note: CKM_CAST5_MAC_GENERAL is deprecated in v2.11, CKM_CAST128_MAC_GENERAL is preferred.
            ckmEnum.Add((ulong)CKM.CKM_CAST128_MAC_GENERAL, new EnumMember() { Name = "CKM_CAST128_MAC_GENERAL", Value = (ulong)CKM.CKM_CAST128_MAC_GENERAL, FriendlyName = "", Description = "TODO" });
            // Note: CKM_CAST5_CBC_PAD is deprecated in v2.11, CKM_CAST128_CBC_PAD is preferred.
            ckmEnum.Add((ulong)CKM.CKM_CAST128_CBC_PAD, new EnumMember() { Name = "CKM_CAST128_CBC_PAD", Value = (ulong)CKM.CKM_CAST128_CBC_PAD, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RC5_KEY_GEN, new EnumMember() { Name = "CKM_RC5_KEY_GEN", Value = (ulong)CKM.CKM_RC5_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RC5_ECB, new EnumMember() { Name = "CKM_RC5_ECB", Value = (ulong)CKM.CKM_RC5_ECB, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RC5_CBC, new EnumMember() { Name = "CKM_RC5_CBC", Value = (ulong)CKM.CKM_RC5_CBC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RC5_MAC, new EnumMember() { Name = "CKM_RC5_MAC", Value = (ulong)CKM.CKM_RC5_MAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RC5_MAC_GENERAL, new EnumMember() { Name = "CKM_RC5_MAC_GENERAL", Value = (ulong)CKM.CKM_RC5_MAC_GENERAL, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_RC5_CBC_PAD, new EnumMember() { Name = "CKM_RC5_CBC_PAD", Value = (ulong)CKM.CKM_RC5_CBC_PAD, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_IDEA_KEY_GEN, new EnumMember() { Name = "CKM_IDEA_KEY_GEN", Value = (ulong)CKM.CKM_IDEA_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_IDEA_ECB, new EnumMember() { Name = "CKM_IDEA_ECB", Value = (ulong)CKM.CKM_IDEA_ECB, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_IDEA_CBC, new EnumMember() { Name = "CKM_IDEA_CBC", Value = (ulong)CKM.CKM_IDEA_CBC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_IDEA_MAC, new EnumMember() { Name = "CKM_IDEA_MAC", Value = (ulong)CKM.CKM_IDEA_MAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_IDEA_MAC_GENERAL, new EnumMember() { Name = "CKM_IDEA_MAC_GENERAL", Value = (ulong)CKM.CKM_IDEA_MAC_GENERAL, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_IDEA_CBC_PAD, new EnumMember() { Name = "CKM_IDEA_CBC_PAD", Value = (ulong)CKM.CKM_IDEA_CBC_PAD, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_GENERIC_SECRET_KEY_GEN, new EnumMember() { Name = "CKM_GENERIC_SECRET_KEY_GEN", Value = (ulong)CKM.CKM_GENERIC_SECRET_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CONCATENATE_BASE_AND_KEY, new EnumMember() { Name = "CKM_CONCATENATE_BASE_AND_KEY", Value = (ulong)CKM.CKM_CONCATENATE_BASE_AND_KEY, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CONCATENATE_BASE_AND_DATA, new EnumMember() { Name = "CKM_CONCATENATE_BASE_AND_DATA", Value = (ulong)CKM.CKM_CONCATENATE_BASE_AND_DATA, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CONCATENATE_DATA_AND_BASE, new EnumMember() { Name = "CKM_CONCATENATE_DATA_AND_BASE", Value = (ulong)CKM.CKM_CONCATENATE_DATA_AND_BASE, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_XOR_BASE_AND_DATA, new EnumMember() { Name = "CKM_XOR_BASE_AND_DATA", Value = (ulong)CKM.CKM_XOR_BASE_AND_DATA, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_EXTRACT_KEY_FROM_KEY, new EnumMember() { Name = "CKM_EXTRACT_KEY_FROM_KEY", Value = (ulong)CKM.CKM_EXTRACT_KEY_FROM_KEY, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SSL3_PRE_MASTER_KEY_GEN, new EnumMember() { Name = "CKM_SSL3_PRE_MASTER_KEY_GEN", Value = (ulong)CKM.CKM_SSL3_PRE_MASTER_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SSL3_MASTER_KEY_DERIVE, new EnumMember() { Name = "CKM_SSL3_MASTER_KEY_DERIVE", Value = (ulong)CKM.CKM_SSL3_MASTER_KEY_DERIVE, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SSL3_KEY_AND_MAC_DERIVE, new EnumMember() { Name = "CKM_SSL3_KEY_AND_MAC_DERIVE", Value = (ulong)CKM.CKM_SSL3_KEY_AND_MAC_DERIVE, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SSL3_MASTER_KEY_DERIVE_DH, new EnumMember() { Name = "CKM_SSL3_MASTER_KEY_DERIVE_DH", Value = (ulong)CKM.CKM_SSL3_MASTER_KEY_DERIVE_DH, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_TLS_PRE_MASTER_KEY_GEN, new EnumMember() { Name = "CKM_TLS_PRE_MASTER_KEY_GEN", Value = (ulong)CKM.CKM_TLS_PRE_MASTER_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_TLS_MASTER_KEY_DERIVE, new EnumMember() { Name = "CKM_TLS_MASTER_KEY_DERIVE", Value = (ulong)CKM.CKM_TLS_MASTER_KEY_DERIVE, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_TLS_KEY_AND_MAC_DERIVE, new EnumMember() { Name = "CKM_TLS_KEY_AND_MAC_DERIVE", Value = (ulong)CKM.CKM_TLS_KEY_AND_MAC_DERIVE, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_TLS_MASTER_KEY_DERIVE_DH, new EnumMember() { Name = "CKM_TLS_MASTER_KEY_DERIVE_DH", Value = (ulong)CKM.CKM_TLS_MASTER_KEY_DERIVE_DH, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_TLS_PRF, new EnumMember() { Name = "CKM_TLS_PRF", Value = (ulong)CKM.CKM_TLS_PRF, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SSL3_MD5_MAC, new EnumMember() { Name = "CKM_SSL3_MD5_MAC", Value = (ulong)CKM.CKM_SSL3_MD5_MAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SSL3_SHA1_MAC, new EnumMember() { Name = "CKM_SSL3_SHA1_MAC", Value = (ulong)CKM.CKM_SSL3_SHA1_MAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_MD5_KEY_DERIVATION, new EnumMember() { Name = "CKM_MD5_KEY_DERIVATION", Value = (ulong)CKM.CKM_MD5_KEY_DERIVATION, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_MD2_KEY_DERIVATION, new EnumMember() { Name = "CKM_MD2_KEY_DERIVATION", Value = (ulong)CKM.CKM_MD2_KEY_DERIVATION, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA1_KEY_DERIVATION, new EnumMember() { Name = "CKM_SHA1_KEY_DERIVATION", Value = (ulong)CKM.CKM_SHA1_KEY_DERIVATION, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA256_KEY_DERIVATION, new EnumMember() { Name = "CKM_SHA256_KEY_DERIVATION", Value = (ulong)CKM.CKM_SHA256_KEY_DERIVATION, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA384_KEY_DERIVATION, new EnumMember() { Name = "CKM_SHA384_KEY_DERIVATION", Value = (ulong)CKM.CKM_SHA384_KEY_DERIVATION, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA512_KEY_DERIVATION, new EnumMember() { Name = "CKM_SHA512_KEY_DERIVATION", Value = (ulong)CKM.CKM_SHA512_KEY_DERIVATION, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SHA224_KEY_DERIVATION, new EnumMember() { Name = "CKM_SHA224_KEY_DERIVATION", Value = (ulong)CKM.CKM_SHA224_KEY_DERIVATION, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_PBE_MD2_DES_CBC, new EnumMember() { Name = "CKM_PBE_MD2_DES_CBC", Value = (ulong)CKM.CKM_PBE_MD2_DES_CBC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_PBE_MD5_DES_CBC, new EnumMember() { Name = "CKM_PBE_MD5_DES_CBC", Value = (ulong)CKM.CKM_PBE_MD5_DES_CBC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_PBE_MD5_CAST_CBC, new EnumMember() { Name = "CKM_PBE_MD5_CAST_CBC", Value = (ulong)CKM.CKM_PBE_MD5_CAST_CBC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_PBE_MD5_CAST3_CBC, new EnumMember() { Name = "CKM_PBE_MD5_CAST3_CBC", Value = (ulong)CKM.CKM_PBE_MD5_CAST3_CBC, FriendlyName = "", Description = "TODO" });
            // Note: CKM_PBE_MD5_CAST5_CBC is deprecated in v2.11, CKM_PBE_MD5_CAST128_CBC is preferred.
            ckmEnum.Add((ulong)CKM.CKM_PBE_MD5_CAST128_CBC, new EnumMember() { Name = "CKM_PBE_MD5_CAST128_CBC", Value = (ulong)CKM.CKM_PBE_MD5_CAST128_CBC, FriendlyName = "", Description = "TODO" });
            // Note: CKM_PBE_SHA1_CAST5_CBC is deprecated in v2.11, CKM_PBE_SHA1_CAST128_CBC is preferred.
            ckmEnum.Add((ulong)CKM.CKM_PBE_SHA1_CAST128_CBC, new EnumMember() { Name = "CKM_PBE_SHA1_CAST128_CBC", Value = (ulong)CKM.CKM_PBE_SHA1_CAST128_CBC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_PBE_SHA1_RC4_128, new EnumMember() { Name = "CKM_PBE_SHA1_RC4_128", Value = (ulong)CKM.CKM_PBE_SHA1_RC4_128, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_PBE_SHA1_RC4_40, new EnumMember() { Name = "CKM_PBE_SHA1_RC4_40", Value = (ulong)CKM.CKM_PBE_SHA1_RC4_40, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_PBE_SHA1_DES3_EDE_CBC, new EnumMember() { Name = "CKM_PBE_SHA1_DES3_EDE_CBC", Value = (ulong)CKM.CKM_PBE_SHA1_DES3_EDE_CBC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_PBE_SHA1_DES2_EDE_CBC, new EnumMember() { Name = "CKM_PBE_SHA1_DES2_EDE_CBC", Value = (ulong)CKM.CKM_PBE_SHA1_DES2_EDE_CBC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_PBE_SHA1_RC2_128_CBC, new EnumMember() { Name = "CKM_PBE_SHA1_RC2_128_CBC", Value = (ulong)CKM.CKM_PBE_SHA1_RC2_128_CBC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_PBE_SHA1_RC2_40_CBC, new EnumMember() { Name = "CKM_PBE_SHA1_RC2_40_CBC", Value = (ulong)CKM.CKM_PBE_SHA1_RC2_40_CBC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_PKCS5_PBKD2, new EnumMember() { Name = "CKM_PKCS5_PBKD2", Value = (ulong)CKM.CKM_PKCS5_PBKD2, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_PBA_SHA1_WITH_SHA1_HMAC, new EnumMember() { Name = "CKM_PBA_SHA1_WITH_SHA1_HMAC", Value = (ulong)CKM.CKM_PBA_SHA1_WITH_SHA1_HMAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_WTLS_PRE_MASTER_KEY_GEN, new EnumMember() { Name = "CKM_WTLS_PRE_MASTER_KEY_GEN", Value = (ulong)CKM.CKM_WTLS_PRE_MASTER_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_WTLS_MASTER_KEY_DERIVE, new EnumMember() { Name = "CKM_WTLS_MASTER_KEY_DERIVE", Value = (ulong)CKM.CKM_WTLS_MASTER_KEY_DERIVE, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_WTLS_MASTER_KEY_DERIVE_DH_ECC, new EnumMember() { Name = "CKM_WTLS_MASTER_KEY_DERIVE_DH_ECC", Value = (ulong)CKM.CKM_WTLS_MASTER_KEY_DERIVE_DH_ECC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_WTLS_PRF, new EnumMember() { Name = "CKM_WTLS_PRF", Value = (ulong)CKM.CKM_WTLS_PRF, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_WTLS_SERVER_KEY_AND_MAC_DERIVE, new EnumMember() { Name = "CKM_WTLS_SERVER_KEY_AND_MAC_DERIVE", Value = (ulong)CKM.CKM_WTLS_SERVER_KEY_AND_MAC_DERIVE, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_WTLS_CLIENT_KEY_AND_MAC_DERIVE, new EnumMember() { Name = "CKM_WTLS_CLIENT_KEY_AND_MAC_DERIVE", Value = (ulong)CKM.CKM_WTLS_CLIENT_KEY_AND_MAC_DERIVE, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_KEY_WRAP_LYNKS, new EnumMember() { Name = "CKM_KEY_WRAP_LYNKS", Value = (ulong)CKM.CKM_KEY_WRAP_LYNKS, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_KEY_WRAP_SET_OAEP, new EnumMember() { Name = "CKM_KEY_WRAP_SET_OAEP", Value = (ulong)CKM.CKM_KEY_WRAP_SET_OAEP, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CMS_SIG, new EnumMember() { Name = "CKM_CMS_SIG", Value = (ulong)CKM.CKM_CMS_SIG, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_KIP_DERIVE, new EnumMember() { Name = "CKM_KIP_DERIVE", Value = (ulong)CKM.CKM_KIP_DERIVE, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_KIP_WRAP, new EnumMember() { Name = "CKM_KIP_WRAP", Value = (ulong)CKM.CKM_KIP_WRAP, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_KIP_MAC, new EnumMember() { Name = "CKM_KIP_MAC", Value = (ulong)CKM.CKM_KIP_MAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CAMELLIA_KEY_GEN, new EnumMember() { Name = "CKM_CAMELLIA_KEY_GEN", Value = (ulong)CKM.CKM_CAMELLIA_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CAMELLIA_ECB, new EnumMember() { Name = "CKM_CAMELLIA_ECB", Value = (ulong)CKM.CKM_CAMELLIA_ECB, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CAMELLIA_CBC, new EnumMember() { Name = "CKM_CAMELLIA_CBC", Value = (ulong)CKM.CKM_CAMELLIA_CBC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CAMELLIA_MAC, new EnumMember() { Name = "CKM_CAMELLIA_MAC", Value = (ulong)CKM.CKM_CAMELLIA_MAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CAMELLIA_MAC_GENERAL, new EnumMember() { Name = "CKM_CAMELLIA_MAC_GENERAL", Value = (ulong)CKM.CKM_CAMELLIA_MAC_GENERAL, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CAMELLIA_CBC_PAD, new EnumMember() { Name = "CKM_CAMELLIA_CBC_PAD", Value = (ulong)CKM.CKM_CAMELLIA_CBC_PAD, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CAMELLIA_ECB_ENCRYPT_DATA, new EnumMember() { Name = "CKM_CAMELLIA_ECB_ENCRYPT_DATA", Value = (ulong)CKM.CKM_CAMELLIA_ECB_ENCRYPT_DATA, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CAMELLIA_CBC_ENCRYPT_DATA, new EnumMember() { Name = "CKM_CAMELLIA_CBC_ENCRYPT_DATA", Value = (ulong)CKM.CKM_CAMELLIA_CBC_ENCRYPT_DATA, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_CAMELLIA_CTR, new EnumMember() { Name = "CKM_CAMELLIA_CTR", Value = (ulong)CKM.CKM_CAMELLIA_CTR, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_ARIA_KEY_GEN, new EnumMember() { Name = "CKM_ARIA_KEY_GEN", Value = (ulong)CKM.CKM_ARIA_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_ARIA_ECB, new EnumMember() { Name = "CKM_ARIA_ECB", Value = (ulong)CKM.CKM_ARIA_ECB, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_ARIA_CBC, new EnumMember() { Name = "CKM_ARIA_CBC", Value = (ulong)CKM.CKM_ARIA_CBC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_ARIA_MAC, new EnumMember() { Name = "CKM_ARIA_MAC", Value = (ulong)CKM.CKM_ARIA_MAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_ARIA_MAC_GENERAL, new EnumMember() { Name = "CKM_ARIA_MAC_GENERAL", Value = (ulong)CKM.CKM_ARIA_MAC_GENERAL, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_ARIA_CBC_PAD, new EnumMember() { Name = "CKM_ARIA_CBC_PAD", Value = (ulong)CKM.CKM_ARIA_CBC_PAD, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_ARIA_ECB_ENCRYPT_DATA, new EnumMember() { Name = "CKM_ARIA_ECB_ENCRYPT_DATA", Value = (ulong)CKM.CKM_ARIA_ECB_ENCRYPT_DATA, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_ARIA_CBC_ENCRYPT_DATA, new EnumMember() { Name = "CKM_ARIA_CBC_ENCRYPT_DATA", Value = (ulong)CKM.CKM_ARIA_CBC_ENCRYPT_DATA, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SKIPJACK_KEY_GEN, new EnumMember() { Name = "CKM_SKIPJACK_KEY_GEN", Value = (ulong)CKM.CKM_SKIPJACK_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SKIPJACK_ECB64, new EnumMember() { Name = "CKM_SKIPJACK_ECB64", Value = (ulong)CKM.CKM_SKIPJACK_ECB64, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SKIPJACK_CBC64, new EnumMember() { Name = "CKM_SKIPJACK_CBC64", Value = (ulong)CKM.CKM_SKIPJACK_CBC64, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SKIPJACK_OFB64, new EnumMember() { Name = "CKM_SKIPJACK_OFB64", Value = (ulong)CKM.CKM_SKIPJACK_OFB64, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SKIPJACK_CFB64, new EnumMember() { Name = "CKM_SKIPJACK_CFB64", Value = (ulong)CKM.CKM_SKIPJACK_CFB64, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SKIPJACK_CFB32, new EnumMember() { Name = "CKM_SKIPJACK_CFB32", Value = (ulong)CKM.CKM_SKIPJACK_CFB32, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SKIPJACK_CFB16, new EnumMember() { Name = "CKM_SKIPJACK_CFB16", Value = (ulong)CKM.CKM_SKIPJACK_CFB16, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SKIPJACK_CFB8, new EnumMember() { Name = "CKM_SKIPJACK_CFB8", Value = (ulong)CKM.CKM_SKIPJACK_CFB8, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SKIPJACK_WRAP, new EnumMember() { Name = "CKM_SKIPJACK_WRAP", Value = (ulong)CKM.CKM_SKIPJACK_WRAP, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SKIPJACK_PRIVATE_WRAP, new EnumMember() { Name = "CKM_SKIPJACK_PRIVATE_WRAP", Value = (ulong)CKM.CKM_SKIPJACK_PRIVATE_WRAP, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_SKIPJACK_RELAYX, new EnumMember() { Name = "CKM_SKIPJACK_RELAYX", Value = (ulong)CKM.CKM_SKIPJACK_RELAYX, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_KEA_KEY_PAIR_GEN, new EnumMember() { Name = "CKM_KEA_KEY_PAIR_GEN", Value = (ulong)CKM.CKM_KEA_KEY_PAIR_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_KEA_KEY_DERIVE, new EnumMember() { Name = "CKM_KEA_KEY_DERIVE", Value = (ulong)CKM.CKM_KEA_KEY_DERIVE, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_FORTEZZA_TIMESTAMP, new EnumMember() { Name = "CKM_FORTEZZA_TIMESTAMP", Value = (ulong)CKM.CKM_FORTEZZA_TIMESTAMP, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_BATON_KEY_GEN, new EnumMember() { Name = "CKM_BATON_KEY_GEN", Value = (ulong)CKM.CKM_BATON_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_BATON_ECB128, new EnumMember() { Name = "CKM_BATON_ECB128", Value = (ulong)CKM.CKM_BATON_ECB128, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_BATON_ECB96, new EnumMember() { Name = "CKM_BATON_ECB96", Value = (ulong)CKM.CKM_BATON_ECB96, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_BATON_CBC128, new EnumMember() { Name = "CKM_BATON_CBC128", Value = (ulong)CKM.CKM_BATON_CBC128, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_BATON_COUNTER, new EnumMember() { Name = "CKM_BATON_COUNTER", Value = (ulong)CKM.CKM_BATON_COUNTER, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_BATON_SHUFFLE, new EnumMember() { Name = "CKM_BATON_SHUFFLE", Value = (ulong)CKM.CKM_BATON_SHUFFLE, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_BATON_WRAP, new EnumMember() { Name = "CKM_BATON_WRAP", Value = (ulong)CKM.CKM_BATON_WRAP, FriendlyName = "", Description = "TODO" });
            // Note: CKM_ECDSA_KEY_PAIR_GEN is deprecated in v2.11, CKM_EC_KEY_PAIR_GEN is preferred.
            ckmEnum.Add((ulong)CKM.CKM_EC_KEY_PAIR_GEN, new EnumMember() { Name = "CKM_EC_KEY_PAIR_GEN", Value = (ulong)CKM.CKM_EC_KEY_PAIR_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_ECDSA, new EnumMember() { Name = "CKM_ECDSA", Value = (ulong)CKM.CKM_ECDSA, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_ECDSA_SHA1, new EnumMember() { Name = "CKM_ECDSA_SHA1", Value = (ulong)CKM.CKM_ECDSA_SHA1, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_ECDH1_DERIVE, new EnumMember() { Name = "CKM_ECDH1_DERIVE", Value = (ulong)CKM.CKM_ECDH1_DERIVE, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_ECDH1_COFACTOR_DERIVE, new EnumMember() { Name = "CKM_ECDH1_COFACTOR_DERIVE", Value = (ulong)CKM.CKM_ECDH1_COFACTOR_DERIVE, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_ECMQV_DERIVE, new EnumMember() { Name = "CKM_ECMQV_DERIVE", Value = (ulong)CKM.CKM_ECMQV_DERIVE, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_JUNIPER_KEY_GEN, new EnumMember() { Name = "CKM_JUNIPER_KEY_GEN", Value = (ulong)CKM.CKM_JUNIPER_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_JUNIPER_ECB128, new EnumMember() { Name = "CKM_JUNIPER_ECB128", Value = (ulong)CKM.CKM_JUNIPER_ECB128, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_JUNIPER_CBC128, new EnumMember() { Name = "CKM_JUNIPER_CBC128", Value = (ulong)CKM.CKM_JUNIPER_CBC128, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_JUNIPER_COUNTER, new EnumMember() { Name = "CKM_JUNIPER_COUNTER", Value = (ulong)CKM.CKM_JUNIPER_COUNTER, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_JUNIPER_SHUFFLE, new EnumMember() { Name = "CKM_JUNIPER_SHUFFLE", Value = (ulong)CKM.CKM_JUNIPER_SHUFFLE, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_JUNIPER_WRAP, new EnumMember() { Name = "CKM_JUNIPER_WRAP", Value = (ulong)CKM.CKM_JUNIPER_WRAP, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_FASTHASH, new EnumMember() { Name = "CKM_FASTHASH", Value = (ulong)CKM.CKM_FASTHASH, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_AES_KEY_GEN, new EnumMember() { Name = "CKM_AES_KEY_GEN", Value = (ulong)CKM.CKM_AES_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_AES_ECB, new EnumMember() { Name = "CKM_AES_ECB", Value = (ulong)CKM.CKM_AES_ECB, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_AES_CBC, new EnumMember() { Name = "CKM_AES_CBC", Value = (ulong)CKM.CKM_AES_CBC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_AES_MAC, new EnumMember() { Name = "CKM_AES_MAC", Value = (ulong)CKM.CKM_AES_MAC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_AES_MAC_GENERAL, new EnumMember() { Name = "CKM_AES_MAC_GENERAL", Value = (ulong)CKM.CKM_AES_MAC_GENERAL, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_AES_CBC_PAD, new EnumMember() { Name = "CKM_AES_CBC_PAD", Value = (ulong)CKM.CKM_AES_CBC_PAD, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_AES_CTR, new EnumMember() { Name = "CKM_AES_CTR", Value = (ulong)CKM.CKM_AES_CTR, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_BLOWFISH_KEY_GEN, new EnumMember() { Name = "CKM_BLOWFISH_KEY_GEN", Value = (ulong)CKM.CKM_BLOWFISH_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_BLOWFISH_CBC, new EnumMember() { Name = "CKM_BLOWFISH_CBC", Value = (ulong)CKM.CKM_BLOWFISH_CBC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_TWOFISH_KEY_GEN, new EnumMember() { Name = "CKM_TWOFISH_KEY_GEN", Value = (ulong)CKM.CKM_TWOFISH_KEY_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_TWOFISH_CBC, new EnumMember() { Name = "CKM_TWOFISH_CBC", Value = (ulong)CKM.CKM_TWOFISH_CBC, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DES_ECB_ENCRYPT_DATA, new EnumMember() { Name = "CKM_DES_ECB_ENCRYPT_DATA", Value = (ulong)CKM.CKM_DES_ECB_ENCRYPT_DATA, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DES_CBC_ENCRYPT_DATA, new EnumMember() { Name = "CKM_DES_CBC_ENCRYPT_DATA", Value = (ulong)CKM.CKM_DES_CBC_ENCRYPT_DATA, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DES3_ECB_ENCRYPT_DATA, new EnumMember() { Name = "CKM_DES3_ECB_ENCRYPT_DATA", Value = (ulong)CKM.CKM_DES3_ECB_ENCRYPT_DATA, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DES3_CBC_ENCRYPT_DATA, new EnumMember() { Name = "CKM_DES3_CBC_ENCRYPT_DATA", Value = (ulong)CKM.CKM_DES3_CBC_ENCRYPT_DATA, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_AES_ECB_ENCRYPT_DATA, new EnumMember() { Name = "CKM_AES_ECB_ENCRYPT_DATA", Value = (ulong)CKM.CKM_AES_ECB_ENCRYPT_DATA, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_AES_CBC_ENCRYPT_DATA, new EnumMember() { Name = "CKM_AES_CBC_ENCRYPT_DATA", Value = (ulong)CKM.CKM_AES_CBC_ENCRYPT_DATA, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DSA_PARAMETER_GEN, new EnumMember() { Name = "CKM_DSA_PARAMETER_GEN", Value = (ulong)CKM.CKM_DSA_PARAMETER_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_DH_PKCS_PARAMETER_GEN, new EnumMember() { Name = "CKM_DH_PKCS_PARAMETER_GEN", Value = (ulong)CKM.CKM_DH_PKCS_PARAMETER_GEN, FriendlyName = "", Description = "TODO" });
            ckmEnum.Add((ulong)CKM.CKM_X9_42_DH_PARAMETER_GEN, new EnumMember() { Name = "CKM_X9_42_DH_PARAMETER_GEN", Value = (ulong)CKM.CKM_X9_42_DH_PARAMETER_GEN, FriendlyName = "", Description = "TODO" });

            #endregion

            #region CKO

            EnumDefinition ckoEnum = new EnumDefinition();
            ckoEnum.Add((ulong)CKO.CKO_DATA, new EnumMember() { Name = "CKO_DATA", Value = (ulong)CKO.CKO_DATA, FriendlyName = "Data object", Description = "TODO" });
            ckoEnum.Add((ulong)CKO.CKO_CERTIFICATE, new EnumMember() { Name = "CKO_CERTIFICATE", Value = (ulong)CKO.CKO_CERTIFICATE, FriendlyName = "Certificate", Description = "TODO" });
            ckoEnum.Add((ulong)CKO.CKO_PUBLIC_KEY, new EnumMember() { Name = "CKO_PUBLIC_KEY", Value = (ulong)CKO.CKO_PUBLIC_KEY, FriendlyName = "Public key", Description = "TODO" });
            ckoEnum.Add((ulong)CKO.CKO_PRIVATE_KEY, new EnumMember() { Name = "CKO_PRIVATE_KEY", Value = (ulong)CKO.CKO_PRIVATE_KEY, FriendlyName = "Private key", Description = "TODO" });
            ckoEnum.Add((ulong)CKO.CKO_SECRET_KEY, new EnumMember() { Name = "CKO_SECRET_KEY", Value = (ulong)CKO.CKO_SECRET_KEY, FriendlyName = "Secret key", Description = "TODO" });
            ckoEnum.Add((ulong)CKO.CKO_HW_FEATURE, new EnumMember() { Name = "CKO_HW_FEATURE", Value = (ulong)CKO.CKO_HW_FEATURE, FriendlyName = "HW feature", Description = "TODO" });
            ckoEnum.Add((ulong)CKO.CKO_DOMAIN_PARAMETERS, new EnumMember() { Name = "CKO_DOMAIN_PARAMETERS", Value = (ulong)CKO.CKO_DOMAIN_PARAMETERS, FriendlyName = "Domain parameters", Description = "TODO" });
            ckoEnum.Add((ulong)CKO.CKO_MECHANISM, new EnumMember() { Name = "CKO_MECHANISM", Value = (ulong)CKO.CKO_MECHANISM, FriendlyName = "Mechanism", Description = "TODO" });
            ckoEnum.Add((ulong)CKO.CKO_OTP_KEY, new EnumMember() { Name = "CKO_OTP_KEY", Value = (ulong)CKO.CKO_OTP_KEY, FriendlyName = "OTP key", Description = "TODO" });

            #endregion

            #region CKC

            EnumDefinition ckcEnum = new EnumDefinition();
            ckcEnum.Add((ulong)CKC.CKC_X_509, new EnumMember() { Name = "CKC_X_509", Value = (ulong)CKC.CKC_X_509, FriendlyName = "", Description = "TODO" });
            ckcEnum.Add((ulong)CKC.CKC_X_509_ATTR_CERT, new EnumMember() { Name = "CKC_X_509_ATTR_CERT", Value = (ulong)CKC.CKC_X_509_ATTR_CERT, FriendlyName = "", Description = "TODO" });
            ckcEnum.Add((ulong)CKC.CKC_WTLS, new EnumMember() { Name = "CKC_WTLS", Value = (ulong)CKC.CKC_WTLS, FriendlyName = "", Description = "TODO" });

            #endregion

            #region CKK

            EnumDefinition ckkEnum = new EnumDefinition();
            ckkEnum.Add((ulong)CKK.CKK_RSA, new EnumMember() { Name = "CKK_RSA", Value = (ulong)CKK.CKK_RSA, FriendlyName = "RSA", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_DSA, new EnumMember() { Name = "CKK_DSA", Value = (ulong)CKK.CKK_DSA, FriendlyName = "DSA", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_DH, new EnumMember() { Name = "CKK_DH", Value = (ulong)CKK.CKK_DH, FriendlyName = "DH", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_EC, new EnumMember() { Name = "CKK_EC", Value = (ulong)CKK.CKK_EC, FriendlyName = "EC", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_X9_42_DH, new EnumMember() { Name = "CKK_X9_42_DH", Value = (ulong)CKK.CKK_X9_42_DH, FriendlyName = "X9.42 DH", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_KEA, new EnumMember() { Name = "CKK_KEA", Value = (ulong)CKK.CKK_KEA, FriendlyName = "KEA", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_GENERIC_SECRET, new EnumMember() { Name = "CKK_GENERIC_SECRET", Value = (ulong)CKK.CKK_GENERIC_SECRET, FriendlyName = "Generic secret", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_RC2, new EnumMember() { Name = "CKK_RC2", Value = (ulong)CKK.CKK_RC2, FriendlyName = "RC2", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_RC4, new EnumMember() { Name = "CKK_RC4", Value = (ulong)CKK.CKK_RC4, FriendlyName = "RC4", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_DES, new EnumMember() { Name = "CKK_DES", Value = (ulong)CKK.CKK_DES, FriendlyName = "DES", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_DES2, new EnumMember() { Name = "CKK_DES2", Value = (ulong)CKK.CKK_DES2, FriendlyName = "DES2", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_DES3, new EnumMember() { Name = "CKK_DES3", Value = (ulong)CKK.CKK_DES3, FriendlyName = "DES3", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_CAST, new EnumMember() { Name = "CKK_CAST", Value = (ulong)CKK.CKK_CAST, FriendlyName = "CAST", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_CAST3, new EnumMember() { Name = "CKK_CAST3", Value = (ulong)CKK.CKK_CAST3, FriendlyName = "CAST3", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_CAST128, new EnumMember() { Name = "CKK_CAST128", Value = (ulong)CKK.CKK_CAST128, FriendlyName = "CAST128", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_RC5, new EnumMember() { Name = "CKK_RC5", Value = (ulong)CKK.CKK_RC5, FriendlyName = "RC5", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_IDEA, new EnumMember() { Name = "CKK_IDEA", Value = (ulong)CKK.CKK_IDEA, FriendlyName = "IDEA", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_SKIPJACK, new EnumMember() { Name = "CKK_SKIPJACK", Value = (ulong)CKK.CKK_SKIPJACK, FriendlyName = "SKIPJACK", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_BATON, new EnumMember() { Name = "CKK_BATON", Value = (ulong)CKK.CKK_BATON, FriendlyName = "BATON", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_JUNIPER, new EnumMember() { Name = "CKK_JUNIPER", Value = (ulong)CKK.CKK_JUNIPER, FriendlyName = "JUNIPER", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_CDMF, new EnumMember() { Name = "CKK_CDMF", Value = (ulong)CKK.CKK_CDMF, FriendlyName = "CDMF", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_AES, new EnumMember() { Name = "CKK_AES", Value = (ulong)CKK.CKK_AES, FriendlyName = "AES", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_BLOWFISH, new EnumMember() { Name = "CKK_BLOWFISH", Value = (ulong)CKK.CKK_BLOWFISH, FriendlyName = "BLOWFISH", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_TWOFISH, new EnumMember() { Name = "CKK_TWOFISH", Value = (ulong)CKK.CKK_TWOFISH, FriendlyName = "TWOFISH", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_SECURID, new EnumMember() { Name = "CKK_SECURID", Value = (ulong)CKK.CKK_SECURID, FriendlyName = "SecurID", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_HOTP, new EnumMember() { Name = "CKK_HOTP", Value = (ulong)CKK.CKK_HOTP, FriendlyName = "HOTP", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_ACTI, new EnumMember() { Name = "CKK_ACTI", Value = (ulong)CKK.CKK_ACTI, FriendlyName = "ACTI", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_CAMELLIA, new EnumMember() { Name = "CKK_CAMELLIA", Value = (ulong)CKK.CKK_CAMELLIA, FriendlyName = "CAMELLIA", Description = "TODO" });
            ckkEnum.Add((ulong)CKK.CKK_ARIA, new EnumMember() { Name = "CKK_ARIA", Value = (ulong)CKK.CKK_ARIA, FriendlyName = "ARIA", Description = "TODO" });

            #endregion

            #region CKH

            EnumDefinition ckhEnum = new EnumDefinition();
            ckhEnum.Add((ulong)CKH.CKH_MONOTONIC_COUNTER, new EnumMember() { Name = "CKH_MONOTONIC_COUNTER", Value = (ulong)CKH.CKH_MONOTONIC_COUNTER, FriendlyName = "", Description = "TODO" });
            ckhEnum.Add((ulong)CKH.CKH_CLOCK, new EnumMember() { Name = "CKH_CLOCK", Value = (ulong)CKH.CKH_CLOCK, FriendlyName = "", Description = "TODO" });
            ckhEnum.Add((ulong)CKH.CKH_USER_INTERFACE, new EnumMember() { Name = "CKH_USER_INTERFACE", Value = (ulong)CKH.CKH_USER_INTERFACE, FriendlyName = "", Description = "TODO" });

            #endregion

            cfg.EnumDefinitions = new EnumDefinitions();
            cfg.EnumDefinitions.Add("CKM", ckmEnum);
            cfg.EnumDefinitions.Add("CKO", ckoEnum);
            cfg.EnumDefinitions.Add("CKC", ckcEnum);
            cfg.EnumDefinitions.Add("CKK", ckkEnum);
            cfg.EnumDefinitions.Add("CKH", ckhEnum);

            #endregion

            #region ObjectAttributes

            #region Hardware feature attributes

            cfg.HwFeatureAttributes = new ClassAttributesDefinition();
            cfg.HwFeatureAttributes.CommonAttributes = new ClassAttributes();

            cfg.HwFeatureAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_HW_FEATURE_TYPE, CreateDefaultValue = "TODO" });
            // TODO - No label no nothing ???

            cfg.HwFeatureAttributes.TypeSpecificAttributes = new TypeAttributes();

            #endregion

            #region Data object attributes

            cfg.DataObjectAttributes = new ClassAttributesDefinition();
            cfg.DataObjectAttributes.CommonAttributes = new ClassAttributes();
            cfg.DataObjectAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_CLASS, CreateDefaultValue = "ULONG:0", CreateSetByDefault = true });
            cfg.DataObjectAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_TOKEN, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = true });
            cfg.DataObjectAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_PRIVATE, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = true });
            cfg.DataObjectAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_MODIFIABLE, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = true });
            cfg.DataObjectAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_LABEL, CreateDefaultValue = null, CreateSetByDefault = true });
            cfg.DataObjectAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_APPLICATION, CreateDefaultValue = null });
            cfg.DataObjectAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_OBJECT_ID, CreateDefaultValue = null });
            cfg.DataObjectAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_VALUE, CreateDefaultValue = null, CreateSetByDefault = true });

            #endregion

            #region Certificate attributes

            cfg.CertificateAttributes = new ClassAttributesDefinition();
            cfg.CertificateAttributes.CommonAttributes = new ClassAttributes();

            cfg.CertificateAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_CLASS, CreateDefaultValue = "ULONG:1", CreateSetByDefault = true });

            // Common Storage Object Attributes
            cfg.CertificateAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_TOKEN, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = true });
            cfg.CertificateAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_PRIVATE, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = true });
            cfg.CertificateAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_MODIFIABLE, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = true });
            cfg.CertificateAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_LABEL, CreateDefaultValue = null, CreateSetByDefault = true });

            // TODO - Review
            // Common Certificate Object Attributes
            cfg.CertificateAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_CERTIFICATE_TYPE, CreateDefaultValue = "ULONG:0", CreateSetByDefault = true });
            cfg.CertificateAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_TRUSTED, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = false });
            cfg.CertificateAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_CERTIFICATE_CATEGORY, CreateDefaultValue = "ULONG:0" });
            cfg.CertificateAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_CHECK_VALUE, CreateDefaultValue = null });
            cfg.CertificateAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_START_DATE, CreateDefaultValue = null });
            cfg.CertificateAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_END_DATE, CreateDefaultValue = null });

            cfg.CertificateAttributes.TypeSpecificAttributes = new TypeAttributes();

            // TODO - Review
            // X.509 public key certificate objects
            cfg.CertificateAttributes.TypeSpecificAttributes.Add((ulong)CKC.CKC_X_509, new ClassAttributes());
            cfg.CertificateAttributes.TypeSpecificAttributes[(ulong)CKC.CKC_X_509].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_SUBJECT, CreateDefaultValue = null, CreateSetByDefault = true });
            cfg.CertificateAttributes.TypeSpecificAttributes[(ulong)CKC.CKC_X_509].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_ID, CreateDefaultValue = null, CreateSetByDefault = true });
            cfg.CertificateAttributes.TypeSpecificAttributes[(ulong)CKC.CKC_X_509].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_ISSUER, CreateDefaultValue = null, CreateSetByDefault = true });
            cfg.CertificateAttributes.TypeSpecificAttributes[(ulong)CKC.CKC_X_509].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_SERIAL_NUMBER, CreateDefaultValue = null, CreateSetByDefault = true });
            cfg.CertificateAttributes.TypeSpecificAttributes[(ulong)CKC.CKC_X_509].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_VALUE, CreateDefaultValue = null, CreateSetByDefault = true });
            cfg.CertificateAttributes.TypeSpecificAttributes[(ulong)CKC.CKC_X_509].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_URL, CreateDefaultValue = null });
            cfg.CertificateAttributes.TypeSpecificAttributes[(ulong)CKC.CKC_X_509].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_HASH_OF_SUBJECT_PUBLIC_KEY, CreateDefaultValue = null });
            cfg.CertificateAttributes.TypeSpecificAttributes[(ulong)CKC.CKC_X_509].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_HASH_OF_ISSUER_PUBLIC_KEY, CreateDefaultValue = null });
            cfg.CertificateAttributes.TypeSpecificAttributes[(ulong)CKC.CKC_X_509].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_JAVA_MIDP_SECURITY_DOMAIN, CreateDefaultValue = "ULONG:0" });

            // TODO - Review
            // WTLS Certificate Object Attributes
            cfg.CertificateAttributes.TypeSpecificAttributes.Add((ulong)CKC.CKC_WTLS, new ClassAttributes());
            cfg.CertificateAttributes.TypeSpecificAttributes[(ulong)CKC.CKC_WTLS].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_SUBJECT, CreateDefaultValue = null, CreateSetByDefault = true });
            cfg.CertificateAttributes.TypeSpecificAttributes[(ulong)CKC.CKC_WTLS].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_ISSUER, CreateDefaultValue = null, CreateSetByDefault = true });
            cfg.CertificateAttributes.TypeSpecificAttributes[(ulong)CKC.CKC_WTLS].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_VALUE, CreateDefaultValue = null, CreateSetByDefault = true });
            cfg.CertificateAttributes.TypeSpecificAttributes[(ulong)CKC.CKC_WTLS].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_URL, CreateDefaultValue = null });
            cfg.CertificateAttributes.TypeSpecificAttributes[(ulong)CKC.CKC_WTLS].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_HASH_OF_SUBJECT_PUBLIC_KEY, CreateDefaultValue = null });
            cfg.CertificateAttributes.TypeSpecificAttributes[(ulong)CKC.CKC_WTLS].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_HASH_OF_ISSUER_PUBLIC_KEY, CreateDefaultValue = null });

            // TODO - Review
            // X.509 Attribute Certificate Object Attributes
            cfg.CertificateAttributes.TypeSpecificAttributes.Add((ulong)CKC.CKC_X_509_ATTR_CERT, new ClassAttributes());
            cfg.CertificateAttributes.TypeSpecificAttributes[(ulong)CKC.CKC_X_509_ATTR_CERT].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_OWNER, CreateDefaultValue = null });
            cfg.CertificateAttributes.TypeSpecificAttributes[(ulong)CKC.CKC_X_509_ATTR_CERT].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_AC_ISSUER, CreateDefaultValue = null });
            cfg.CertificateAttributes.TypeSpecificAttributes[(ulong)CKC.CKC_X_509_ATTR_CERT].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_SERIAL_NUMBER, CreateDefaultValue = null, CreateSetByDefault = true });
            cfg.CertificateAttributes.TypeSpecificAttributes[(ulong)CKC.CKC_X_509_ATTR_CERT].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_ATTR_TYPES, CreateDefaultValue = null });
            cfg.CertificateAttributes.TypeSpecificAttributes[(ulong)CKC.CKC_X_509_ATTR_CERT].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_VALUE, CreateDefaultValue = null, CreateSetByDefault = true });

            #endregion

            #region Private key attributes

            cfg.PrivateKeyAttributes = new ClassAttributesDefinition();
            cfg.PrivateKeyAttributes.CommonAttributes = new ClassAttributes();

            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_CLASS, CreateDefaultValue = "ULONG:" + (ulong)CKO.CKO_PRIVATE_KEY, CreateSetByDefault = true, GenerateDefaultValue = "ULONG:" + (ulong)CKO.CKO_PRIVATE_KEY, GenerateSetByDefault = true });

            // Common Storage Object Attributes
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_TOKEN, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = true, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = true });
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_PRIVATE, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = true, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = true });
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_MODIFIABLE, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = true, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = true });
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_LABEL, CreateDefaultValue = null, CreateSetByDefault = true, GenerateDefaultValue = null, GenerateSetByDefault = true });

            // Common Key Attributes
            // Note: CKA_KEY_TYPE moved to TypeSpecificAttributes
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_ID, CreateDefaultValue = null, CreateSetByDefault = true, GenerateDefaultValue = null, GenerateSetByDefault = true });
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_START_DATE, CreateDefaultValue = null, CreateSetByDefault = false, GenerateDefaultValue = null, GenerateSetByDefault = false });
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_END_DATE, CreateDefaultValue = null, CreateSetByDefault = false, GenerateDefaultValue = null, GenerateSetByDefault = false });
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_DERIVE, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = false });
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_LOCAL, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = false });
            // Note: CKA_KEY_GEN_MECHANISM moved to TypeSpecificAttributes
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_ALLOWED_MECHANISMS, CreateDefaultValue = null, CreateSetByDefault = false, GenerateDefaultValue = null, GenerateSetByDefault = false });

            // Common Private Key Attributes
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_SUBJECT, CreateDefaultValue = null, CreateSetByDefault = false, GenerateDefaultValue = null, GenerateSetByDefault = false });
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_SENSITIVE, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = false });
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_DECRYPT, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = true, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = true });
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_SIGN, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = true, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = true });
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_SIGN_RECOVER, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:FALSE", GenerateSetByDefault = false });
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_UNWRAP, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = false });
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_EXTRACTABLE, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:FALSE", GenerateSetByDefault = false });
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_ALWAYS_SENSITIVE, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = false });
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_NEVER_EXTRACTABLE, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = false });
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_WRAP_WITH_TRUSTED, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:FALSE", GenerateSetByDefault = false });
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_UNWRAP_TEMPLATE, CreateDefaultValue = null, CreateSetByDefault = false, GenerateDefaultValue = null, GenerateSetByDefault = false });
            cfg.PrivateKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_ALWAYS_AUTHENTICATE, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:FALSE", GenerateSetByDefault = false });

            cfg.PrivateKeyAttributes.TypeSpecificAttributes = new TypeAttributes();

            // RSA Private Key Object Attributes
            cfg.PrivateKeyAttributes.TypeSpecificAttributes.Add((ulong)CKK.CKK_RSA, new ClassAttributes() { KeyGenerationMechanism = CKM.CKM_RSA_PKCS_KEY_PAIR_GEN });
            cfg.PrivateKeyAttributes.TypeSpecificAttributes[(ulong)CKK.CKK_RSA].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_KEY_TYPE, CreateDefaultValue = "ULONG:" + (ulong)CKK.CKK_RSA, CreateSetByDefault = true, GenerateDefaultValue = "ULONG:" + (ulong)CKK.CKK_RSA, GenerateSetByDefault = true });
            cfg.PrivateKeyAttributes.TypeSpecificAttributes[(ulong)CKK.CKK_RSA].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_KEY_GEN_MECHANISM, CreateDefaultValue = "ULONG:" + (ulong)CKM.CKM_RSA_PKCS_KEY_PAIR_GEN, CreateSetByDefault = false, GenerateDefaultValue = "ULONG:" + (ulong)CKM.CKM_RSA_PKCS_KEY_PAIR_GEN, GenerateSetByDefault = false });
            cfg.PrivateKeyAttributes.TypeSpecificAttributes[(ulong)CKK.CKK_RSA].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_MODULUS, CreateDefaultValue = null, CreateSetByDefault = true, GenerateDefaultValue = null, GenerateSetByDefault = false });
            cfg.PrivateKeyAttributes.TypeSpecificAttributes[(ulong)CKK.CKK_RSA].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_PUBLIC_EXPONENT, CreateDefaultValue = null, CreateSetByDefault = true, GenerateDefaultValue = "BYTES:010001", GenerateSetByDefault = false });
            cfg.PrivateKeyAttributes.TypeSpecificAttributes[(ulong)CKK.CKK_RSA].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_PRIVATE_EXPONENT, CreateDefaultValue = null, CreateSetByDefault = true, GenerateDefaultValue = null, GenerateSetByDefault = false });
            cfg.PrivateKeyAttributes.TypeSpecificAttributes[(ulong)CKK.CKK_RSA].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_PRIME_1, CreateDefaultValue = null, CreateSetByDefault = true, GenerateDefaultValue = null, GenerateSetByDefault = false });
            cfg.PrivateKeyAttributes.TypeSpecificAttributes[(ulong)CKK.CKK_RSA].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_PRIME_2, CreateDefaultValue = null, CreateSetByDefault = true, GenerateDefaultValue = null, GenerateSetByDefault = false });
            cfg.PrivateKeyAttributes.TypeSpecificAttributes[(ulong)CKK.CKK_RSA].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_EXPONENT_1, CreateDefaultValue = null, CreateSetByDefault = true, GenerateDefaultValue = null, GenerateSetByDefault = false });
            cfg.PrivateKeyAttributes.TypeSpecificAttributes[(ulong)CKK.CKK_RSA].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_EXPONENT_2, CreateDefaultValue = null, CreateSetByDefault = true, GenerateDefaultValue = null, GenerateSetByDefault = false });
            cfg.PrivateKeyAttributes.TypeSpecificAttributes[(ulong)CKK.CKK_RSA].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_COEFFICIENT, CreateDefaultValue = null, CreateSetByDefault = true, GenerateDefaultValue = null, GenerateSetByDefault = false });

            #endregion

            #region Public key attributes

            cfg.PublicKeyAttributes = new ClassAttributesDefinition();
            cfg.PublicKeyAttributes.CommonAttributes = new ClassAttributes();

            cfg.PublicKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_CLASS, CreateDefaultValue = "ULONG:" + (ulong)CKO.CKO_PUBLIC_KEY, CreateSetByDefault = true, GenerateDefaultValue = "ULONG:" + (ulong)CKO.CKO_PUBLIC_KEY, GenerateSetByDefault = true });

            // Common Storage Object Attributes
            cfg.PublicKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_TOKEN, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = true, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = true });
            cfg.PublicKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_PRIVATE, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = true, GenerateDefaultValue = "BOOL:FALSE", GenerateSetByDefault = true });
            cfg.PublicKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_MODIFIABLE, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = true, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = true });
            cfg.PublicKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_LABEL, CreateDefaultValue = null, CreateSetByDefault = true, GenerateDefaultValue = null, GenerateSetByDefault = true });

            // Common Key Attributes
            // Note: CKA_KEY_TYPE moved to TypeSpecificAttributes
            cfg.PublicKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_ID, CreateDefaultValue = null, CreateSetByDefault = true, GenerateDefaultValue = null, GenerateSetByDefault = true });
            cfg.PublicKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_START_DATE, CreateDefaultValue = null, CreateSetByDefault = false, GenerateDefaultValue = null, GenerateSetByDefault = false });
            cfg.PublicKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_END_DATE, CreateDefaultValue = null, CreateSetByDefault = false, GenerateDefaultValue = null, GenerateSetByDefault = false });
            cfg.PublicKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_DERIVE, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:FALSE", GenerateSetByDefault = false });
            cfg.PublicKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_LOCAL, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = false });
            // Note: CKA_KEY_GEN_MECHANISM moved to TypeSpecificAttributes
            cfg.PublicKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_ALLOWED_MECHANISMS, CreateDefaultValue = null, CreateSetByDefault = false, GenerateDefaultValue = null, GenerateSetByDefault = false });

            // Common Public Key Attributes
            cfg.PublicKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_SUBJECT, CreateDefaultValue = null, CreateSetByDefault = false, GenerateDefaultValue = null, GenerateSetByDefault = false });
            cfg.PublicKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_ENCRYPT, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = true, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = true });
            cfg.PublicKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_VERIFY, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = true, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = true });
            cfg.PublicKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_VERIFY_RECOVER, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:FALSE", GenerateSetByDefault = false });
            cfg.PublicKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_WRAP, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = false });
            cfg.PublicKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_TRUSTED, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:FALSE", GenerateSetByDefault = false });
            cfg.PublicKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_WRAP_TEMPLATE, CreateDefaultValue = null, CreateSetByDefault = false, GenerateDefaultValue = null, GenerateSetByDefault = false });

            cfg.PublicKeyAttributes.TypeSpecificAttributes = new TypeAttributes();

            // RSA Public Key Object Attributes
            cfg.PublicKeyAttributes.TypeSpecificAttributes.Add((ulong)CKK.CKK_RSA, new ClassAttributes());
            cfg.PublicKeyAttributes.TypeSpecificAttributes[(ulong)CKK.CKK_RSA].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_KEY_TYPE, CreateDefaultValue = "ULONG:" + (ulong)CKK.CKK_RSA, CreateSetByDefault = true, GenerateDefaultValue = "ULONG:" + (ulong)CKK.CKK_RSA, GenerateSetByDefault = true });
            cfg.PublicKeyAttributes.TypeSpecificAttributes[(ulong)CKK.CKK_RSA].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_KEY_GEN_MECHANISM, CreateDefaultValue = "ULONG:" + (ulong)CKM.CKM_RSA_PKCS_KEY_PAIR_GEN, CreateSetByDefault = false, GenerateDefaultValue = "ULONG:" + (ulong)CKM.CKM_RSA_PKCS_KEY_PAIR_GEN, GenerateSetByDefault = false });
            cfg.PublicKeyAttributes.TypeSpecificAttributes[(ulong)CKK.CKK_RSA].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_MODULUS, CreateDefaultValue = null, CreateSetByDefault = true, GenerateDefaultValue = null, GenerateSetByDefault = false });
            cfg.PublicKeyAttributes.TypeSpecificAttributes[(ulong)CKK.CKK_RSA].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_MODULUS_BITS, CreateDefaultValue = "ULONG:2048", CreateSetByDefault = false, GenerateDefaultValue = "ULONG:2048", GenerateSetByDefault = true });
            cfg.PublicKeyAttributes.TypeSpecificAttributes[(ulong)CKK.CKK_RSA].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_PUBLIC_EXPONENT, CreateDefaultValue = null, CreateSetByDefault = true, GenerateDefaultValue = "BYTES:010001", GenerateSetByDefault = false });

            #endregion

            #region Secret key attributes

            cfg.SecretKeyAttributes = new ClassAttributesDefinition();
            cfg.SecretKeyAttributes.CommonAttributes = new ClassAttributes();

            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_CLASS, CreateDefaultValue = "ULONG:" + (ulong)CKO.CKO_SECRET_KEY, CreateSetByDefault = true, GenerateDefaultValue = "ULONG:" + (ulong)CKO.CKO_SECRET_KEY, GenerateSetByDefault = true });

            // Common Storage Object Attributes
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_TOKEN, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = true, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = true });
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_PRIVATE, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = true, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = true });
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_MODIFIABLE, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = true, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = true });
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_LABEL, CreateDefaultValue = null, CreateSetByDefault = true, GenerateDefaultValue = null, GenerateSetByDefault = true });

            // Common Key Attributes
            // Note: CKA_KEY_TYPE moved to TypeSpecificAttributes
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_ID, CreateDefaultValue = null, CreateSetByDefault = true, GenerateDefaultValue = null, GenerateSetByDefault = true });
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_START_DATE, CreateDefaultValue = null, CreateSetByDefault = false, GenerateDefaultValue = null, GenerateSetByDefault = false });
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_END_DATE, CreateDefaultValue = null, CreateSetByDefault = false, GenerateDefaultValue = null, GenerateSetByDefault = false });
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_DERIVE, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = false });
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_LOCAL, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = false });
            // Note: CKA_KEY_GEN_MECHANISM moved to TypeSpecificAttributes
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_ALLOWED_MECHANISMS, CreateDefaultValue = null, CreateSetByDefault = false, GenerateDefaultValue = null, GenerateSetByDefault = false });

            // Common Secret Key Attributes
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_SENSITIVE, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = true, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = true });
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_ENCRYPT, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = true, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = true });
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_DECRYPT, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = true, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = true });
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_SIGN, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:FALSE", GenerateSetByDefault = false });
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_VERIFY, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:FALSE", GenerateSetByDefault = false });
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_WRAP, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = false });
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_UNWRAP, CreateDefaultValue = "BOOL:TRUE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = false });
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_EXTRACTABLE, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:FALSE", GenerateSetByDefault = false });
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_ALWAYS_SENSITIVE, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = false });
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_NEVER_EXTRACTABLE, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:TRUE", GenerateSetByDefault = false });
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_CHECK_VALUE, CreateDefaultValue = null, CreateSetByDefault = false, GenerateDefaultValue = null, GenerateSetByDefault = false });
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_WRAP_WITH_TRUSTED, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:FALSE", GenerateSetByDefault = false });
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_TRUSTED, CreateDefaultValue = "BOOL:FALSE", CreateSetByDefault = false, GenerateDefaultValue = "BOOL:FALSE", GenerateSetByDefault = false });
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_WRAP_TEMPLATE, CreateDefaultValue = null, CreateSetByDefault = false, GenerateDefaultValue = null, GenerateSetByDefault = false });
            cfg.SecretKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_UNWRAP_TEMPLATE, CreateDefaultValue = null, CreateSetByDefault = false, GenerateDefaultValue = null, GenerateSetByDefault = false });

            cfg.SecretKeyAttributes.TypeSpecificAttributes = new TypeAttributes();

            // AES Secret Key Object Attributes
            cfg.SecretKeyAttributes.TypeSpecificAttributes.Add((ulong)CKK.CKK_AES, new ClassAttributes() { KeyGenerationMechanism = CKM.CKM_AES_KEY_GEN });
            cfg.SecretKeyAttributes.TypeSpecificAttributes[(ulong)CKK.CKK_AES].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_KEY_TYPE, CreateDefaultValue = "ULONG:" + (ulong)CKK.CKK_AES, CreateSetByDefault = true, GenerateDefaultValue = "ULONG:" + (ulong)CKK.CKK_AES, GenerateSetByDefault = true });
            cfg.SecretKeyAttributes.TypeSpecificAttributes[(ulong)CKK.CKK_AES].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_KEY_GEN_MECHANISM, CreateDefaultValue = "ULONG:" + (ulong)CKM.CKM_AES_KEY_GEN, CreateSetByDefault = false, GenerateDefaultValue = "ULONG:" + (ulong)CKM.CKM_AES_KEY_GEN, GenerateSetByDefault = false });
            cfg.SecretKeyAttributes.TypeSpecificAttributes[(ulong)CKK.CKK_AES].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_VALUE, CreateDefaultValue = null, CreateSetByDefault = true, GenerateDefaultValue = null, GenerateSetByDefault = false });
            cfg.SecretKeyAttributes.TypeSpecificAttributes[(ulong)CKK.CKK_AES].Add(new ClassAttribute() { Value = (ulong)CKA.CKA_VALUE_LEN, CreateDefaultValue = null, CreateSetByDefault = true, GenerateDefaultValue = "ULONG:32", GenerateSetByDefault = true });

            // TODO - Add more TypeSpecificAttributes

            #endregion

            #region OTP key attributes

            cfg.OtpKeyAttributes = new ClassAttributesDefinition();
            cfg.OtpKeyAttributes.CommonAttributes = new ClassAttributes();

            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_CLASS, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_TOKEN, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_PRIVATE, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_MODIFIABLE, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_LABEL, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_KEY_TYPE, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_ID, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_START_DATE, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_END_DATE, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_DERIVE, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_LOCAL, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_KEY_GEN_MECHANISM, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_ALLOWED_MECHANISMS, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_SENSITIVE, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_ENCRYPT, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_DECRYPT, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_SIGN, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_VERIFY, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_WRAP, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_UNWRAP, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_EXTRACTABLE, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_ALWAYS_SENSITIVE, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_NEVER_EXTRACTABLE, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_CHECK_VALUE, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_WRAP_WITH_TRUSTED, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_TRUSTED, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_WRAP_TEMPLATE, CreateDefaultValue = "TODO" });
            cfg.OtpKeyAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_UNWRAP_TEMPLATE, CreateDefaultValue = "TODO" });

            cfg.OtpKeyAttributes.TypeSpecificAttributes = new TypeAttributes();
            // TODO 

            #endregion

            #region Domain parameters attributes

            cfg.DomainParamsAttributes = new ClassAttributesDefinition();
            cfg.DomainParamsAttributes.CommonAttributes = new ClassAttributes();

            cfg.DomainParamsAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_CLASS, CreateDefaultValue = "TODO" });
            cfg.DomainParamsAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_TOKEN, CreateDefaultValue = "TODO" });
            cfg.DomainParamsAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_PRIVATE, CreateDefaultValue = "TODO" });
            cfg.DomainParamsAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_MODIFIABLE, CreateDefaultValue = "TODO" });
            cfg.DomainParamsAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_KEY_TYPE, CreateDefaultValue = "TODO" });
            cfg.DomainParamsAttributes.CommonAttributes.Add(new ClassAttribute() { Value = (ulong)CKA.CKA_LOCAL, CreateDefaultValue = "TODO" });

            cfg.DomainParamsAttributes.TypeSpecificAttributes = new TypeAttributes();
            // TODO 

            #endregion

            #endregion

            #region DnEntries

            cfg.DnEntryDefinitions = new DnEntryDefinitions();
            cfg.DnEntryDefinitions.Add("2.5.4.3", new DnEntryDefinition() { Name = "commonName", Oid = "2.5.4.3", ValueType = DnEntryValueType.Utf8String });
            cfg.DnEntryDefinitions.Add("2.5.4.4", new DnEntryDefinition() { Name = "surname", Oid = "2.5.4.4", ValueType = DnEntryValueType.Utf8String });
            cfg.DnEntryDefinitions.Add("2.5.4.5", new DnEntryDefinition() { Name = "serialNumber", Oid = "2.5.4.5", ValueType = DnEntryValueType.PrintableString });
            cfg.DnEntryDefinitions.Add("2.5.4.6", new DnEntryDefinition() { Name = "countryName", Oid = "2.5.4.6", ValueType = DnEntryValueType.PrintableString });
            cfg.DnEntryDefinitions.Add("2.5.4.7", new DnEntryDefinition() { Name = "localityName", Oid = "2.5.4.7", ValueType = DnEntryValueType.Utf8String });
            cfg.DnEntryDefinitions.Add("2.5.4.8", new DnEntryDefinition() { Name = "stateOrProvinceName", Oid = "2.5.4.8", ValueType = DnEntryValueType.Utf8String });
            cfg.DnEntryDefinitions.Add("2.5.4.9", new DnEntryDefinition() { Name = "streetAddress", Oid = "2.5.4.9", ValueType = DnEntryValueType.Utf8String });
            cfg.DnEntryDefinitions.Add("2.5.4.10", new DnEntryDefinition() { Name = "organizationName", Oid = "2.5.4.10", ValueType = DnEntryValueType.Utf8String });
            cfg.DnEntryDefinitions.Add("2.5.4.11", new DnEntryDefinition() { Name = "organizationUnitName", Oid = "2.5.4.11", ValueType = DnEntryValueType.Utf8String });
            cfg.DnEntryDefinitions.Add("2.5.4.42", new DnEntryDefinition() { Name = "givenName", Oid = "2.5.4.42", ValueType = DnEntryValueType.Utf8String });

            #endregion

            return cfg;
        }
    }
}

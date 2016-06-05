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

using Net.Pkcs11Interop.Common;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;

namespace Net.Pkcs11Admin
{
    public class HashAlgorithm
    {
        public static readonly HashAlgorithm SHA1 = new HashAlgorithm(
            "SHA1",
            "1.3.14.3.2.26",
            new Dictionary<CKK, string>() { { CKK.CKK_RSA, "1.2.840.113549.1.1.5" } },
            typeof(Sha1Digest));

        public static readonly HashAlgorithm SHA256 = new HashAlgorithm(
            "SHA256",
            "2.16.840.1.101.3.4.2.1",
            new Dictionary<CKK, string>() { { CKK.CKK_RSA, "1.2.840.113549.1.1.11" } },
            typeof(Sha256Digest));

        public static readonly HashAlgorithm SHA384 = new HashAlgorithm(
            "SHA384",
            "2.16.840.1.101.3.4.2.2",
            new Dictionary<CKK, string>() { { CKK.CKK_RSA, "1.2.840.113549.1.1.12" } },
            typeof(Sha384Digest));

        public static readonly HashAlgorithm SHA512 = new HashAlgorithm(
            "SHA512",
            "2.16.840.1.101.3.4.2.3",
            new Dictionary<CKK, string>() { { CKK.CKK_RSA, "1.2.840.113549.1.1.13" } },
            typeof(Sha512Digest));

        public static readonly HashAlgorithm[] SupportedAlgorithms = new HashAlgorithm[]
        {
            SHA1, SHA256, SHA384, SHA512
        };

        public string Name
        {
            get;
            private set;
        }

        public string Oid
        {
            get;
            private set;
        }

        public Dictionary<CKK, string> SignatureAlgorithmOid
        {
            get;
            private set;
        }

        private Type ImplementationType
        {
            get;
            set;
        }

        private HashAlgorithm(string name, string oid, Dictionary<CKK, string> signatureAlgorithmOid, Type implementationType)
        {
            this.Name = name;
            this.Oid = oid;
            this.SignatureAlgorithmOid = signatureAlgorithmOid;
            this.ImplementationType = implementationType;
        }

        private IDigest GetImplementationInstance()
        {
            return (IDigest)Activator.CreateInstance(this.ImplementationType);
        }

        public byte[] ComputeDigest(byte[] data)
        {
            if (data == null || data.Length < 1)
                throw new ArgumentNullException("data");

            IDigest digest = GetImplementationInstance();

            byte[] hash = new byte[digest.GetDigestSize()];

            digest.Reset();
            digest.BlockUpdate(data, 0, data.Length);
            digest.DoFinal(hash, 0);

            return hash;
        }
    }
}

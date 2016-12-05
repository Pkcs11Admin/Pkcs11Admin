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

using Net.Pkcs11Admin.Configuration;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Net.Pkcs11Admin
{
    public static class Utils
    {
        public static string NormalizeFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName");

            return string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));
        }

        public static Dictionary<string, List<string>> ParseX509Name(X509Name x509Name)
        {
            if (x509Name == null)
                throw new ArgumentNullException("x509Name");

            Dictionary<string, List<string>> parts = new Dictionary<string, List<string>>();

            IList oidList = x509Name.GetOidList();
            IList valueList = x509Name.GetValueList();

            for (int i = 0; i < oidList.Count; i++)
            {
                DerObjectIdentifier oid = oidList[i] as DerObjectIdentifier;
                string value = valueList[i] as string;

                if (!parts.ContainsKey(oid.Id))
                    parts.Add(oid.Id, new List<string>() { value });
                else
                    parts[oid.Id].Add(value);
            }

            return parts;
        }

        private static Asn1Encodable EncodeDnEntry(DnEntry dnEntry)
        {
            DerObjectIdentifier type = new DerObjectIdentifier(dnEntry.Definition.Oid);
            Asn1Encodable value = null;

            switch (dnEntry.Definition.ValueType)
            {
                case DnEntryValueType.PrintableString:
                    value = new DerPrintableString(Encoding.UTF8.GetBytes(dnEntry.Value));
                    break;

                case DnEntryValueType.UniversalString:
                    value = new DerUniversalString(Encoding.UTF8.GetBytes(dnEntry.Value));
                    break;

                case DnEntryValueType.Utf8String:
                    value = new DerUtf8String(Encoding.UTF8.GetBytes(dnEntry.Value));
                    break;

                case DnEntryValueType.BmpString:
                    value = new DerBmpString(Encoding.UTF8.GetBytes(dnEntry.Value));
                    break;

                default:
                    // TODO - Does BC support DnEntryValueType.TeletexString ???
                    throw new Exception("Unsupported type of DnEntry value");
            }

            return new DerSet(new DerSequence(type, value));
        }

        public static X509Name CreateX509Name(DnEntry[] dnEntries)
        {
            Asn1EncodableVector vector = new Asn1EncodableVector();
            for (int i = 0; i != dnEntries.Length; i++)
                vector.Add(EncodeDnEntry(dnEntries[i]));

            DerSequence sequence = new DerSequence(vector);
            return X509Name.GetInstance(sequence);
        }

        public static byte[] CreateDigestInfo(byte[] hash, string hashOid)
        {
            DerObjectIdentifier derObjectIdentifier = new DerObjectIdentifier(hashOid);
            AlgorithmIdentifier algorithmIdentifier = new AlgorithmIdentifier(derObjectIdentifier, null);
            DigestInfo digestInfo = new DigestInfo(algorithmIdentifier, hash);
            return digestInfo.GetDerEncoded();
        }
    }
}

/*
 *  Pkcs11Admin - GUI tool for administration of PKCS#11 enabled devices
 *  Copyright (c) 2014-2022 Jaroslav Imrich <jimrich@jimrich.sk>
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

using Net.Pkcs11Interop.HighLevelAPI;
using System.Collections.Generic;

namespace Net.Pkcs11Admin
{
    public class Pkcs11CertificateInfo : Pkcs11ObjectInfo
    {
        public bool CkaPrivate
        {
            get;
            internal set;
        }

        public ulong CkaCertificateType
        {
            get;
            internal set;
        }

        public string CkaLabel
        {
            get;
            internal set;
        }

        public byte[] CkaId
        {
            get;
            internal set;
        }

        public byte[] CkaValue
        {
            get;
            internal set;
        }

        internal Pkcs11CertificateInfo(IObjectHandle objectHandle, List<IObjectAttribute> objectAttributes, ulong? storageSize)
        {
            ObjectHandle = objectHandle;
            ObjectAttributes = objectAttributes;
            StorageSize = storageSize;
        }
    }
}

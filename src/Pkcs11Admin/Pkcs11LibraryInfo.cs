/*
 *  Pkcs11Admin - GUI tool for administration of PKCS#11 enabled devices
 *  Copyright (c) 2014-2019 Jaroslav Imrich <jimrich@jimrich.sk>
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

namespace Net.Pkcs11Admin
{
    public class Pkcs11LibraryInfo : Pkcs11Info
    {
        public string LibraryPath
        {
            get;
            private set;
        }

        public string CryptokiVersion
        {
            get;
            private set;
        }

        public string ManufacturerId
        {
            get;
            private set;
        }

        public ulong Flags
        {
            get;
            private set;
        }

        public string LibraryDescription
        {
            get;
            private set;
        }

        public string LibraryVersion
        {
            get;
            private set;
        }

        internal Pkcs11LibraryInfo(string libraryPath, ILibraryInfo libraryInfo)
        {
            LibraryPath = libraryPath;
            CryptokiVersion = libraryInfo.CryptokiVersion;
            ManufacturerId = libraryInfo.ManufacturerId;
            Flags = libraryInfo.Flags;
            LibraryDescription = libraryInfo.LibraryDescription;
            LibraryVersion = libraryInfo.LibraryVersion;
        }
    }
}

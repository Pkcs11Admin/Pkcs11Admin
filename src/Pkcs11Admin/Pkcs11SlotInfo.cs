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

using Net.Pkcs11Interop.HighLevelAPI;

namespace Net.Pkcs11Admin
{
    public class Pkcs11SlotInfo : Pkcs11Info
    {
        public ulong SlotId
        {
            get;
            private set;
        }

        public string SlotDescription
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

        public bool TokenPresent
        {
            get;
            private set;
        }

        public bool RemovableDevice
        {
            get;
            private set;
        }

        public bool HardwareSlot
        {
            get;
            private set;
        }

        public string HardwareVersion
        {
            get;
            private set;
        }

        public string FirmwareVersion
        {
            get;
            private set;
        }

        internal Pkcs11SlotInfo(SlotInfo slotInfo)
        {
            SlotId = slotInfo.SlotId;
            SlotDescription = slotInfo.SlotDescription;
            ManufacturerId = slotInfo.ManufacturerId;
            Flags = slotInfo.SlotFlags.Flags;
            TokenPresent = slotInfo.SlotFlags.TokenPresent;
            RemovableDevice = slotInfo.SlotFlags.RemovableDevice;
            HardwareSlot = slotInfo.SlotFlags.HardwareSlot;
            HardwareVersion = slotInfo.HardwareVersion;
            FirmwareVersion = slotInfo.FirmwareVersion;
        }
    }
}

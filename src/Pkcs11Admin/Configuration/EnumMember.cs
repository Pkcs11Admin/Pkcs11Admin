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

using System.Runtime.Serialization;

namespace Net.Pkcs11Admin.Configuration
{
    [DataContract(Namespace = Pkcs11AdminConfig.Namespace)]
    public class EnumMember
    {
        [DataMember(Order = 1, IsRequired = true)]
        public ulong Value
        {
            get;
            set;
        }

        [DataMember(Order = 2, IsRequired = true)]
        public string Name
        {
            get;
            set;
        }

        [DataMember(Order = 3, IsRequired = true)]
        public string FriendlyName
        {
            get;
            set;
        }

        [DataMember(Order = 4, IsRequired = false)]
        public string Description // TODO - How should this be used ???
        {
            get;
            set;
        }
    }
}

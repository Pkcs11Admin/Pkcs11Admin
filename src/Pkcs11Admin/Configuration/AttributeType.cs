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

using System.Runtime.Serialization;

namespace Net.Pkcs11Admin.Configuration
{
    [DataContract(Namespace = Pkcs11AdminConfig.Namespace)]
    public enum AttributeType
    {
        [EnumMember]
        ULong = 0,

        [EnumMember]
        Bool = 1,

        [EnumMember]
        String = 2,

        [EnumMember]
        ByteArray = 3,

        [EnumMember]
        DateTime = 4,

        [EnumMember]
        AttributeArray = 5,

        [EnumMember]
        ULongArray = 6,

        [EnumMember]
        MechanismArray = 7
    }
}

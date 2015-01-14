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

using System.Runtime.Serialization;

namespace Net.Pkcs11Admin.Configuration
{
    [DataContract(Namespace = Pkcs11AdminConfig.Namespace)]
    public class ClassAttributesDefinition
    {
        [DataMember(Order = 1, IsRequired = true)]
        public ClassAttributes CommonAttributes;

        [DataMember(Order = 2, IsRequired = false)]
        public TypeAttributes TypeSpecificAttributes;
    }
}

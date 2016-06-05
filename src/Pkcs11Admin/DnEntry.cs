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
using System;

namespace Net.Pkcs11Admin
{
    public class DnEntry
    {
        public DnEntryDefinition Definition
        {
            get;
            private set;
        }

        public string Value
        {
            get;
            private set;
        }

        public DnEntry(DnEntryDefinition definition, string value)
        {
            if (definition == null)
                throw new ArgumentNullException(nameof(definition));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            this.Definition = definition;
            this.Value = value;
        }
    }
}

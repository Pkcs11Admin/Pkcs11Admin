/*
 *  Pkcs11Admin - GUI tool for administration of PKCS#11 enabled devices
 *  Copyright (c) 2014 Jaroslav Imrich <jimrich@jimrich.sk>
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
using Net.Pkcs11Interop.HighLevelAPI;
using System;
using System.Collections.Generic;

namespace Net.Pkcs11Admin.Configuration
{
    public static class StringUtils // TODO - Rename to more appropriate name
    {
        public static string BytesToHexString(byte[] bytes)
        {
            return (bytes == null) ? null : BitConverter.ToString(bytes).Replace('-', ' ');
        }

        public static byte[] HexStringToBytes(string hexString)
        {
            return (string.IsNullOrEmpty(hexString)) ? null : ConvertUtils.HexStringToBytes(hexString.Replace(" ", ""));
        }

        public static void GetAttributeNameAndValue(ObjectAttribute objectAttribute, out string name, out string value)
        {
            if (objectAttribute == null)
                throw new ArgumentNullException("objectAttribute");

            string tmpName = null;
            string tmpValue = null;

            // Find attribute definition in configuration
            AttributeDefinition pkcs11Attribute = null;
            if (Pkcs11Admin.Instance.Config.AttributeDefinitions.ContainsKey(objectAttribute.Type))
                pkcs11Attribute = Pkcs11Admin.Instance.Config.AttributeDefinitions[objectAttribute.Type];

            // Determine attribute name
            if (pkcs11Attribute == null)
                tmpName = string.Format("Unknown ({0})", objectAttribute.Type.ToString());
            else
                tmpName = pkcs11Attribute.Name;
    
            // Determine attribute value
            if (pkcs11Attribute == null)
            {
                if (objectAttribute.CannotBeRead)
                    tmpValue = "<unextractable>";
                else
                    tmpValue = BytesToHexString(objectAttribute.GetValueAsByteArray());
            }
            else
            {
                if (objectAttribute.CannotBeRead)
                {
                    tmpValue = "<unextractable>";
                }
                else
                {
                    // TODO - More robust conversions
                    switch (pkcs11Attribute.Type)
                    {
                        case AttributeType.Bool:

                            tmpValue = objectAttribute.GetValueAsBool().ToString();

                            break;

                        case AttributeType.ByteArray:

                            tmpValue = BytesToHexString(objectAttribute.GetValueAsByteArray());

                            break;

                        case AttributeType.DateTime:

                            DateTime? dateTime = objectAttribute.GetValueAsDateTime();
                            tmpValue = (dateTime == null) ? null : dateTime.Value.ToShortDateString();

                            break;

                        case AttributeType.String:

                            tmpValue = objectAttribute.GetValueAsString();

                            break;

                        case AttributeType.ULong:

                            tmpValue = GetAttributeEnumValue(pkcs11Attribute, objectAttribute.GetValueAsUlong(), false);

                            break;

                        case AttributeType.AttributeArray:
                        case AttributeType.MechanismArray:
                        case AttributeType.ULongArray:

                            tmpValue = "<unsupported>"; // TODO

                            break;

                        default:

                            tmpValue = "<unknown>";

                            break;
                    }

                    if (string.IsNullOrEmpty(tmpValue))
                        tmpValue = "<empty>";
                }
            }

            // Set output parameters
            name = tmpName;
            value = tmpValue;
        }

        public static string GetAttributeEnumValue(ulong attribute, ulong value, bool preferFriendlyName)
        {
            string strValue = value.ToString();

            AttributeDefinition pkcs11Attribute = null;
            if (Pkcs11Admin.Instance.Config.AttributeDefinitions.ContainsKey(attribute))
            {
                pkcs11Attribute = Pkcs11Admin.Instance.Config.AttributeDefinitions[attribute];
                strValue = GetAttributeEnumValue(pkcs11Attribute, value, preferFriendlyName);
            }

            return strValue;
        }

        public static string GetAttributeEnumValue(AttributeDefinition attributeDefinition, ulong attributeValue, bool preferFriendlyName)
        {
            if (attributeDefinition == null)
                throw new ArgumentNullException("attributeDefinition");

            string strValue = attributeValue.ToString();

            if (!string.IsNullOrEmpty(attributeDefinition.Enum))
            {
                if ((Pkcs11Admin.Instance.Config.EnumDefinitions.ContainsKey(attributeDefinition.Enum)) &&
                    (Pkcs11Admin.Instance.Config.EnumDefinitions[attributeDefinition.Enum].ContainsKey(attributeValue)))
                {
                    EnumMember enumMember = Pkcs11Admin.Instance.Config.EnumDefinitions[attributeDefinition.Enum][attributeValue];
                    if ((preferFriendlyName == true) && (!string.IsNullOrEmpty(enumMember.FriendlyName)))
                        strValue = enumMember.FriendlyName;
                    else
                        strValue = enumMember.Name;
                }
                else
                {
                    strValue = string.Format("Unknown ({0})", attributeValue.ToString());
                }
            }

            return strValue;
        }

        public static ObjectAttribute GetDefaultAttribute(ClassAttribute classAttribute)
        {
            if (classAttribute == null)
                throw new ArgumentNullException("classAttribute");

            ObjectAttribute objectAttribute = null;

            if (classAttribute.DefaultValue == null)
            {
                objectAttribute = new ObjectAttribute(classAttribute.Value);
            }
            else
            {
                if (classAttribute.DefaultValue.StartsWith("ULONG:"))
                {
                    string ulongString = classAttribute.DefaultValue.Substring("ULONG:".Length);
                    ulong ulongValue = Convert.ToUInt64(ulongString);
                    objectAttribute = new ObjectAttribute(classAttribute.Value, ulongValue);
                }
                else if (classAttribute.DefaultValue.StartsWith("BOOL:"))
                {
                    string boolString = classAttribute.DefaultValue.Substring("BOOL:".Length);
                    
                    bool boolValue = false;
                    if (0 == string.Compare(boolString, "TRUE", true))
                        boolValue = true;
                    else if (0 == string.Compare(boolString, "FALSE", true))
                        boolValue = false;
                    else
                        throw new Exception("Unable to parse default value of class attribute");
                    
                    objectAttribute = new ObjectAttribute(classAttribute.Value, boolValue);
                }
                else if (classAttribute.DefaultValue.StartsWith("STRING:"))
                {
                    string strValue = classAttribute.DefaultValue.Substring("STRING:".Length);
                    objectAttribute = new ObjectAttribute(classAttribute.Value, strValue);
                }
                else if (classAttribute.DefaultValue.StartsWith("BYTES:"))
                {
                    string hexString = classAttribute.DefaultValue.Substring("BYTES:".Length);
                    byte[] bytes = ConvertUtils.HexStringToBytes(hexString);
                    objectAttribute = new ObjectAttribute(classAttribute.Value, bytes);
                }
                else if (classAttribute.DefaultValue.StartsWith("DATE:"))
                {
                    // TODO
                    throw new NotImplementedException();
                }
                else
                {
                    throw new Exception("Unable to parse default value of class attribute");
                }
            }

            return objectAttribute;
        }

        public static List<Tuple<ObjectAttribute, ClassAttribute>> GetDefaultAttributes(ClassAttributesDefinition classAttributes, ulong? objectType)
        {
            if (classAttributes == null)
                throw new ArgumentNullException("classAttributes");

            List<Tuple<ObjectAttribute, ClassAttribute>> objectAttributes = new List<Tuple<ObjectAttribute, ClassAttribute>>();

            foreach (ClassAttribute classAttribute in classAttributes.CommonAttributes)
                objectAttributes.Add(new Tuple<ObjectAttribute, ClassAttribute>(GetDefaultAttribute(classAttribute), classAttribute));

            if ((objectType != null) && (classAttributes.TypeSpecificAttributes.ContainsKey(objectType.Value)))
                foreach (ClassAttribute classAttribute in classAttributes.TypeSpecificAttributes[objectType.Value])
                    objectAttributes.Add(new Tuple<ObjectAttribute, ClassAttribute>(GetDefaultAttribute(classAttribute), classAttribute));

            return objectAttributes;
        }
    }
}

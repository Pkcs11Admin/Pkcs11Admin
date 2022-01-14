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

using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;
using Net.Pkcs11Interop.HighLevelAPI.Factories;
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

        /// <summary>
        /// Compares two specified cryptoki versions and returns an integer that indicates their relative position in the sort order.
        /// </summary>
        /// <param name="version1">The first version to compare</param>
        /// <param name="version2">The second version to compare</param>
        /// <returns>Less than zero - versionA is less than versionB. Zero - versionA equals versionB. Greater than zero - versionA is greater than versionB.</returns>
        public static int CompareCkVersions(string versionA, string versionB)
        {
            return string.Compare(versionA, versionB);
        }

        public static void GetAttributeNameAndValue(IObjectAttribute objectAttribute, out string name, out string value)
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

        private static IObjectAttribute GetDefaultAttribute(ulong type, string defaultValue)
        {
            IObjectAttribute objectAttribute = null;

            IObjectAttributeFactory objectAttributeFactory = Pkcs11Admin.Instance.Factories.ObjectAttributeFactory;

            if (defaultValue == null)
            {
                objectAttribute = objectAttributeFactory.Create(type);
            }
            else
            {
                if (defaultValue.StartsWith("ULONG:"))
                {
                    string ulongString = defaultValue.Substring("ULONG:".Length);
                    ulong ulongValue = Convert.ToUInt64(ulongString);
                    objectAttribute = objectAttributeFactory.Create(type, ulongValue);
                }
                else if (defaultValue.StartsWith("BOOL:"))
                {
                    string boolString = defaultValue.Substring("BOOL:".Length);
                    
                    bool boolValue = false;
                    if (0 == string.Compare(boolString, "TRUE", true))
                        boolValue = true;
                    else if (0 == string.Compare(boolString, "FALSE", true))
                        boolValue = false;
                    else
                        throw new Exception("Unable to parse default value of class attribute");
                    
                    objectAttribute = objectAttributeFactory.Create(type, boolValue);
                }
                else if (defaultValue.StartsWith("STRING:"))
                {
                    string strValue = defaultValue.Substring("STRING:".Length);
                    objectAttribute = objectAttributeFactory.Create(type, strValue);
                }
                else if (defaultValue.StartsWith("BYTES:"))
                {
                    string hexString = defaultValue.Substring("BYTES:".Length);
                    byte[] bytes = ConvertUtils.HexStringToBytes(hexString);
                    objectAttribute = objectAttributeFactory.Create(type, bytes);
                }
                else if (defaultValue.StartsWith("DATE:"))
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

        private static List<Tuple<IObjectAttribute, ClassAttribute>> GetDefaultAttributes(ClassAttributesDefinition classAttributes, ulong? objectType, bool createObject)
        {
            if (classAttributes == null)
                throw new ArgumentNullException("classAttributes");

            List<Tuple<IObjectAttribute, ClassAttribute>> objectAttributes = new List<Tuple<IObjectAttribute, ClassAttribute>>();

            foreach (ClassAttribute classAttribute in classAttributes.CommonAttributes)
            {
                IObjectAttribute objectAttribute = (createObject) ? GetDefaultAttribute(classAttribute.Value, classAttribute.CreateDefaultValue) : GetDefaultAttribute(classAttribute.Value, classAttribute.GenerateDefaultValue);
                objectAttributes.Add(new Tuple<IObjectAttribute, ClassAttribute>(objectAttribute, classAttribute));
            }

            if ((objectType != null) && (classAttributes.TypeSpecificAttributes.ContainsKey(objectType.Value)))
            {
                foreach (ClassAttribute classAttribute in classAttributes.TypeSpecificAttributes[objectType.Value])
                {
                    IObjectAttribute objectAttribute = (createObject) ? GetDefaultAttribute(classAttribute.Value, classAttribute.CreateDefaultValue) : GetDefaultAttribute(classAttribute.Value, classAttribute.GenerateDefaultValue);
                    objectAttributes.Add(new Tuple<IObjectAttribute, ClassAttribute>(objectAttribute, classAttribute));
                }
            }

            return objectAttributes;
        }

        public static List<Tuple<IObjectAttribute, ClassAttribute>> GetCreateDefaultAttributes(ClassAttributesDefinition classAttributes, ulong? objectType)
        {
            if (classAttributes == null)
                throw new ArgumentNullException("classAttributes");

            return GetDefaultAttributes(classAttributes, objectType, true);
        }

        public static List<Tuple<IObjectAttribute, ClassAttribute>> GetGenerateDefaultAttributes(ClassAttributesDefinition classAttributes, ulong? objectType)
        {
            if (classAttributes == null)
                throw new ArgumentNullException("classAttributes");

            return GetDefaultAttributes(classAttributes, objectType, false);
        }
    }
}

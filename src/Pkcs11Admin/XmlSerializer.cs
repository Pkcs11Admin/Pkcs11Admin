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

using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Net.Pkcs11Admin
{
    public static class XmlSerializer
    {
        public static T Deserialize<T>(Stream inputStream)
        {
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings()
            {
                CloseInput = false,
                ConformanceLevel = ConformanceLevel.Document,
                DtdProcessing = DtdProcessing.Prohibit,
                ValidationType = ValidationType.None
            };

            using (XmlReader xmlReader = XmlReader.Create(inputStream, xmlReaderSettings))
            {
                DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(T));
                return (T)dataContractSerializer.ReadObject(xmlReader);
            }
        }

        public static void Serialize(object o, Stream outputStream)
        {
            XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings()
            {
                CloseOutput = false,
                Encoding = new UTF8Encoding(false, true),
                OmitXmlDeclaration = false,
                Indent = true
            };

            using (XmlWriter xmlWriter = XmlWriter.Create(outputStream, xmlWriterSettings))
            {
                DataContractSerializer dataContractSerializer = new DataContractSerializer(o.GetType());
                dataContractSerializer.WriteObject(xmlWriter, o);
            }
        }
    }
}

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

using Net.Pkcs11Admin.Configuration;
using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.URI;
using System.Collections.Generic;
using System.ComponentModel;

namespace Net.Pkcs11Admin
{
    public class Pkcs11Uri
    {
        #region Module definition

        [Category("01. PKCS#11 library path")]
        [DisplayName("Attribute value:")]
        public string ModulePath
        {
            get;
            set;
        }

        [Category("01. PKCS#11 library path")]
        [DisplayName("Present in URI:")]
        public bool ModulePathPresent
        {
            get;
            set;
        }

        [Category("02. PKCS#11 library name")]
        [DisplayName("Attribute value:")]
        public string ModuleName
        {
            get;
            set;
        }

        [Category("02. PKCS#11 library name")]
        [DisplayName("Present in URI:")]
        public bool ModuleNamePresent
        {
            get;
            set;
        }

        #endregion

        #region Library definition

        [Category("03. Library manufacturer")]
        [DisplayName("Attribute value:")]
        public string LibraryManufacturer
        {
            get;
            set;
        }

        [Category("03. Library manufacturer")]
        [DisplayName("Present in URI:")]
        public bool LibraryManufacturerPresent
        {
            get;
            set;
        }

        [Category("04. Library description")]
        [DisplayName("Attribute value:")]
        public string LibraryDescription
        {
            get;
            set;
        }

        [Category("04. Library description")]
        [DisplayName("Present in URI:")]
        public bool LibraryDescriptionPresent
        {
            get;
            set;
        }

        [Category("05. Library version")]
        [DisplayName("Attribute value:")]
        public string LibraryVersion
        {
            get;
            set;
        }

        [Category("05. Library version")]
        [DisplayName("Present in URI:")]
        public bool LibraryVersionPresent
        {
            get;
            set;
        }
        
        #endregion

        #region Token definition

        [Category("06. Token manufacturer")]
        [DisplayName("Attribute value:")]
        public string Manufacturer
        {
            get;
            set;
        }

        [Category("06. Token manufacturer")]
        [DisplayName("Present in URI:")]
        public bool ManufacturerPresent
        {
            get;
            set;
        }

        [Category("07. Token model")]
        [DisplayName("Attribute value:")]
        public string Model
        {
            get;
            set;
        }

        [Category("07. Token model")]
        [DisplayName("Present in URI:")]
        public bool ModelPresent
        {
            get;
            set;
        }

        [Category("08. Token serial number")]
        [DisplayName("Attribute value:")]
        public string Serial
        {
            get;
            set;
        }

        [Category("08. Token serial number")]
        [DisplayName("Present in URI:")]
        public bool SerialPresent
        {
            get;
            set;
        }

        [Category("08. Token label")]
        [DisplayName("Attribute value:")]
        public string Token
        {
            get;
            set;
        }

        [Category("08. Token label")]
        [DisplayName("Present in URI:")]
        public bool TokenPresent
        {
            get;
            set;
        }

        #endregion

        #region Token PIN definition

        [Category("09. Token PIN value")]
        [DisplayName("Attribute value:")]
        public string PinValue
        {
            get;
            set;
        }

        [Category("09. Token PIN value")]
        [DisplayName("Present in URI:")]
        public bool PinValuePresent
        {
            get;
            set;
        }

        [Category("10. Token PIN source")]
        [DisplayName("Attribute value:")]
        public string PinSource
        {
            get;
            set;
        }

        [Category("10. Token PIN source")]
        [DisplayName("Present in URI:")]
        public bool PinSourcePresent
        {
            get;
            set;
        }

        #endregion

        #region Object definition

        [Category("11. Object type (CKA_CLASS)")]
        [DisplayName("Attribute value:")]
        public CKO? Type
        {
            get;
            set;
        }

        [Category("11. Object type (CKA_CLASS)")]
        [DisplayName("Present in URI:")]
        public bool TypePresent
        {
            get;
            set;
        }

        [Category("12. Object label (CKA_LABEL)")]
        [DisplayName("Attribute value:")]
        public string Object
        {
            get;
            set;
        }

        [Category("12. Object label (CKA_LABEL)")]
        [DisplayName("Present in URI:")]
        public bool ObjectPresent
        {
            get;
            set;
        }

        [Category("13. Object identifier (CKA_ID)")]
        [DisplayName("Attribute value:")]
        public string Id
        {
            get;
            set;
        }

        [Category("13. Object identifier (CKA_ID)")]
        [DisplayName("Present in URI:")]
        public bool IdPresent
        {
            get;
            set;
        }
        
        #endregion

        public Pkcs11Uri()
        {
            // Module definition
            this.ModulePath = null;
            this.ModulePathPresent = false;
            this.ModuleName = null;
            this.ModuleNamePresent = false;

            // Library definition
            this.LibraryManufacturer = null;
            this.LibraryManufacturerPresent = false;
            this.LibraryDescription = null;
            this.LibraryDescriptionPresent = false;
            this.LibraryVersion = null;
            this.LibraryVersionPresent = false;

            // Token definition
            this.Manufacturer = null;
            this.ManufacturerPresent = false;
            this.Model = null;
            this.ModelPresent = false;
            this.Serial = null;
            this.SerialPresent = false;
            this.Token = null;
            this.TokenPresent = false;

            // Token PIN definition
            this.PinValue = null;
            this.PinSourcePresent = false;
            this.PinSource = null;
            this.PinSourcePresent = false;

            // Object definition
            this.Type = null;
            this.TypePresent = false;
            this.Object = null;
            this.ObjectPresent = false;
            this.Id = null;
            this.IdPresent = false;
        }

        public Pkcs11Uri(Pkcs11Library pkcs11Library, Pkcs11Slot pkcs11Slot, Pkcs11ObjectInfo pkcs11ObjectInfo)
        {
            // Module definition
            this.ModulePath = pkcs11Library.Info.LibraryPath;
            this.ModulePathPresent = true;
            this.ModuleName = null;
            this.ModuleNamePresent = false;

            // Library definition
            this.LibraryManufacturer = pkcs11Library.Info.ManufacturerId;
            this.LibraryManufacturerPresent = false;
            this.LibraryDescription = pkcs11Library.Info.LibraryDescription;
            this.LibraryDescriptionPresent = false;
            this.LibraryVersion = pkcs11Library.Info.LibraryVersion;
            this.LibraryVersionPresent = false;

            // Token definition
            this.Manufacturer = pkcs11Slot.TokenInfo.ManufacturerId;
            this.ManufacturerPresent = false;
            this.Model = pkcs11Slot.TokenInfo.Model;
            this.ModelPresent = false;
            this.Serial = pkcs11Slot.TokenInfo.SerialNumber;
            this.SerialPresent = true;
            this.Token = pkcs11Slot.TokenInfo.Label;
            this.TokenPresent = true;

            // Token PIN definition
            this.PinValue = null;
            this.PinSourcePresent = false;
            this.PinSource = null;
            this.PinSourcePresent = false;

            // Object definition
            this.Type = (CKO)pkcs11Slot.LoadObjectAttributes(pkcs11ObjectInfo, new List<ulong> { (ulong)CKA.CKA_CLASS })[0].GetValueAsUlong();
            this.TypePresent = true;

            this.Object = pkcs11Slot.LoadObjectAttributes(pkcs11ObjectInfo, new List<ulong> { (ulong)CKA.CKA_LABEL })[0].GetValueAsString();
            this.ObjectPresent = true;
            
            if (this.Type == CKO.CKO_DATA)
            {
                this.Id = null;
                this.IdPresent = false;
            }
            else
            {
                this.Id = StringUtils.BytesToHexString(pkcs11Slot.LoadObjectAttributes(pkcs11ObjectInfo, new List<ulong> { (ulong)CKA.CKA_ID })[0].GetValueAsByteArray());
                this.IdPresent = true;
            }
        }

        public override string ToString()
        {
            Pkcs11UriBuilder pkcs11UriBuilder = new Pkcs11UriBuilder(true);

            // Module definition
            pkcs11UriBuilder.ModulePath = (!this.ModulePathPresent) ? null : this.ModulePath;
            pkcs11UriBuilder.ModuleName = (!this.ModuleNamePresent) ? null : this.ModuleName;

            // Library definition
            pkcs11UriBuilder.LibraryManufacturer = (!this.LibraryManufacturerPresent) ? null : this.LibraryManufacturer;
            pkcs11UriBuilder.LibraryDescription = (!this.LibraryDescriptionPresent) ? null : this.LibraryDescription;
            pkcs11UriBuilder.LibraryVersion = (!this.LibraryVersionPresent) ? null : this.LibraryVersion;

            // Token definition
            pkcs11UriBuilder.Manufacturer = (!this.ManufacturerPresent) ? null : this.Manufacturer;
            pkcs11UriBuilder.Model = (!this.ModelPresent) ? null : this.Model;
            pkcs11UriBuilder.Serial = (!this.SerialPresent) ? null : this.Serial;
            pkcs11UriBuilder.Token = (!this.TokenPresent) ? null : this.Token;

            // Token PIN definition
            pkcs11UriBuilder.PinValue = (!this.PinValuePresent) ? null : this.PinValue;
            pkcs11UriBuilder.PinSource = (!this.PinSourcePresent) ? null : this.PinSource;

            // Object definition
            pkcs11UriBuilder.Type = (!this.TypePresent) ? (CKO?)null : this.Type;
            pkcs11UriBuilder.Object = (!this.ObjectPresent) ? null : this.Object;
            pkcs11UriBuilder.Id = (!this.IdPresent) ? null : StringUtils.HexStringToBytes(this.Id);

            return pkcs11UriBuilder.ToString();
        }
    }
}

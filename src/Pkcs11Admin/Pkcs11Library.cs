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

using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;
using System;
using System.Collections.Generic;

namespace Net.Pkcs11Admin
{
    public class Pkcs11Library : IDisposable
    {
        private bool _disposed = false;

        private string _path = null;

        private Pkcs11 _pkcs11 = null;

        public Pkcs11LibraryInfo Info
        {
            get;
            private set;
        }

        public List<Pkcs11Slot> Slots
        {
            get;
            private set;
        }

        public Pkcs11Library(string libraryPath, string loggerPath = null)
        {
            _path = libraryPath;

            try
            {
                _pkcs11 = new Pkcs11(loggerPath ?? libraryPath, true);
            }
            catch (Pkcs11Exception ex)
            {
                if (ex.RV == CKR.CKR_CANT_LOCK)
                    _pkcs11 = new Pkcs11(loggerPath ?? libraryPath, false);
                else
                    throw;
            }
            
            Info = GetPkcs11LibraryInfo();
            Slots = GetPkcs11Slots();
        }

        private Pkcs11LibraryInfo GetPkcs11LibraryInfo()
        {
            return new Pkcs11LibraryInfo(_path, _pkcs11.GetInfo());
        }

        private List<Pkcs11Slot> GetPkcs11Slots()
        {
            List<Pkcs11Slot> slots = new List<Pkcs11Slot>();

            foreach (Slot slot in _pkcs11.GetSlotList(false))
                slots.Add(new Pkcs11Slot(slot));

            return slots;
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    // Dispose managed objects

                    if (_pkcs11 != null)
                    {
                        _pkcs11.Dispose();
                        _pkcs11 = null;
                    }
                }

                // Dispose unmanaged objects

                _disposed = true;
            }
        }

        ~Pkcs11Library()
        {
            Dispose(false);
        }

        #endregion
    }
}

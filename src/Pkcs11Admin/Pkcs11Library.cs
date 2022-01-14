﻿/*
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
using System;
using System.Collections.Generic;

namespace Net.Pkcs11Admin
{
    public class Pkcs11Library : IDisposable
    {
        private bool _disposed = false;

        private string _path = null;

        private IPkcs11Library _pkcs11Library = null;

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

            Pkcs11InteropFactories factories = Pkcs11Admin.Instance.Factories;

            try
            {
                _pkcs11Library = factories.Pkcs11LibraryFactory.LoadPkcs11Library(factories, loggerPath ?? libraryPath, AppType.MultiThreaded);
            }
            catch (Pkcs11Exception ex)
            {
                if (ex.RV == CKR.CKR_CANT_LOCK)
                    _pkcs11Library = factories.Pkcs11LibraryFactory.LoadPkcs11Library(factories, loggerPath ?? libraryPath, AppType.SingleThreaded);
                else
                    throw;
            }
            
            Info = GetPkcs11LibraryInfo();
            Slots = GetPkcs11Slots();
        }

        private Pkcs11LibraryInfo GetPkcs11LibraryInfo()
        {
            return new Pkcs11LibraryInfo(_path, _pkcs11Library.GetInfo());
        }

        private List<Pkcs11Slot> GetPkcs11Slots()
        {
            List<Pkcs11Slot> slots = new List<Pkcs11Slot>();

            foreach (ISlot slot in _pkcs11Library.GetSlotList(SlotsType.WithOrWithoutTokenPresent))
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

                    if (Slots != null)
                    {
                        for (int i = 0; i < Slots.Count; i++)
                        {
                            Slots[i].Dispose();
                            Slots[i] = null;
                        }
                    }

                    if (_pkcs11Library != null)
                    {
                        _pkcs11Library.Dispose();
                        _pkcs11Library = null;
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

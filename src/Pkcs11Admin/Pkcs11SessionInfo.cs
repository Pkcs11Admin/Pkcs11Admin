/*
 *  Pkcs11Admin - GUI tool for administration of PKCS#11 enabled devices
 *  Copyright (c) 2014-2019 Jaroslav Imrich <jimrich@jimrich.sk>
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

namespace Net.Pkcs11Admin
{
    public class Pkcs11SessionInfo
    {
        public bool UserLoggedIn
        {
            get;
            private set;
        }

        public bool UserCanLogin
        {
            get;
            private set;
        }

        public bool UserCanLoginProtected
        {
            get;
            private set;
        }

        public bool UserCanChangePin
        {
            get;
            private set;
        }

        public bool UserCanChangePinProtected
        {
            get;
            private set;
        }

        public bool SoLoggedIn
        {
            get;
            private set;
        }

        public bool SoCanLogin
        {
            get;
            private set;
        }

        public bool SoCanLoginProtected
        {
            get;
            private set;
        }

        public bool SoCanChangePin
        {
            get;
            private set;
        }

        public bool SoCanChangePinProtected
        {
            get;
            private set;
        }

        public bool SoCanSetUserPin
        {
            get;
            private set;
        }

        public bool SoCanSetUserPinProtected
        {
            get;
            private set;
        }

        public bool CanLogout
        {
            get;
            private set;
        }

        public bool CanInitToken
        {
            get;
            private set;
        }

        public bool CanInitTokenProtected
        {
            get;
            private set;
        }

        internal Pkcs11SessionInfo(ISessionInfo sessionInfo, bool protectedAuthenticationPath)
        {
            if (sessionInfo == null)
                throw new ArgumentNullException("sessionInfo");

            switch (sessionInfo.State)
            {
                case CKS.CKS_RO_PUBLIC_SESSION:
                case CKS.CKS_RW_PUBLIC_SESSION:

                    UserLoggedIn = false;
                    UserCanLogin = true;
                    UserCanLoginProtected = protectedAuthenticationPath;
                    UserCanChangePin = false;
                    UserCanChangePinProtected = false;
                    SoLoggedIn = false;
                    SoCanLogin = true;
                    SoCanLoginProtected = protectedAuthenticationPath;
                    SoCanChangePin = false;
                    SoCanChangePinProtected = false;
                    SoCanSetUserPin = false;
                    SoCanSetUserPinProtected = false;
                    CanLogout = false;
                    CanInitToken = true;
                    CanInitTokenProtected = protectedAuthenticationPath;

                    break;

                case CKS.CKS_RO_USER_FUNCTIONS:
                case CKS.CKS_RW_USER_FUNCTIONS:

                    UserLoggedIn = true;
                    UserCanLogin = false;
                    UserCanLoginProtected = false;
                    UserCanChangePin = true;
                    UserCanChangePinProtected = protectedAuthenticationPath;
                    SoLoggedIn = false;
                    SoCanLogin = false;
                    SoCanLoginProtected = false;
                    SoCanChangePin = false;
                    SoCanChangePinProtected = false;
                    SoCanSetUserPin = false;
                    SoCanSetUserPinProtected = false;
                    CanLogout = true;
                    CanInitToken = false;
                    CanInitTokenProtected = false;

                    break;

                case CKS.CKS_RW_SO_FUNCTIONS:

                    UserLoggedIn = false;
                    UserCanLogin = false;
                    UserCanLoginProtected = false;
                    UserCanChangePin = false;
                    UserCanChangePinProtected = false;
                    SoLoggedIn = true;
                    SoCanLogin = false;
                    SoCanLoginProtected = false;
                    SoCanChangePin = true;
                    SoCanChangePinProtected = protectedAuthenticationPath;
                    SoCanSetUserPin = true;
                    SoCanSetUserPinProtected = protectedAuthenticationPath;
                    CanLogout = true;
                    CanInitToken = false;
                    CanInitTokenProtected = false;

                    break;
            }
        }
    }
}

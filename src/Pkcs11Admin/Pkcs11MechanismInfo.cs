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

using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;

namespace Net.Pkcs11Admin
{
    public class Pkcs11MechanismInfo : Pkcs11Info
    {
        public CKM Mechanism
        {
            get;
            private set;
        }

        public ulong MinKeySize
        {
            get;
            private set;
        }

        public ulong MaxKeySize
        {
            get;
            private set;
        }

        public ulong Flags
        {
            get;
            private set;
        }

        public bool Hw
        {
            get;
            private set;
        }

        public bool Encrypt
        {
            get;
            private set;
        }

        public bool Decrypt
        {
            get;
            private set;
        }

        public bool Digest
        {
            get;
            private set;
        }

        public bool Sign
        {
            get;
            private set;
        }

        public bool SignRecover
        {
            get;
            private set;
        }

        public bool Verify
        {
            get;
            private set;
        }

        public bool VerifyRecover
        {
            get;
            private set;
        }

        public bool Generate
        {
            get;
            private set;
        }

        public bool GenerateKeyPair
        {
            get;
            private set;
        }

        public bool Wrap
        {
            get;
            private set;
        }

        public bool Unwrap
        {
            get;
            private set;
        }

        public bool Derive
        {
            get;
            private set;
        }

        public bool Extension
        {
            get;
            private set;
        }

        public bool EcFp
        {
            get;
            private set;
        }

        public bool EcF2m
        {
            get;
            private set;
        }

        public bool EcEcParameters
        {
            get;
            private set;
        }

        public bool EcNamedCurve
        {
            get;
            private set;
        }

        public bool EcUncompress
        {
            get;
            private set;
        }

        public bool EcCompress
        {
            get;
            private set;
        }

        internal Pkcs11MechanismInfo(CKM mechanism, IMechanismInfo mechanismInfo)
        {
            Mechanism = mechanism;
            MinKeySize = mechanismInfo.MinKeySize;
            MaxKeySize = mechanismInfo.MaxKeySize;
            Flags = mechanismInfo.MechanismFlags.Flags;
            Hw = mechanismInfo.MechanismFlags.Hw;
            Encrypt = mechanismInfo.MechanismFlags.Encrypt;
            Decrypt = mechanismInfo.MechanismFlags.Decrypt;
            Digest = mechanismInfo.MechanismFlags.Digest;
            Sign = mechanismInfo.MechanismFlags.Sign;
            SignRecover = mechanismInfo.MechanismFlags.SignRecover;
            Verify = mechanismInfo.MechanismFlags.Verify;
            VerifyRecover = mechanismInfo.MechanismFlags.VerifyRecover;
            Generate = mechanismInfo.MechanismFlags.Generate;
            GenerateKeyPair = mechanismInfo.MechanismFlags.GenerateKeyPair;
            Wrap = mechanismInfo.MechanismFlags.Wrap;
            Unwrap = mechanismInfo.MechanismFlags.Unwrap;
            Derive = mechanismInfo.MechanismFlags.Derive;
            Extension = mechanismInfo.MechanismFlags.Extension;
            EcFp = mechanismInfo.MechanismFlags.EcFp;
            EcF2m = mechanismInfo.MechanismFlags.EcF2m;
            EcEcParameters = mechanismInfo.MechanismFlags.EcEcParameters;
            EcNamedCurve = mechanismInfo.MechanismFlags.EcNamedCurve;
            EcUncompress = mechanismInfo.MechanismFlags.EcUncompress;
            EcCompress = mechanismInfo.MechanismFlags.EcCompress;
        }
    }
}

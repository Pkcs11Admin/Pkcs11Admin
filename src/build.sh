#!/bin/sh

PLATFORM=AnyCPU
OUTDIR=Pkcs11Admin-$PLATFORM

# Build the source code
xbuild /property:Platform=$PLATFORM /property:Configuration=Release /t:Clean Pkcs11Admin.sln || exit
xbuild /property:Platform=$PLATFORM /property:Configuration=Release /t:Build Pkcs11Admin.sln || exit

# Prepare output directory
rm -Rf $OUTDIR || exit
mkdir -p $OUTDIR/LICENSE || exit

# Copy binaries
cp Pkcs11Admin.WinForms/bin/$PLATFORM/Release/Be.Windows.Forms.HexBox.dll $OUTDIR || exit
cp lib/pkcs11-logger/pkcs11-logger-x86.so $OUTDIR || exit
cp lib/pkcs11-logger/pkcs11-logger-x64.so $OUTDIR || exit
cp Pkcs11Admin.WinForms/bin/$PLATFORM/Release/Pkcs11Admin.dll $OUTDIR || exit
cp Pkcs11Admin.WinForms/bin/$PLATFORM/Release/Pkcs11Admin.WinForms.exe $OUTDIR || exit
cp Pkcs11Admin.WinForms/bin/$PLATFORM/Release/Pkcs11Admin.WinForms.exe.config $OUTDIR || exit
cp Pkcs11Admin.WinForms/bin/$PLATFORM/Release/Pkcs11Interop.dll $OUTDIR || exit
cp Pkcs11Admin.WinForms/bin/$PLATFORM/Release/Pkcs11Interop.URI.dll $OUTDIR || exit

# Copy licenses
cp packages/Be.Windows.Forms.HexBox.*/LICENSE.txt $OUTDIR/LICENSE/Be.Windows.Forms.HexBox.txt || exit
cp lib/pkcs11-logger/license.txt $OUTDIR/LICENSE/pkcs11-logger.txt || exit
cp LICENSE.txt $OUTDIR/LICENSE/Pkcs11Admin.txt || exit
cp packages/Pkcs11Interop.*/license.txt $OUTDIR/LICENSE/Pkcs11Interop.txt || exit
cp lib/Pkcs11Interop.URI/license.txt $OUTDIR/LICENSE/Pkcs11Interop.URI.txt || exit


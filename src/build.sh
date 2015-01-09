#!/bin/sh

set -e

PLATFORM=AnyCPU
OUTDIR=Pkcs11Admin-$PLATFORM

# Build the source code
xbuild /property:Platform=$PLATFORM /property:Configuration=Release /t:Clean Pkcs11Admin.sln
xbuild /property:Platform=$PLATFORM /property:Configuration=Release /t:Build Pkcs11Admin.sln

# Prepare output directory
rm -Rf $OUTDIR
mkdir -p $OUTDIR/LICENSE

# Copy binaries
cp Pkcs11Admin.WinForms/bin/$PLATFORM/Release/Be.Windows.Forms.HexBox.dll $OUTDIR
cp lib/pkcs11-logger/pkcs11-logger-x86.so $OUTDIR
cp lib/pkcs11-logger/pkcs11-logger-x64.so $OUTDIR
cp Pkcs11Admin.WinForms/bin/$PLATFORM/Release/Pkcs11Admin.dll $OUTDIR
cp Pkcs11Admin.WinForms/bin/$PLATFORM/Release/Pkcs11Admin.WinForms.exe $OUTDIR
cp Pkcs11Admin.WinForms/bin/$PLATFORM/Release/Pkcs11Admin.WinForms.exe.config $OUTDIR
cp Pkcs11Admin.WinForms/bin/$PLATFORM/Release/Pkcs11Interop.dll $OUTDIR
cp Pkcs11Admin.WinForms/bin/$PLATFORM/Release/Pkcs11Interop.URI.dll $OUTDIR

# Copy licenses
cp packages/Be.Windows.Forms.HexBox.*/LICENSE.txt $OUTDIR/LICENSE/Be.Windows.Forms.HexBox.txt
cp lib/pkcs11-logger/license.txt $OUTDIR/LICENSE/pkcs11-logger.txt
cp LICENSE.txt $OUTDIR/LICENSE/Pkcs11Admin.txt
cp packages/Pkcs11Interop.*/license.txt $OUTDIR/LICENSE/Pkcs11Interop.txt
cp lib/Pkcs11Interop.URI/license.txt $OUTDIR/LICENSE/Pkcs11Interop.URI.txt


#!/bin/sh

set -e

# Build for x86 platform
xbuild /property:Platform=x86 /property:Configuration=Release /t:Clean Pkcs11Admin.sln
xbuild /property:Platform=x86 /property:Configuration=Release /t:Build Pkcs11Admin.sln

# Build for AnyCPU platform
xbuild /property:Platform=AnyCPU /property:Configuration=Release /t:Clean Pkcs11Admin.sln
xbuild /property:Platform=AnyCPU /property:Configuration=Release /t:Build Pkcs11Admin.sln

# Prepare output directory
OUTDIR=Pkcs11Admin-Release
rm -Rf $OUTDIR
mkdir $OUTDIR

# Copy binaries to the output directory
cp Pkcs11Admin.WinForms/bin/AnyCPU/Release/Be.Windows.Forms.HexBox.dll $OUTDIR
cp Pkcs11Admin.WinForms/bin/AnyCPU/Release/Pkcs11Interop.dll $OUTDIR
cp packages/Pkcs11Interop.*/lib/net40/Pkcs11Interop.dll.config $OUTDIR
cp Pkcs11Admin.WinForms/bin/AnyCPU/Release/Pkcs11Interop.URI.dll $OUTDIR
cp Pkcs11Admin.WinForms/bin/AnyCPU/Release/Pkcs11Admin.dll $OUTDIR
cp Pkcs11Admin.WinForms/bin/AnyCPU/Release/Pkcs11Admin.WinForms.exe $OUTDIR
cp Pkcs11Admin.WinForms/bin/AnyCPU/Release/Pkcs11Admin.WinForms.exe.config $OUTDIR
# Following executable is useful only to force 32-bit mode on 64-bit Windows. It is useless on other platforms.
cp Pkcs11Admin.WinForms/bin/x86/Release/Pkcs11Admin.WinForms.exe $OUTDIR/Pkcs11Admin.WinForms.x86.exe
cp Pkcs11Admin.WinForms/bin/x86/Release/Pkcs11Admin.WinForms.exe.config $OUTDIR/Pkcs11Admin.WinForms.x86.exe.config


# Copy PKCS11-LOGGER to the output directory
mkdir $OUTDIR/pkcs11-logger
cp lib/pkcs11-logger/pkcs11-logger-*.* $OUTDIR/pkcs11-logger/

# Copy licenses to the output directory
mkdir $OUTDIR/LICENSE
cp packages/Be.Windows.Forms.HexBox.*/LICENSE.txt $OUTDIR/LICENSE/Be.Windows.Forms.HexBox.txt
cp lib/pkcs11-logger/license.txt $OUTDIR/LICENSE/pkcs11-logger.txt
cp LICENSE.txt $OUTDIR/LICENSE/Pkcs11Admin.txt
cp packages/Pkcs11Interop.*/license.txt $OUTDIR/LICENSE/Pkcs11Interop.txt
cp lib/Pkcs11Interop.URI/license.txt $OUTDIR/LICENSE/Pkcs11Interop.URI.txt

echo "*** BUILD SUCCESSFUL ***"
exit 0


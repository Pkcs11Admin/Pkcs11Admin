#!/bin/sh

set -e

# Build for x86 platform
xbuild /property:Platform=x86 /property:Configuration=Release /t:Clean ../../src/Pkcs11Admin.sln
xbuild /property:Platform=x86 /property:Configuration=Release /t:Build ../../src/Pkcs11Admin.sln

# Build for x64 platform
xbuild /property:Platform=x64 /property:Configuration=Release /t:Clean ../../src/Pkcs11Admin.sln
xbuild /property:Platform=x64 /property:Configuration=Release /t:Build ../../src/Pkcs11Admin.sln

# Build for AnyCPU platform
xbuild /property:Platform=AnyCPU /property:Configuration=Release /t:Clean ../../src/Pkcs11Admin.sln
xbuild /property:Platform=AnyCPU /property:Configuration=Release /t:Build ../../src/Pkcs11Admin.sln

# Prepare output directory
OUTDIR=Pkcs11Admin-Release
rm -Rf $OUTDIR
mkdir $OUTDIR
mkdir $OUTDIR/license
mkdir $OUTDIR/pkcs11-logger

# Copy binaries to the output directory
cp ../../src/Pkcs11Admin.WinForms/bin/AnyCPU/Release/Asn1Net.Forms.TreeView.dll $OUTDIR
cp ../../src/Pkcs11Admin.WinForms/bin/AnyCPU/Release/Asn1Net.Reader.dll $OUTDIR
cp ../../src/Pkcs11Admin.WinForms/bin/AnyCPU/Release/Be.Windows.Forms.HexBox.dll $OUTDIR
cp ../../src/Pkcs11Admin.WinForms/bin/AnyCPU/Release/Pkcs11Admin.dll $OUTDIR
cp ../../src/Pkcs11Admin.WinForms/bin/AnyCPU/Release/Pkcs11Interop.dll $OUTDIR
cp ../../src/packages/Pkcs11Interop.*/lib/net40/Pkcs11Interop.dll.config $OUTDIR
cp ../../src/Pkcs11Admin.WinForms/bin/x86/Release/Pkcs11Admin.WinForms.exe $OUTDIR/Pkcs11Admin-x86.exe
cp ../../src/Pkcs11Admin.WinForms/bin/x86/Release/Pkcs11Admin.WinForms.exe.config $OUTDIR/Pkcs11Admin-x86.exe.config
cp ../../src/Pkcs11Admin.WinForms/bin/x64/Release/Pkcs11Admin.WinForms.exe $OUTDIR/Pkcs11Admin-x64.exe
cp ../../src/Pkcs11Admin.WinForms/bin/x64/Release/Pkcs11Admin.WinForms.exe.config $OUTDIR/Pkcs11Admin-x64.exe.config
cp ../../src/lib/pkcs11-logger/pkcs11-logger-*.* $OUTDIR/pkcs11-logger/

# Copy licenses to the output directory
cp ../../src/packages/Asn1Net.Forms.TreeView.*/license.txt $OUTDIR/license/Asn1Net.Forms.TreeView.txt
cp ../../src/packages/Asn1Net.Reader.*/license.txt $OUTDIR/license/Asn1Net.Reader.txt
cp ../../src/packages/Be.Windows.Forms.HexBox.*/LICENSE.txt $OUTDIR/license/Be.Windows.Forms.HexBox.txt
cp ../../src/LICENSE.txt $OUTDIR/license/Pkcs11Admin.txt
cp ../../src/packages/Pkcs11Interop.*/license.txt $OUTDIR/license/Pkcs11Interop.txt
cp ../../src/lib/pkcs11-logger/license.txt $OUTDIR/license/pkcs11-logger.txt

echo "*** BUILD SUCCESSFUL ***"
exit 0


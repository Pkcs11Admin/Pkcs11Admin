setlocal

@rem Initialize build environment of Visual Studio 2015
call "c:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\Tools\vsvars32.bat"

@rem Build for x86 platform
msbuild ..\..\src\Pkcs11Admin.sln /p:Configuration=Release /p:Platform=x86 /target:Clean || exit /b 1
msbuild ..\..\src\Pkcs11Admin.sln /p:Configuration=Release /p:Platform=x86 /target:Build || exit /b 1

@rem Build for x64 platform
msbuild ..\..\src\Pkcs11Admin.sln /p:Configuration=Release /p:Platform=x64 /target:Clean || exit /b 1
msbuild ..\..\src\Pkcs11Admin.sln /p:Configuration=Release /p:Platform=x64 /target:Build || exit /b 1

@rem Build for AnyCPU platform
msbuild ..\..\src\Pkcs11Admin.sln /p:Configuration=Release /p:Platform=AnyCPU /target:Clean || exit /b 1
msbuild ..\..\src\Pkcs11Admin.sln /p:Configuration=Release /p:Platform=AnyCPU /target:Build || exit /b 1

endlocal

setlocal

@rem Prepare output directory
set OUTDIR=Pkcs11Admin-Release
rmdir /S /Q %OUTDIR%
mkdir %OUTDIR% || exit /b 1
mkdir %OUTDIR%\license || exit /b 1
mkdir %OUTDIR%\pkcs11-logger || exit /b 1

@rem Copy binaries to the output directory
copy ..\..\src\Pkcs11Admin.WinForms\bin\AnyCPU\Release\Asn1Net.Forms.TreeView.dll %OUTDIR% || exit /b 1
copy ..\..\src\Pkcs11Admin.WinForms\bin\AnyCPU\Release\Asn1Net.Reader.dll %OUTDIR% || exit /b 1
copy ..\..\src\Pkcs11Admin.WinForms\bin\AnyCPU\Release\Be.Windows.Forms.HexBox.dll %OUTDIR% || exit /b 1
copy ..\..\src\Pkcs11Admin.WinForms\bin\AnyCPU\Release\Pkcs11Admin.dll %OUTDIR% || exit /b 1
copy ..\..\src\Pkcs11Admin.WinForms\bin\AnyCPU\Release\Pkcs11Interop.dll %OUTDIR% || exit /b 1
copy ..\..\src\lib\Pkcs11Interop\Pkcs11Interop.dll.config %OUTDIR% || exit /b 1
copy ..\..\src\Pkcs11Admin.WinForms\bin\x86\Release\Pkcs11Admin.WinForms.exe %OUTDIR%\Pkcs11Admin-x86.exe || exit /b 1
copy ..\..\src\Pkcs11Admin.WinForms\bin\x86\Release\Pkcs11Admin.WinForms.exe.config %OUTDIR%\Pkcs11Admin-x86.exe.config || exit /b 1
copy ..\..\src\Pkcs11Admin.WinForms\bin\x64\Release\Pkcs11Admin.WinForms.exe %OUTDIR%\Pkcs11Admin-x64.exe || exit /b 1
copy ..\..\src\Pkcs11Admin.WinForms\bin\x64\Release\Pkcs11Admin.WinForms.exe.config %OUTDIR%\Pkcs11Admin-x64.exe.config || exit /b 1
copy ..\..\src\lib\pkcs11-logger\pkcs11-logger-*.* %OUTDIR%\pkcs11-logger\ || exit /b 1
copy ..\..\src\Pkcs11Admin.WinForms\bin\AnyCPU\Release\crypto.dll %OUTDIR% || exit /b 1

@rem Copy licenses to the output directory
copy ..\..\src\lib\Asn1Net.Forms.TreeView\license.txt %OUTDIR%\license\Asn1Net.Forms.TreeView.txt || exit /b 1
copy ..\..\src\lib\Asn1Net.Reader\license.txt %OUTDIR%\license\Asn1Net.Reader.txt || exit /b 1
copy ..\..\src\lib\Be.Windows.Forms.HexBox\LICENSE.txt %OUTDIR%\license\Be.Windows.Forms.HexBox.txt || exit /b 1
copy ..\..\src\LICENSE.txt %OUTDIR%\license\Pkcs11Admin.txt || exit /b 1
copy ..\..\src\lib\Pkcs11Interop\license.txt %OUTDIR%\license\Pkcs11Interop.txt || exit /b 1
copy ..\..\src\lib\pkcs11-logger\license.txt %OUTDIR%\license\pkcs11-logger.txt || exit /b 1
copy ..\..\src\lib\Portable.BouncyCastle\license.txt %OUTDIR%\license\crypto.txt || exit /b 1

endlocal

@echo *** BUILD SUCCESSFUL ***
@exit /b 0

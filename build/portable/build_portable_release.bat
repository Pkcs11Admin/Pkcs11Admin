@setlocal

@rem Initialize Visual Studio build environment:
@rem - Visual Studio 2017 Community/Professional/Enterprise is the preferred option
@rem - Visual Studio 2015 is the fallback option (which might or might not work)
@set tools=
@set tmptools="c:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\Tools\vsvars32.bat"
@if exist %tmptools% set tools=%tmptools%
@set tmptools="c:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\Tools\VsMSBuildCmd.bat"
@if exist %tmptools% set tools=%tmptools%
@set tmptools="c:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\Tools\VsMSBuildCmd.bat"
@if exist %tmptools% set tools=%tmptools%
@set tmptools="c:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\Tools\VsMSBuildCmd.bat"
@if exist %tmptools% set tools=%tmptools%
@if not defined tools goto :error
call %tools%
@echo on

@rem Build for x86 platform
msbuild ..\..\src\Pkcs11Admin.sln /p:Configuration=Release /p:Platform=x86 /target:Clean || goto :error
msbuild ..\..\src\Pkcs11Admin.sln /p:Configuration=Release /p:Platform=x86 /target:Build || goto :error

@rem Build for x64 platform
msbuild ..\..\src\Pkcs11Admin.sln /p:Configuration=Release /p:Platform=x64 /target:Clean || goto :error
msbuild ..\..\src\Pkcs11Admin.sln /p:Configuration=Release /p:Platform=x64 /target:Build || goto :error

@rem Build for AnyCPU platform
msbuild ..\..\src\Pkcs11Admin.sln /p:Configuration=Release /p:Platform=AnyCPU /target:Clean || goto :error
msbuild ..\..\src\Pkcs11Admin.sln /p:Configuration=Release /p:Platform=AnyCPU /target:Build || goto :error

@rem Prepare output directory
set OUTDIR=Pkcs11Admin-Release
rmdir /S /Q %OUTDIR%
mkdir %OUTDIR% || goto :error
mkdir %OUTDIR%\license || goto :error
mkdir %OUTDIR%\pkcs11-logger || goto :error

@rem Copy binaries to the output directory
copy ..\..\src\Pkcs11Admin.WinForms\bin\AnyCPU\Release\Asn1Net.Forms.TreeView.dll %OUTDIR% || goto :error
copy ..\..\src\Pkcs11Admin.WinForms\bin\AnyCPU\Release\Asn1Net.Reader.dll %OUTDIR% || goto :error
copy ..\..\src\Pkcs11Admin.WinForms\bin\AnyCPU\Release\Be.Windows.Forms.HexBox.dll %OUTDIR% || goto :error
copy ..\..\src\Pkcs11Admin.WinForms\bin\AnyCPU\Release\Pkcs11Admin.dll %OUTDIR% || goto :error
copy ..\..\src\Pkcs11Admin.WinForms\bin\AnyCPU\Release\Pkcs11Interop.dll %OUTDIR% || goto :error
copy ..\..\src\Pkcs11Admin.WinForms\bin\x86\Release\Pkcs11Admin.WinForms.exe %OUTDIR%\Pkcs11Admin-x86.exe || goto :error
copy ..\..\src\Pkcs11Admin.WinForms\bin\x86\Release\Pkcs11Admin.WinForms.exe.config %OUTDIR%\Pkcs11Admin-x86.exe.config || goto :error
copy ..\..\src\Pkcs11Admin.WinForms\bin\x64\Release\Pkcs11Admin.WinForms.exe %OUTDIR%\Pkcs11Admin-x64.exe || goto :error
copy ..\..\src\Pkcs11Admin.WinForms\bin\x64\Release\Pkcs11Admin.WinForms.exe.config %OUTDIR%\Pkcs11Admin-x64.exe.config || goto :error
copy ..\..\src\lib\pkcs11-logger\pkcs11-logger-*.* %OUTDIR%\pkcs11-logger\ || goto :error
copy ..\..\src\Pkcs11Admin.WinForms\bin\AnyCPU\Release\BouncyCastle.Crypto.dll %OUTDIR% || goto :error

@rem Copy scripts to the output directory
copy Pkcs11Admin-x86.sh %OUTDIR%\Pkcs11Admin-x86.sh || goto :error
copy Pkcs11Admin-x64.sh %OUTDIR%\Pkcs11Admin-x64.sh || goto :error

@rem Copy licenses to the output directory
copy license\*.* %OUTDIR%\license\ || goto :error

@endlocal

@echo *** BUILD SUCCESSFUL ***
@endlocal
@exit /b 0

:error
@echo *** BUILD FAILED ***
@endlocal
@exit /b 1

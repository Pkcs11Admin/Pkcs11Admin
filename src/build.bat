@rem Build the source code
setlocal
@rem Initialize build environment of Visual Studio 2013
call "C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\Tools\vsvars32.bat" || @goto :error
@rem Build for x86 platform
msbuild Pkcs11Admin.sln /p:Configuration=Release /p:Platform=x86 /target:Clean || exit /b 1
msbuild Pkcs11Admin.sln /p:Configuration=Release /p:Platform=x86 /target:Build || exit /b 1
@rem Build for AnyCPU platform
msbuild Pkcs11Admin.sln /p:Configuration=Release /p:Platform=AnyCPU /target:Clean || exit /b 1
msbuild Pkcs11Admin.sln /p:Configuration=Release /p:Platform=AnyCPU /target:Build || exit /b 1
endlocal

@rem Prepare output directory
set OUTDIR=Pkcs11Admin-Release
rmdir /S /Q %OUTDIR%
mkdir %OUTDIR% || exit /b 1

@rem Copy binaries to the output directory
copy Pkcs11Admin.WinForms\bin\AnyCPU\Release\Be.Windows.Forms.HexBox.dll %OUTDIR% || exit /b 1
copy Pkcs11Admin.WinForms\bin\AnyCPU\Release\Pkcs11Interop.dll %OUTDIR% || exit /b 1
copy Pkcs11Admin.WinForms\bin\AnyCPU\Release\Pkcs11Interop.URI.dll %OUTDIR% || exit /b 1
copy Pkcs11Admin.WinForms\bin\AnyCPU\Release\Pkcs11Admin.dll %OUTDIR% || exit /b 1
copy Pkcs11Admin.WinForms\bin\AnyCPU\Release\Pkcs11Admin.WinForms.exe %OUTDIR% || exit /b 1
copy Pkcs11Admin.WinForms\bin\AnyCPU\Release\Pkcs11Admin.WinForms.exe.config %OUTDIR% || exit /b 1
@rem Following executable is useful only to force 32-bit mode on 64-bit Windows. It is useless on other platforms.
copy Pkcs11Admin.WinForms\bin\x86\Release\Pkcs11Admin.WinForms.exe %OUTDIR%\Pkcs11Admin.WinForms.x86.exe || exit /b 1
copy Pkcs11Admin.WinForms\bin\x86\Release\Pkcs11Admin.WinForms.exe.config %OUTDIR%\Pkcs11Admin.WinForms.x86.exe.config || exit /b 1

@rem Copy PKCS11-LOGGER to the output directory
mkdir %OUTDIR%\pkcs11-logger || exit /b 1
copy lib\pkcs11-logger\pkcs11-logger-*.* %OUTDIR%\pkcs11-logger\ || exit /b 1

@rem Copy licenses to the output directory
mkdir %OUTDIR%\LICENSE || exit /b 1
pushd packages\Be.Windows.Forms.HexBox.* || exit /b 1
copy LICENSE.txt ..\..\%OUTDIR%\LICENSE\Be.Windows.Forms.HexBox.txt || exit /b 1
popd || exit /b 1
copy lib\pkcs11-logger\license.txt %OUTDIR%\LICENSE\pkcs11-logger.txt || exit /b 1
copy LICENSE.txt %OUTDIR%\LICENSE\Pkcs11Admin.txt || exit /b 1
pushd packages\Pkcs11Interop.* || exit /b 1
copy license.txt ..\..\%OUTDIR%\LICENSE\Pkcs11Interop.txt || exit /b 1
popd || exit /b 1
copy lib\Pkcs11Interop.URI\license.txt %OUTDIR%\LICENSE\Pkcs11Interop.URI.txt || exit /b 1

@echo *** BUILD SUCCESSFUL ***
@exit /b 0

call "C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\Tools\vsvars32.bat" || @goto :error
call:BuildPkcs11Admin x86 || @goto :error
call:BuildPkcs11Admin x64 || @goto :error
@goto :success


:error
@echo BUILD FAILED !!!
@exit /b 1


:success
@echo BUILD SUCCEEDED !!!
@exit /b 0


:BuildPkcs11Admin

msbuild Pkcs11Admin.sln /p:Configuration=Release /p:Platform=%1 /target:Clean || exit /b 1
msbuild Pkcs11Admin.sln /p:Configuration=Release /p:Platform=%1 /target:Build || exit /b 1

rmdir /S /Q Pkcs11Admin-%1
mkdir Pkcs11Admin-%1 || exit /b 1

copy Pkcs11Admin.WinForms\bin\%1\Release\Be.Windows.Forms.HexBox.dll Pkcs11Admin-%1 || exit /b 1
copy lib\pkcs11-logger\pkcs11-logger-%1.dll Pkcs11Admin-%1 || exit /b 1
copy lib\pkcs11-logger\pkcs11-logger-%1.dylib Pkcs11Admin-%1 || exit /b 1
copy lib\pkcs11-logger\pkcs11-logger-%1.so Pkcs11Admin-%1 || exit /b 1
copy Pkcs11Admin.WinForms\bin\%1\Release\Pkcs11Admin.dll Pkcs11Admin-%1 || exit /b 1
copy Pkcs11Admin.WinForms\bin\%1\Release\Pkcs11Admin.WinForms.exe Pkcs11Admin-%1 || exit /b 1
copy Pkcs11Admin.WinForms\bin\%1\Release\Pkcs11Admin.WinForms.exe.config Pkcs11Admin-%1 || exit /b 1
copy Pkcs11Admin.WinForms\bin\%1\Release\Pkcs11Interop.dll Pkcs11Admin-%1 || exit /b 1
copy Pkcs11Admin.WinForms\bin\%1\Release\Pkcs11Interop.URI.dll Pkcs11Admin-%1 || exit /b 1

mkdir Pkcs11Admin-%1\LICENSE || exit /b 1
pushd packages\Be.Windows.Forms.HexBox.* || exit /b 1
copy LICENSE.txt ..\..\Pkcs11Admin-%1\LICENSE\Be.Windows.Forms.HexBox.txt || exit /b 1
popd || exit /b 1
copy lib\pkcs11-logger\license.txt Pkcs11Admin-%1\LICENSE\pkcs11-logger.txt || exit /b 1
copy LICENSE.txt Pkcs11Admin-%1\LICENSE\Pkcs11Admin.txt || exit /b 1
pushd packages\Pkcs11Interop.* || exit /b 1
copy license.txt ..\..\Pkcs11Admin-%1\LICENSE\Pkcs11Interop.txt || exit /b 1
popd || exit /b 1
copy lib\Pkcs11Interop.URI\license.txt Pkcs11Admin-%1\LICENSE\Pkcs11Interop.URI.txt || exit /b 1

@goto:eof

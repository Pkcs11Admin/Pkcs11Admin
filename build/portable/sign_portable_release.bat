@setlocal

@rem Initialize build environment of Visual Studio 2015
call "C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\Tools\vsvars32.bat"

@rem Define signing options
set CERTHASH=501db72834b4b32704a5e0e97b9cb0a38b5a85ca
set TSAURL=http://time.certum.pl/
set LIBNAME=Pkcs11Admin
set LIBURL=https://www.pkcs11admin.net/

@rem Sign assemblies using SHA1withRSA algorithm
signtool sign /sha1 %CERTHASH% /fd sha1 /tr %TSAURL% /td sha1 /d %LIBNAME% /du %LIBURL% ^
Pkcs11Admin-Release\Pkcs11Admin.dll ^
Pkcs11Admin-Release\Pkcs11Admin-x86.exe ^
Pkcs11Admin-Release\Pkcs11Admin-x64.exe || goto :error

@rem Sign assemblies using SHA256withRSA algorithm
signtool sign /sha1 %CERTHASH% /as /fd sha256 /tr %TSAURL% /td sha256 /d %LIBNAME% /du %LIBURL% ^
Pkcs11Admin-Release\Pkcs11Admin.dll ^
Pkcs11Admin-Release\Pkcs11Admin-x86.exe ^
Pkcs11Admin-Release\Pkcs11Admin-x64.exe || goto :error

@echo *** SIGNING SUCCESSFUL ***
@endlocal
@exit /b 0

:error
@echo *** SIGNING FAILED ***
@endlocal
@exit /b 1

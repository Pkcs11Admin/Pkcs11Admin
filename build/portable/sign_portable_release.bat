@setlocal

set SIGNTOOL="C:\Program Files (x86)\Microsoft SDKs\ClickOnce\SignTool\signtool.exe"

@rem Define signing options
set CERTHASH=d5de31ea974f5ea8581d633eeffa8f3ea0d479bb
set TSAURL=http://time.certum.pl/
set LIBNAME=Pkcs11Admin
set LIBURL=https://www.pkcs11admin.net/

@rem Sign assemblies using SHA1withRSA algorithm
%SIGNTOOL% sign /sha1 %CERTHASH% /fd sha1 /tr %TSAURL% /td sha1 /d %LIBNAME% /du %LIBURL% ^
Pkcs11Admin-Release\Pkcs11Admin.dll ^
Pkcs11Admin-Release\Pkcs11Admin-x86.exe ^
Pkcs11Admin-Release\Pkcs11Admin-x64.exe || goto :error

@rem Sign assemblies using SHA256withRSA algorithm
%SIGNTOOL% sign /sha1 %CERTHASH% /as /fd sha256 /tr %TSAURL% /td sha256 /d %LIBNAME% /du %LIBURL% ^
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

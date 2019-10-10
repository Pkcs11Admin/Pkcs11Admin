@setlocal

set SIGNTOOL="C:\Program Files (x86)\Microsoft SDKs\ClickOnce\SignTool\signtool.exe"

@rem Define signing options
set CERTHASH=ef1bfeaa474bb078923831bf7732186673a5b5c9
set TSAURL=http://time.certum.pl/
set LIBNAME=Pkcs11Admin
set LIBURL=https://www.pkcs11admin.net/

@rem Sign assemblies
%SIGNTOOL% sign /sha1 %CERTHASH% /fd sha256 /tr %TSAURL% /td sha256 /d %LIBNAME% /du %LIBURL% ^
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

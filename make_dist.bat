set distdir=dist_[
FOR /F "tokens=1,2 delims=/: " %%a in ('Time/T') do set CTIME=%%a-%%b
FOR /F "tokens=1,2,3 delims=/. " %%a in ('Date/T') do set CTIME2=%%c-%%b-%%a
set date=%CTIME2%--%CTIME%
set name=dist\%distdir%%date%]
if exist "%name%" goto 1
md %name%
echo.

REM MHD
copy MHD\bin\Release\MHD.exe %name%
for /R MHD\bin\Release %%f in (*.dll) do copy %%f %name%
xcopy MHD\bin\Release\Content %name%\Content /S /E /I

REM MHDEDIT
copy MHDEDIT\bin\Release\MHDEDIT.exe %name%
for /R MHDEDIT\bin\Release %%f in (*.dll) do copy %%f %name%
copy MHDEDIT\bin\Release\MHDEDIT.exe.config %name%

:2
pause
exit

:1
echo Directory already exists!
goto 2
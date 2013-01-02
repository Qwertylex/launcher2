@echo off

if not defined BUILDCONFIG set BUILDCONFIG=Release
if not defined BUILDPLATFORM set BUILDPLATFORM=x86

if "%~1"=="" ( 
    goto :all
) else (
    for %%A in (%*) do (
        set BUILDFUNC=%%A
        call :%%A
    )
)

goto :eof

:all
    call :clean
    call :build
    call :package
    goto :eof

:clean
    echo [::] Cleaning
    del /S /Q launcher2\bin launcher2\obj *.cache launcher2-release.7z buildinfo.txt
    goto :eof

:build
    echo [::] Building launcher2 for %BUILDCONFIG% platform %BUILDPLATFORM%
    call :buildid
    C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe launcher2.sln /t:Rebuild /p:Configuration="%BUILDCONFIG%" /p:Platform="%BUILDPLATFORM%"
    goto :eof

:package
    echo [::] Creating package
    cd launcher2\bin\Release\%BUILDPLATFORM%
    "C:\Program Files\7-Zip\7z.exe" a -y ..\..\..\launcher2-release.7z *.exe *.dll ..\..\..\..\buildinfo.txt
    cd ..\..\..\..
    goto :eof

:buildid
    if exist ".git/refs/heads/master" ( set /p GITCOMMIT=<".git/refs/heads/master" ) else ( set GITCOMMIT=unknown )
    for /f "tokens=2,3,4 delims=[.]" %%a in ('ver') do set WINVER=%%a.%%b.%%c
    echo launcher2 build information > buildinfo.txt
    echo --------------------------- >> buildinfo.txt
    echo Build host user: %COMPUTERNAME%\%USERNAME% >> buildinfo.txt
    echo Build host OS: %WINVER% >> buildinfo.txt
    echo Build host architecture: %PROCESSOR_ARCHITECTURE% >> buildinfo.txt
    echo Build Git commit: %GITCOMMIT% >> buildinfo.txt
    echo Build time: %date% %time% >> buildinfo.txt
    echo Build configuration: %BUILDCONFIG% >> buildinfo.txt
    echo Build platform: %BUILDPLATFORM% >> buildinfo.txt
    echo --------------------------- >> buildinfo.txt
    goto :eof
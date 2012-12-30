@echo off

if "%~1"=="" goto :all
for %%A in (%*) do ( call :%%A )
goto :eof

:all
    call :clean
    call :release
    goto :eof

:clean
    echo [::] Cleaning
    del /S /Q launcher2\bin launcher2\obj *.cache launcher2-release.7z
    goto :eof

:debug
    echo [::] Building debug
    C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe launcher2.sln /t:Rebuild /p:Configuration=Debug
    goto :eof

:release
    echo [::] Building release
    C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe launcher2.sln /t:Rebuild /p:Configuration=Release
    echo [::] Packaging release
    cd launcher2\bin\Release
    "C:\Program Files\7-Zip\7z.exe" a -y ..\..\..\launcher2-release.7z *.exe *.dll
    cd ..\..\..
    goto :eof

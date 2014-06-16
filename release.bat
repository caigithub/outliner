@echo off

@set solution=outliner
@set build=Release

@set build_cmd=C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\WDExpress.exe
@rem build_cmd=C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE\WDExpress.exe
@rem build_cmd=C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\vcsexpress.exe

@echo building %solution% solution...
"%build_cmd%" %solution%.sln /build %build% 

rd "src\obj" /S /Q

pause

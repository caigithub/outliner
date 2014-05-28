@echo off

@set solution=outliner
@set build=Release

@set build_cmd=C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE\WDExpress.exe
@rem C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\vcsexpress.exe

@echo building %solution% solution...
"%build_cmd%" %solution%.sln /build %build% 

@set projects=%solution%
@set output=bin\Release

@echo deploy 
for %%t in (%solution%) do  copy "%%t\%output%\*.exe" ".\bin" 
@echo done...
pause

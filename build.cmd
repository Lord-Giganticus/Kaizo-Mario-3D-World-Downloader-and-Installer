msbuild "Installer\Installer.csproj" -p:Configuration=Release
cd Installer\bin\Release
Installer.exe
7z a Release.zip *.exe -x!Installer.exe
mv Release.zip ../../../.
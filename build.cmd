msbuild "Installer\Installer.csproj" -p:Configuration=Release
cd Installer\bin\Release
Installer.exe
7z a Release.zip "Kaizo Mario 3D World.exe"
mv Release.zip ../../../.
echo Complete
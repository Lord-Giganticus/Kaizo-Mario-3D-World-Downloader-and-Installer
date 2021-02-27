msbuild "Installer\Installer.csproj" -p:Configuration=Release
cd Installer\bin\Release
Installer.exe
mv "Kaizo Mario 3D World.exe" ../../../.
7z a Release.zip "Kaizo Mario 3D World.exe"
echo Complete
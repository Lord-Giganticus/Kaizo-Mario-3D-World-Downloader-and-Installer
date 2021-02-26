msbuild "Installer\Installer.csproj" -p:Configuration=Release
cd Installer\bin\Release
Installer.exe
mv Kaizo Mario 3D World Normal Mode.exe ../../../.
mv Kaizo Mario 3D World Practice Mode.exe ../../../.
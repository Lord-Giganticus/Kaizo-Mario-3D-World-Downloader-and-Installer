msbuild "Installer\Installer.csproj" -p:Configuration=Release
cd Installer\bin\Release
Installer.exe
mv "Kaizo Mario 3D World Normal Mode.exe" ../../../.
mv "Kaizo Mario 3D World Practice Mode.exe" ../../../.
cd ../../../
cd Installer
mv KM3DW.nsi ../.
cd ../
echo makensis KM3DW.nsi > Release.cmd
Release
7z a Release.zip "Kaizo Mario 3D World.exe"
echo Complete
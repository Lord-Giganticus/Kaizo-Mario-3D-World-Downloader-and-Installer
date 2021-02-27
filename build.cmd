msbuild "Installer\Installer.csproj" -p:Configuration=Release
cd Installer\bin\Release
Installer.exe
mv "Kaizo Mario 3D World Normal Mode.exe" ../../../.
mv "Kaizo Mario 3D World Practice Mode.exe" ../../../.
cd ../../../
cd Installer
mv KM3DW.nsi ../.
cd ../
makensis KM3DW.nsi
mv KM3DW.nsi Installer/.
7z a Release.zip "Kaizo Mario 3D World.exe"
echo Complete
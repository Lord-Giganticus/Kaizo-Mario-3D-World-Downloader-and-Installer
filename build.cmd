msbuild "Installer\Installer.csproj" -p:Configuration=Release
cd Updater
build-py
makensis Updater.nsi
copy "Kaizo Mario 3D World Updater.exe" "..\Installer\bin\Release\Kaizo Mario 3D World Updater.exe"
cd ..\Installer\bin\Release
Installer.exe
7z a Release.zip "Kaizo Mario 3D World.exe"
mv Release.zip ../../../.
echo Complete
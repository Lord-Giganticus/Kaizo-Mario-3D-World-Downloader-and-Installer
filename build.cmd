pushd %CD%
dotnet clean --configuration Release && dotnet nuget locals all --clear
nuget restore
cd Updater
dotnet build /p:Configuration=Release
cd ../
cd Updater\bin\Release\net5.0
echo %CD%
makensis Updater.nsi
popd
copy Updater\bin\Release\net5.0\KM3DW-Updater.exe .
msbuild Installer/Installer.csproj -p:Configuration=Release
echo %CD%
pause
cd Installer\bin\Release
mv ../../../KM3DW-Updater.exe .
Installer.exe
mv "Kaizo Mario 3D World.exe" ../../../.
cd ../../../
7z a Release.zip "Kaizo Mario 3D World.exe"
echo Complete
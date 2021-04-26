pushd %CD%
dotnet clean --configuration Release && dotnet nuget locals all --clear
nuget restore
cd Updater
dotnet build /p:Configuration=Release && dotnet publish /p:PublishProfile=win-x86
cd ../
cd Updater\bin\Release\net5.0\publish\win-x86
echo %CD%
makensis Updater.nsi
popd
copy Updater\bin\Release\net5.0\publish\win-x86\KM3DW-Updater.exe .
msbuild Installer/Installer.csproj -p:Configuration=Release
echo %CD%
cd Installer\bin\Release
mv ../../../KM3DW-Updater.exe .
Installer.exe
mv "Kaizo Mario 3D World.exe" ../../../.
cd ../../../
7z a Release.zip "Kaizo Mario 3D World.exe"
echo Complete
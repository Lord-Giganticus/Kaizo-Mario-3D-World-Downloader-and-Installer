nuget restore
cd Updater
dotnet publish /p:Configuration=Release /p:PublishProfile=win-x86
cd bin/Release/net5.0/publish/win-x86
cd ../../../../../../
cp Updater/bin/Release/net5.0/publish/win-x86/Updater.exe Updater.exe
msbuild Installer/Installer.csproj -p:Configuration=Release
cd Installer\bin\Release
mv ../../../Updater.exe Updater.exe
Installer.exe
mv "Kaizo Mario 3D World.exe" ../../../.
cd ../../../
7z a Release.zip "Kaizo Mario 3D World.exe"
echo Complete
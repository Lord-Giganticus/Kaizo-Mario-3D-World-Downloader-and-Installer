nuget restore
cd Updater
msbuild Updater.csproj -p:Configuration=Release
cd bin/Release/net5.0/publish/win-x86
cd ../../../../../../
cp Updater/bin/Release/net5.0/Updater.exe Updater.exe
cp Updater/bin/Release/net5.0/Updater.dll Updater.dll
cp Updater/bin/Release/net5.0/Updater.runtimeconfig.json Updater.runtimeconfig.json
cp Updater/bin/Release/net5.0/Newtonsoft.Json.dll Newtonsoft.Json.dll
msbuild Installer/Installer.csproj -p:Configuration=Release
cd Installer\bin\Release
mv ../../../Updater.exe Updater.exe
mv ../../../Updater.dll Updater.dll
mv ../../../Updater.runtimeconfig.json Updater.runtimeconfig.json
mv ../../../Newtonsoft.Json.dll Newtonsoft.Json.dll
Installer.exe
mv "Kaizo Mario 3D World.exe" ../../../.
cd ../../../
7z a Release.zip "Kaizo Mario 3D World.exe"
echo Complete
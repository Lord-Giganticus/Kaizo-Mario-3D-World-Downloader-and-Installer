dotnet clean --configuration Release && dotnet nuget locals all --clear
nuget restore
cd Updater
dotnet add package Newtonsoft.Json --version 13.0.1
msbuild Updater.csproj -p:Configuration=Release
cd bin/Release/net5.0/publish/win-x86
cd ../../../../../../
copy Updater\bin\Release\net5.0\Updater.exe .
copy Updater\bin\Release\net5.0\Updater.dll .
copy Updater\bin\Release\net5.0\Updater.runtimeconfig.json .
cp Updater\bin\Release\net5.0\Newtonsoft.Json.dll .
msbuild Installer/Installer.csproj -p:Configuration=Release
cd Installer\bin\Release
mv ../../../Updater.exe .
mv ../../../Updater.dll .
mv ../../../Updater.runtimeconfig.json .
mv ../../../Newtonsoft.Json.dll .
Installer.exe
mv "Kaizo Mario 3D World.exe" ../../../.
cd ../../../
7z a Release.zip "Kaizo Mario 3D World.exe"
echo Complete
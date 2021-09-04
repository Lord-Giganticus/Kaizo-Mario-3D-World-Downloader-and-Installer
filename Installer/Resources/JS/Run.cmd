Powershell ./GetUrl.ps1 https://gamebanana.com/dl/543972 > result.txt
set /p OUTPUT=<result.txt
rm result.txt
Powershell Invoke-WebRequest -Uri "%OUTPUT%" -OutFile kaizo_mario_3d_world_269.zip
Powershell ./GetUrl.ps1 "https://gamebanana.com/dl/543971" > result.txt
set /p OUTPUT=<result.txt
rm result.txt
Powershell Invoke-WebRequest -Uri "%OUTPUT%" -OutFile kaizo_mario_3d_world_practice_269.zip
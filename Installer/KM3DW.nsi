; The name of the installer
Name "Kaizo Mario 3D World (Installer)"

; The file to write
OutFile "Kaizo Mario 3D World.exe"

; Request application privileges for Windows Vista
RequestExecutionLevel user

; Build Unicode installer
Unicode True

; The default installation directory
InstallDir "$DESKTOP\Kaizo Mario 3D World"

;--------------------------------

; Pages

Page directory
Page instfiles

;--------------------------------
Icon "Normal.ico"
!define MUI_ICON "Normal.ico"
!define MUI_UNICON "Normal.ico"
; The stuff to install
Section "" ;No components page, name is not important
  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  ; Put file there
  File "Kaizo Mario 3D World Practice Mode.exe"
  File "Kaizo Mario 3D World Normal Mode.exe"
  File "Updater.exe"
  File "Updater.dll"
  File "Updater.runtimeconfig.json"
  File "Newtonsoft.Json.dll"
  
SectionEnd ; end the section
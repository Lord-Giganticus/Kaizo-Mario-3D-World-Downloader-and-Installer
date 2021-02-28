; The name of the installer
Name "Kaizo Mario 3D World (Updater)"

; The file to write
OutFile "Kaizo Mario 3D World Updater.exe"

; Request application privileges for Windows Vista
RequestExecutionLevel user

; Build Unicode installer
Unicode True

; The default installation directory
InstallDir "$DESKTOP\Kaizo Mario 3D World\Updater"

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
  File "bin\Release\Updater.exe"
  File /r "Runtimes"  
  File "Checker.js"

SectionEnd ; end the section
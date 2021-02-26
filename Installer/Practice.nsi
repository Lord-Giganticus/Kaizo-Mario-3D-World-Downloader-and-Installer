; The name of the installer
Name "Kaizo Mario 3D World Practice Mode (Installer)"

; The file to write
OutFile "Kaizo Mario 3D World Practice Mode.exe"

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
Icon "Practice.ico"
!define MUI_ICON "Practice.ico"
!define MUI_UNICON "Practice.ico"
; The stuff to install
Section "" ;No components page, name is not important
  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  ; Put file there
  File "Kaizo Mario 3D World Practice Mode (Cemu Graphic Pack).exe"
  File "Kaizo Mario 3D World Practice Mode (SdCafiine-EUR).exe"
  File "Kaizo Mario 3D World Practice Mode (SdCafiine-JPN).exe"
  File "Kaizo Mario 3D World Practice Mode (SdCafiine-USA).exe"
  
SectionEnd ; end the section
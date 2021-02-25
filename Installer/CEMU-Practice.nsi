; The name of the installer
Name "Kaizo Mario 3D World Practice Mode (Cemu Graphic Pack)"

; The file to write
OutFile "Kaizo Mario 3D World Practice Mode (Cemu Graphic Pack).exe"

; Request application privileges for Windows Vista
RequestExecutionLevel user

; Build Unicode installer
Unicode True

; The default installation directory
InstallDir "$DESKTOP\Kaizo Mario 3D World\Practice Mode"

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
  File /r "Kaizo Mario 3D World Practice Mode\content"
  File "Kaizo Mario 3D World Practice Mode\rules.txt"
  
SectionEnd ; end the section

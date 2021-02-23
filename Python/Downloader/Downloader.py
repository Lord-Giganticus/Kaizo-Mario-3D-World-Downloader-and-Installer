import os
import sys
import shutil
if sys.argv[0].endswith('.exe') == False:
    if os.getcwd() != os.path.dirname(__file__):
        os.chdir(os.path.dirname(__file__))
    else:
        pass
else:
    pass
os.system('cmd /c curl https://lord-giganticus.github.io/Kaizo-Mario-3D-World-Downloader-and-Installer/files/index.js -o index.js')
os.system('cmd /c curl https://gamebanana.com/maps/download/211946?api=FilesModule -o kaizo.json')
os.system('cmd /c node index > download.cmd')
os.system('cmd /c download.cmd')
if os.path.isdir("Kaizo Mario 3D World") == True:
    os.remove("Kaizo Mario 3D World")
else:
    pass
if os.path.isdir("Kaizo Mario 3D World Practice Mode") == True:
    os.remove("Kaizo Mario 3D World Practice Mode")
else:
    pass
os.system('cmd /c unzip.cmd')
os.chdir('Kaizo Mario 3D World')
os.chdir("meta")
os.remove("meta.xml")
os.chdir('../../Kaizo Mario 3D World Practice Mode/meta')
os.remove("meta.xml")
import os
import sys
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
os.system('cmd /c http://stahlworks.com/dev/unzip.exe -o unzip.exe')
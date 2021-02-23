import os
import sys
if sys.argv[0].endswith('.exe') == False:
    if os.getcwd() != os.path.dirname(__file__):
        os.chdir(os.path.dirname(__file__))
    else:
        pass
else:
    pass
if os.path.isfile('kaizo.json') == False:
    os.system('cmd /c curl https://gamebanana.com/maps/download/211946?api=FilesModule -o kaizo.json')
try:
    if sys.argv[1] == "Action":
        os.system('cmd /c git config --local user.email "action@github.com" && git config --local user.name "GitHub Action" && git add *')
    else:
        os.system("cmd /c git add *")    
except:
    os.system('cmd /c git add *')
os.system('git commit -m "Update JSON" -a')
os.system('git push > test.txt')
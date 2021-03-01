import sys
import os
import urllib.request
import json
import requests

if sys.argv[0].endswith(".exe") == False:
    if os.getcwd() != os.path.dirname(__file__) == True:
        os.chdir(os.path.dirname(__file__))
    else:
        pass
else:
    pass
url = 'https://api.github.com/repos/Lord-Giganticus/Kaizo-Mario-3D-World-Downloader-and-Installer/releases/latest'
with urllib.request.urlopen(url) as f:
    html = f.read().decode('utf-8')
with open("config.json",'w') as j:
    j.writelines(html)
    j.close()
with open('config.json','r') as f:
  data = json.load(f)
  f.close()
tag = data['tag_name']
assets = data['assets']
asset = assets[0]
url = asset['browser_download_url']
name = asset['name']
if sys.argv[1] != tag:
    r = requests.get(url, allow_redirects=True)
    with open(name, 'wb') as f:
        f.write(r.content)
elif sys.argv[1] == tag:
    print("No need to update.")
else:
    exit(1)
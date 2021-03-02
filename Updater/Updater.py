import sys
import os
import urllib.request
import json
import requests
import time

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
    j.write(html)
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
    print("Starting download in 5 seconds. This will take some time depending on your internet data rate!")
    time.sleep(5)
    r = requests.get(url, allow_redirects=True)
    with open(name, 'wb') as f:
        f.write(r.content)
        f.close()
    print("Latest Release downloaded.")
elif sys.argv[1] == tag:
    url = 'https://api.github.com/repos/Lord-Giganticus/Kaizo-Mario-3D-World-Downloader-and-Installer/commits'
    with urllib.request.urlopen(url) as f:
        html = f.read().decode('utf-8')
    with open("config.json",'w') as j:
        j.write(html)
        j.close()
    with open('config.json','r') as f:
      data = json.load(f)
      f.close()
    latest = data[0]
    sha = latest['sha']
    with open('commit.txt','r') as f:
        commit = f.read()
    if commit != sha:
       choice = int(input("Local Commit is not the latest Commit from the repo! Do you want to download the release just in case?\n[1]Yes\n[2]No\n"))
       if choice == 1:
           print("Starting download in 5 seconds. This will take some time depending on your internet data rate!")
           time.sleep(5)
           r = requests.get(url, allow_redirects=True)
           with open(name, 'wb') as f:
            f.write(r.content)
            f.close()
            print("Latest Release downloaded.")
       else:
           print("Alright! I won't update!")
else:
    exit(1)
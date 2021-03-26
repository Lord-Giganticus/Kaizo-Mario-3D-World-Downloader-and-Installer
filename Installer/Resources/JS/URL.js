// Made by Lord-Giganticus
const fs = require('fs');
const data = require('./config.json')
var files = data._aCellValues._aFiles
var line = ""
for (var key in files) {
    var value = files[key];
    var url = value._sDownloadUrl
    line = line + "curl -k -L "+ url+ " -o "+ value._sFile + "\n" 
}
fs.writeFile('download.cmd', line, err => {
    if (err) {
        console.error(err)
        return
    }
    return console.log("Complete.");
})
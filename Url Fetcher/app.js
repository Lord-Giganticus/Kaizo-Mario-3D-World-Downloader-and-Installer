// Made by Lord-Giganticus

const { _aCellValues } = require('./config.json');
const objects = _aCellValues._aFiles
for (var key in objects) {
    var value = objects[key];
    var url = value._sDownloadUrl
    console.log("curl -L", url, "-o", value._sFile)
}
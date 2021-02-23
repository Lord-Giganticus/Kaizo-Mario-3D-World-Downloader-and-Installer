const {_aCellValues} = require('./kaizo.json');
const objects = _aCellValues._aFiles
for(var key in objects) {
    var value = objects[key];
    var url = value._sDownloadUrl
    console.log(url)
}
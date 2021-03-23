const data = require("./update.json");
const fs = require("fs");
var vales = data._aCellValues[0];
var tag = vales._sName;
fs.writeFile("tag.txt",tag, err => {
    if (err) {
        console.error(err)
        return
    } else {
        return console.log("Complete.")
    }
})
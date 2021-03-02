const data = require('./config.json');
const fs = require('fs');
commit = data[0].sha
fs.writeFile('commit.txt', commit, err => {
    if (err) {
        console.error(err)
        return
    }
    return console.log("Complete.");
})
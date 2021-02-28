const {tag_name, assets} = require("./config.json");
var version = process.argv[2];
var url = assets[0].browser_download_url
var name = assets[0].name
if (version != tag_name) {
    console.log("curl -L",url,name);
    return process.exit(0);
} else {
    console.log("No need to update!");
    return process.exit(0);
}
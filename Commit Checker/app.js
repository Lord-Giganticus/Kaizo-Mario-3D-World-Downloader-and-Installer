const { Octokit } = require('@octokit/core');
const fs = require('fs');
const octokit = new Octokit({ auth: `d03bf420dfe87d1e8a0d15d8e6c74eda6bf478ad` });
async function start() {
    const result = await octokit.request('GET /repos/{owner}/{repo}/commits', {
        owner: 'Lord-Giganticus',
        repo: 'Kaizo-Mario-3D-World-Downloader-and-Installer'
    })
    fs.writeFile('commit.txt', result.data[0].sha, err => {
        if (err) {
            console.error(err)
            return
        }
        return console.log("Complete.");
    })
}
start();
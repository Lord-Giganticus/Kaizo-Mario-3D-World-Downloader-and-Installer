/* js2exe.js is from https://dev.to/jochemstoel/bundle-your-node-app-to-a-single-executable-for-windows-linux-and-osx-2c89*/
const { exec } = require('pkg')
exec([process.argv[2], '--target', 'host', '--output', process.argv[3]+'.exe']).then(function () {
    console.log('Done!')
}).catch(function (error) {
    console.error(error)
})


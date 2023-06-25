// const express = require('express')
// const app = express()
// const port = 5000

// app.get('/', (req, res) => {
//   res.send('Hello World!')
// })

// app.listen(port, () => {
//   console.log(`Example app listening on port ${port}`)
// })



const os = require('os')
// const name = require('./sum.js')
// const dfault = require('./default.js')

const path = require('path');
const filename = path.basename('/user/documents/file.txt');
console.log(filename); // file.txt

const filenameWithoutExt = path.basename('/user/documents/file.txt', '.txt');
console.log(filenameWithoutExt); // file

const directory = path.dirname('/user/documents/file.txt');
console.log(directory);

// console.log(dfault.items);
// console.log(dfault.singlePerson.name);
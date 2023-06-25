const {writeFileSync, readFileSync} = require('fs');
const path = require('path');

console.log('started');

const firstPath = path.resolve(__dirname,'content/first.txt');
const secondPath = path.resolve(__dirname,'content/second.txt');


const first = readFileSync(firstPath,'utf8');
const second = readFileSync(secondPath,'utf8');

writeFileSync('./content/result-sync.txt', `here is the result : ${first} ${second}`)
console.log('Done with this task');

console.log('start with a next one');
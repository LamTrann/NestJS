const { writeFile, readFile } = require('fs').promises;
console.log('started');

readFile('./content/first.txt', 'utf8')
  .then((data) => {
    const first = data;
    return readFile('./content/second.txt', 'utf8');
  })
  .then((data) => {
    const second = data;
    return writeFile('./content/result-sync.txt', `here is the result: ${second}`);
  })
  .then(() => {
    console.log('Done with this task');
  })
  .catch((err) => {
    console.error(err);
  });

  console.log('start with a next one');
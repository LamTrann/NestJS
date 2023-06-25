console.log('FirstTask')

console.time();

for (let index = 0; index < 10000000; index++) {
  const h3 = document.querySelector('h3')
  h3.textContent `Hey`
}

console.timeEnd();

console.log('Next task');
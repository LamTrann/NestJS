const http = require('http');

const server = http.createServer((req, res) => {
  if (req.url === '/') {
    res.end('Hello World');
  } else if (req.url === '/about') {
    res.end('About');
  } else {
    res.statusCode = 404;
    res.end(`
      <h1>Oops</h1>
      <p>We can't seem to find the page you're looking for</p>
      <a href="/">back home</a> 
      <button>a</button>
    `);
  }
});

server.listen(5000);

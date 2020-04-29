fetch('https://localhost:44335/api/v1/cars')
  .mode
  .then(response => response.json())
  .then(data => console.log(data));




/*
var request = new XMLHttpRequest()
request.open('GET', 'https://localhost:44335/api/v1/cars')
request.withCredentials = true;
request.setRequestHeader("Content-Type", "application/json");
request.setRequestHeader("Access-Control-Allow-Origin", "*");

request.onload = function() {
  // Begin accessing JSON data here
  var data = JSON.parse(this.response)
  console.log(data)
  if (request.status >= 200 && request.status < 400) {
    data.forEach(car => {
      console.log(car.Name)
    })
  } else {
    console.log('error')
  }
}

request.send({ 'request': "authentication token" })
*/

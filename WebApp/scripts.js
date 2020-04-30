/*
fetch('https://localhost:44335/api/v1/cars')
  .then((resp) => resp.json()) // Transform the data into json
  .then(function(data) {
    // Create and append the li's to the ul
    console.log(data);
    })
*/


var request = new XMLHttpRequest()
request.open('GET', 'https://localhost:44335/api/v1/cars')

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

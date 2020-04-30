// access root from html file
const app = document.getElementById('root')

//create first container
const container = document.createElement('div')
container.setAttribute('class', 'container')

//add container to html file
app.appendChild(container)

//http GET request
var request = new XMLHttpRequest()
request.open('GET', 'https://localhost:44335/api/v1/cars')

request.onload = function() {
  // Begin accessing JSON data here
  var data = JSON.parse(this.response)
  if (request.status >= 200 && request.status < 400) {
    //data well received
    
    data.forEach(car => {
      //Create card
      const card = document.createElement('div')
      card.setAttribute('class', 'card')
      //Create Card header using car.name
      const h1 = document.createElement('h1')
      h1.textContent = "Bugatti " + car.name
      
        //ALL PROPERTIES:
        //  Id, Name, Creator, StartBuildYear, StopBuildYear, Countries, AvrgPrice, Horsepower, MaxSpeed, Weight, Prototype, WorldRecords, TotalBuilt, TotalRaceVictories, SmallDescription

      // Make the list
      listElement = document.createElement('ul')
      //--------------------------CREATE LIST--------------------------
      listItem1 = document.createElement('li');
      listItem1.innerHTML = "price: " + car.avrgPrice + " euro";

      //listItem2 = document.createElement('li');
      //listItem2.innerHTML = "Creator: " + car.creator;

      //listItem3 = document.createElement('li');
      //listItem3.innerHTML = "Build from " + car.startBuildYear + " until " + car.StopBuildYear.getFullYear();

      //listItem4 = document.createElement('li');
      //listItem4.innerHTML = "Countries: " + car.countries;

      listItem5 = document.createElement('li');
      listItem5.innerHTML = "price: " + car.avrgprice + " euro";

      listItem6 = document.createElement('li');
      listItem6.innerHTML = "Engine horsepower: " + car.horsepower + " PK";

      listItem7 = document.createElement('li');
      listItem7.innerHTML = "Maximum speed: " + car.maxSpeed + " Km/h";

      listItem8 = document.createElement('li');
      listItem8.innerHTML = "Weight: " + car.weight + " Kg";

      listItem9 = document.createElement('li');
      listItem9.innerHTML = "Prototype: " + car.prototype;

      listItem10 = document.createElement('li');
      listItem10.innerHTML = "Worldrecords: " + car.worldrecords;

      listItem11 = document.createElement('li');
      listItem11.innerHTML = "Total built: " + car.totalBuilt;

      listItem12 = document.createElement('li');
      listItem12.innerHTML = "Total race victories: " + car.totalRaceVictories + "victories";

      listItem13 = document.createElement('li');
      listItem13.innerHTML = "Extra description:" + car.description;
      //---------------------------------------------------------------

      
     
      
      
      // Add all components to each parent
      // Add Card to container
      container.appendChild(card)
      // Add h1 to Card
      card.appendChild(h1)
      // Add listItem to the Card
      card.appendChild(listElement)
      // Add listItem to the listElement
      listElement.appendChild(listItem1);
      //listElement.appendChild(listItem2);
      //listElement.appendChild(listItem3);
      //listElement.appendChild(listItem4);
      listElement.appendChild(listItem5);
      listElement.appendChild(listItem6);
      listElement.appendChild(listItem7);
      listElement.appendChild(listItem8);
      listElement.appendChild(listItem9);
      listElement.appendChild(listItem10);
      listElement.appendChild(listItem11);
      listElement.appendChild(listItem12);
      listElement.appendChild(listItem13);
    })
  } else {
    console.log('error')
  }
}
request.send()

var carNameInput = '', sortInput = '', lenghtInput = 0, sortDir = "asc";
var baseUrl = 'https://localhost:44335/api/v1/cars?';
var url, urlAddon;

function EditUrl() {
    urlAddon='';
    if (document.getElementById('nameInput').value != '') {
        carNameInput = document.getElementById('nameInput').value;
        urlAddon += '&name=' + carNameInput;
    }

    if (document.getElementById('sortInput').value != ''){
        sortInput = document.getElementById('sortInput').value;
        urlAddon += '&sortItem=' + sortInput;
    }

    if (document.getElementById('CheckOrder').checked == true) {
        sortDir = 'desc';
        urlAddon += '&sortDir=' + sortDir;
    }
    else {
        sortDir = 'asc';
        urlAddon += '&sortDir=' + sortDir;
    }

    if (document.getElementById('lengthInput').value != 0){
        lenghtInput = document.getElementById('lengthInput').value;
        urlAddon += '&amount=' + lenghtInput;
    }
    url = baseUrl +  urlAddon.slice(1);
    Refresh();

}

function Refresh() {
    
    document.getElementById('root').innerHTML = "";

    const app = document.getElementById('root')

    //create first container
    const container = document.createElement('div')
    container.setAttribute('class', 'container')

    //add container to html file
    app.appendChild(container)

    //http GET request
    var request = new XMLHttpRequest()

    request.open('GET', url)

    request.onload = function () {
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

                listItem2 = document.createElement('li');
                listItem2.innerHTML = "Creator: " + car.creator.firstName + " " + car.creator.lastName;

                listItem3 = document.createElement('li');
                var startYear = car.startBuildYear.toString().substring(0, 4);
                var stopYear = car.stopBuildYear.toString().substring(0, 4);
                if (stopYear == 0001)
                    stopYear = "/";
                listItem3.innerHTML = "Build from " + startYear + " until " + stopYear;

                listItem4 = document.createElement('li');
                var countries = "";
                for (i = 0; i < car.countryList.length; i++) {
                    countries += car.countryList[i].country.name + ", ";
                }
                countries = countries.substring(0, (countries.length - 2));
                listItem4.innerHTML = "Countries: " + countries;

                listItem6 = document.createElement('li');
                listItem6.innerHTML = "Engine horsepower: " + car.horsepower + " PK";

                listItem7 = document.createElement('li');
                listItem7.innerHTML = "Maximum speed: " + car.maxSpeed + " Km/h";

                listItem8 = document.createElement('li');
                listItem8.innerHTML = "Weight: " + car.weight + " Kg";

                listItem9 = document.createElement('li');
                listItem9.innerHTML = "Prototype: " + car.prototype;

                listItem10 = document.createElement('li');
                listItem10.innerHTML = "Worldrecords: " + car.worldRecords;

                listItem11 = document.createElement('li');
                listItem11.innerHTML = "Total built: " + car.totalBuilt;

                listItem12 = document.createElement('li');
                listItem12.innerHTML = "Total race victories: " + car.totalRaceVictories + " victories";

                listItem13 = document.createElement('li');
                listItem13.innerHTML = "Extra description: " + car.smallDescription;
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
                listElement.appendChild(listItem2);
                listElement.appendChild(listItem3);
                listElement.appendChild(listItem4);
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
    request.send();
}
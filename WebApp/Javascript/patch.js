
var data;
var carNames = [];
var selectedCar;
//http GET request
var request = new XMLHttpRequest()
request.open('GET', 'https://localhost:44335/api/v1/cars')
;
request.onload = function () {
    data = JSON.parse(this.response)
    if (request.status >= 200 && request.status < 400) {
        data.forEach(car => {
            var opt = document.createElement("option");
            document.getElementById("cars").options.add(opt);
            opt.text = car.name;
            
        })
    } else {
        console.log('error')
    }
}
request.send();

function UpdateForm()
{
    data.forEach(car => {
        if (car.name == document.getElementById("cars").value)
        {
            selectedCar = car;
            document.getElementById('element_1').value = car.name;

            document.getElementById('element_2_1').value = car.startBuildYear.substring(5,7);
            document.getElementById('element_2_2').value = car.startBuildYear.substring(8,10);
            document.getElementById('element_2_3').value = car.startBuildYear.substring(0,4);
        
            document.getElementById('element_3_1').value = car.stopBuildYear.substring(5,7);
            document.getElementById('element_3_2').value = car.stopBuildYear.substring(8,10);
            document.getElementById('element_3_3').value = car.stopBuildYear.substring(0,4);
        
            document.getElementById('element_4').value = car.avrgPrice;
            document.getElementById('element_5').value = car.horsepower;
            document.getElementById('element_6').value = car.maxSpeed;
            document.getElementById('element_7').value = car.weight;
        
            if (car.prototype == true)
                document.getElementById('element_12_1').checked == true;
            else
                document.getElementById('element_12_1').checked == false;
        
            var ItotalBuilt = document.getElementById('element_8').value = car.totalBuilt;
            var IworldRecords = document.getElementById('element_9').value = car.worldRecords;
            var Itotalvictories = document.getElementById('element_10').value = car.totalRaceVictories;
            var IsmallDescription = document.getElementById('element_11').value = car.smallDescription;  
        }
    })
}

function PatchRequest()
{
    var Iname = document.getElementById('element_1').value;

    var IstartBuildYear_MONTH = document.getElementById('element_2_1').value;
    var IstartBuildYear_DAY = document.getElementById('element_2_2').value;
    var ItartBuildYear_YEAR = document.getElementById('element_2_3').value;

    var ItopBuildYear_MONTH = document.getElementById('element_3_1').value;
    var ItopBuildYear_DAY = document.getElementById('element_3_2').value;
    var ItopBuildYear_YEAR = document.getElementById('element_3_3').value;

    var IavrgPrice = document.getElementById('element_4').value;
    var Ihorsepower = document.getElementById('element_5').value;
    var ImaxSpeed = document.getElementById('element_6').value;
    var Iweight = document.getElementById('element_7').value;

    if (document.getElementById('element_12_1').checked == true)
        var Iprototype = true;
    else
        var Iprototype = false;

    var ItotalBuilt = document.getElementById('element_8').value;
    var IworldRecords = document.getElementById('element_9').value;
    var Itotalvictories = document.getElementById('element_10').value;
    var IsmallDescription = document.getElementById('element_11').value;

    if (Iname == "" || IavrgPrice == "" || Ihorsepower == "" || ImaxSpeed == "" || Iweight == "" || ItotalBuilt == "" || IworldRecords == "" || ItotalBuilt == "" || IsmallDescription == "")
    {
        alert("u heeft niet alles ingevuld!")
    }else
    {
        var obj =
        {
            id: selectedCar.id,
            name: Iname,
            startBuildYear: ItartBuildYear_YEAR + '-' + IstartBuildYear_MONTH + '-' + IstartBuildYear_DAY,
            stopBuildYear: ItopBuildYear_YEAR + '-' + ItopBuildYear_MONTH + '-' + ItopBuildYear_DAY,
            avrgPrice: IavrgPrice,
            horsepower: Ihorsepower,
            maxSpeed: ImaxSpeed,
            weight: Iweight,
            prototype: Iprototype,
            totalBuilt: ItotalBuilt,
            worldRecords: IworldRecords,
            totalRaceVictories: Itotalvictories,
            smallDescription: IsmallDescription
        }
        var request = new XMLHttpRequest()
        request.open('PATCH', 'https://localhost:44335/api/v1/cars', true);
        request.setRequestHeader('Content-Type', 'application/json');
        request.send(JSON.stringify(obj));
        alert("Patch succesfull")
    }
}
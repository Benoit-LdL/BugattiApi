var access_token;

//authentication
function CheckToken()
{
    access_token = new URLSearchParams(window.location).get('code');
    //alert(access_token);
    if (access_token == null)
    {
    //document.getElementById("btnDelete").disabled = true;
    //document.getElementById("loggedIn").innerText ="Not logged in";
    }
    else
    {
    //document.getElementById("btnDelete").disabled = false;
    //document.getElementById("loggedIn").innerText="Succesfully logged in";
    }
}
//-------------------------------------------------

var data 
var carNames = []
//http GET request
var request = new XMLHttpRequest()
request.open('GET', 'https://localhost:44335/api/v1/cars');
request.setRequestHeader("Bearer",access_token);
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

function DeleteRequest()
{
    data.forEach(car => {
        if (car.name == document.getElementById("cars").value)
        {
            
            return fetch('https://localhost:44335/api/v1/cars' + '/' + car.id, 
            {
                method: 'delete'
            })
            .then(res => res.text()) // or res.json()
            .then(res => console.log(res.status))
        }
    })
    
}


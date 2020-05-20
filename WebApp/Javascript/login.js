        // Settings for the script, you MUST fill these out for the example to work
var settings = {
	client_id: "YnSPFsd22xQbf3bJ6_v1A4jl",
	callback_url: "609373984330-onab060bp61jj60piq66h7sg1icicf4t.apps.googleusercontent.com"
};

// Fix an issue with Prism cdn (this is for looks only, feel free to ignore this)
Prism.languages.json = {
	'property': /"(?:\\.|[^|"])*"(?=\s*:)/ig,
	'string': /"(?!:)(?:\\.|[^|"])*"(?!:)/g,
	'number': /\b-?(0x[\dA-Fa-f]+|\d*\.?\d+([Ee][+-]?\d+)?)\b/g,
	'punctuation': /[{}[\]);,]/g,
	'operator': /:/g,
	'boolean': /\b(true|false)\b/gi,
	'null': /\bnull\b/gi
};

Prism.languages.jsonp = Prism.languages.json;

var token;

window.onload = function() {
	// Try to get the token from the URL
	token = getToken();
	// If the token has been given so change the display
	if (token) {
		document.getElementById('api-call').disabled = false;
		document.getElementById('authenticated-msg').innerHTML += token;
		document.getElementById('authenticated-msg').style.display = "block";
		document.getElementById('make-call-msg').style.display = "block";
	} else { // Else we haven't been authorized yet
		document.getElementById('un-authenticated-msg').style.display = "block";
	}
}

// Parses the URL parameters and returns an object
function parseParms(str) {
	var pieces = str.split("&"), data = {}, i, parts;
	// process each query pair
	for (i = 0; i < pieces.length; i++) {
		parts = pieces[i].split("=");
		if (parts.length < 2) {
			parts.push("");
		}
		data[decodeURIComponent(parts[0])] = decodeURIComponent(parts[1]);
	}
	return data;
}

// Returns the token from the URL hash
function getToken() {
	//substring(1) to remove the '#'
	hash = parseParms(document.location.hash.substring(1));
	return hash.access_token;
}

// Send the user to the authorize endpoint for login and authorization
function authorize() {
	window.location = "https://api.byu.edu/authorize?response_type=token&scope=openid&client_id=" + settings.client_id + "&redirect_uri=" + settings.callback_url;
}

// Make a call using our token to the Echo API
function testCall() {
	$.ajax({
		url: "https://api.byu.edu/echo/v1/echo/Hello There!",
		method: "GET",
		headers: {
			"Authorization" : "Bearer " + token
		},
		success: function(response) {
			$("#response-code").html(JSON.stringify(response, null, 2));
			Prism.highlightAll();
		}
	});
}
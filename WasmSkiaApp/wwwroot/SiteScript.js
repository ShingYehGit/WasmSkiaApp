function helloFunction() {
    alert("Hello Blazor Web Assembly");
}

function showAlert(name) {
    alert('Hello ' + name);
}

function RemoveOnClickHandler(Id_name) {
    let elem = document.getElementById(Id_name);
    if (elem) {
        elem.removeAttribute("onclick");
    }
}

function AddOnClickHandler(Id_name) {
    let elem = document.getElementById(Id_name);
    if (elem) {
        elem.addAttribute("onclick");
    }
}

function EnableAllSubDivs(Id_name) {
    //The special string "*" represents all elements
    var nodes = document.getElementById(Id_name).getElementsByTagName('*');
    for (var i = 0; i < nodes.length; i++) {
        nodes[i].disabled = false;
    }


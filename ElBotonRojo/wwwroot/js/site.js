//testea githuba
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//var makeUnselectable = function ($target) {
//    $target
//        .addClass('unselectable') // All these attributes are inheritable
//        .attr('unselectable', 'on') // For IE9 - This property is not inherited, needs to be placed onto everything
//        .attr('draggable', 'false') // For moz and webkit, although Firefox 16 ignores this when -moz-user-select: none; is set, it's like these properties are mutually exclusive, seems to be a bug.
//        .on('dragstart', function () { return false; });  // Needed since Firefox 16 seems to ingore the 'draggable' attribute we just applied above when '-moz-user-select: none' is applied to the CSS 

//    $target // Apply non-inheritable properties to the child elements
//        .find('*')
//        .attr('draggable', 'false')
//        .attr('unselectable', 'on');
//};

function irAJugar() {
    window.location = '../Partidas/Create';
}

var pulsaciones = 0;
var executed = false;
var timerON = false;
var tiempoCumplido = false;

function contarClick() {
    if (document.getElementById("IdJugador").value != -1) {
        if (!tiempoCumplido) {
            if (!timerON) {
                chronoStart()
                timerON = true;
            }
            pulsaciones += 1;
            document.getElementById("IdJugador").disabled = true;
            document.getElementById("newPlayer").disabled = true;
            document.getElementById("pulsaciones").innerHTML = "Clicks: " + pulsaciones;
            document.getElementById("Clicks").value = pulsaciones;
            setTimeout(send, 5000)
        }
    } else {
        mostrarValidacion();
    }

};

function mostrarValidacion() {
    document.getElementById("validacion").innerHTML = "¡Ups! Te olvidaste de algo";
    document.getElementById("validacion2").innerHTML = "Debes seleccionar un jugador";
}

function borrarValidacion() {
    document.getElementById("validacion").innerHTML = "";
    document.getElementById("validacion2").innerHTML = "";
}

function send() {
    document.getElementById("botonazo").disabled = true;
    document.getElementById("IdJugador").disabled = false;
    submit()
}
function submit() {
    if (!executed)
        $('form').submit();
    executed = true;
}

function nuevoJugador() {
    window.location = '../Jugadores/Create';
}

function sortTable() {
    var table, rows, switching, i, x, y, shouldSwitch;
    table = document.getElementById("Ranking");
    switching = true;
    /*Make a loop that will continue until
    no switching has been done:*/
    while (switching) {
        //start by saying: no switching is done:
        switching = false;
        rows = table.rows;
        /*Loop through all table rows (except the
        first, which contains table headers):*/
        for (i = 1; i < (rows.length - 1); i++) {
            //start by saying there should be no switching:
            shouldSwitch = false;
            /*Get the two elements you want to compare,
            one from current row and one from the next:*/
            x = rows[i].getElementsByTagName("TD")[1];
            y = rows[i + 1].getElementsByTagName("TD")[1];
            //check if the two rows should switch place:
            if (Number(x.innerHTML) < Number(y.innerHTML)) {
                //if so, mark as a switch and break the loop:
                shouldSwitch = true;
                break;
            }
        }
        if (shouldSwitch) {
            /*If a switch has been marked, make the switch
            and mark that a switch has been done:*/
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
        }
    }
}



var startTime = 0
var start = 0
var end = 0
var diff = 0
var timerID = 0

function chronoStart() {
    start = new Date()
    chrono()
}

function chrono() {
    end = new Date()
    diff = end - start
    diff = new Date(5000 - diff)
    var msec = diff.getMilliseconds()
    var sec = diff.getSeconds()
    if (msec < 10) {
            msec = "00" + msec
    }
    else if (msec < 100) {
            msec = "0" + msec
    }
    if (diff < 5) {
        document.getElementById("chronotime").innerHTML = "Tiempo: " + 0 + ":" + 0 + 0 + 0
        tiempoCumplido = true;
    } else {
        document.getElementById("chronotime").innerHTML = "Tiempo: " + sec + ":" + msec
        timerID = setTimeout("chrono()", 5)
    }
}




function changeImage() {
    document.images["jsbutton"].src = "/img/button2.png";
    return true;
}

function changeImageBack() {
    document.images["jsbutton"].src = "/img/button.png";
    return true;
}

function handleMDown() {
    document.images["jsbutton"].src = "/img/button2.png";
    return true;
}

function handleMUp() {
    document.images["jsbutton"].src = "/img/button.png";
    return true;
}
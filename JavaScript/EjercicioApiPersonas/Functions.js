url = "https://raulcrudapi.azurewebsites.net/api/personaapi/"
function mostrarPokemon() {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", url);
    console.log(miLlamada.responseText)
    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            console.log("esta cargando")
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            console.log("entra");
            var arraypersonas = JSON.parse(miLlamada.responseText);
            mostrarDatos(arraypersonas);
    }
    };
    miLlamada.send();
}

function mostrarDatos(personas){
    console.log(personas);
    document.getElementById("calta").innerHTML =
    personas.map((persona) =>
        `<li>${persona.nombre} <img src="${persona.foto}" width="100px"/> <i class="fa fa-trash-o" onclick="eliminar(${persona.id})"><i></li>`).join("");
}

function eliminar(id) {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("DELETE", "https://raulraulcrudapi.azurewebsites.net/api/personaapi/" + id);
    if (miLlamada.readyState == 4 && miLlamada.status == 200) {
        mostrarPokemon();
    }
    miLlamada.send();
}
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
    document.getElementById("calta").innerHTML =
    personas.map((persona) =>
        `<li>${persona.nombre} <img src="${persona.foto}" width="100px"/> <i class="fa fa-trash-o" onclick="eliminarPersona(${persona.id})"></i></li>`).join("");
}

function eliminarPersona(id) {

    if(window.confirm("¿Desea eliminar la persona?")){
        var miLlamada = new XMLHttpRequest();

    miLlamada.open("DELETE", url + id);

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            // aquí se puede poner una imagen de un reloj o un texto “Cargando”
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            window.alert("Se ha eliminado la persona");
            mostrarPokemon();
        }
    };
    miLlamada.send();
    }else{
        window.alert("No se ha eliminado la persona");
    }
    
}
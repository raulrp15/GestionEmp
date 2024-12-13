function pedirDatos()
{
    document.getElementById("lista").innerHTML=""
    let nombre = document.getElementById("nombre").value
    var miLlamada = new XMLHttpRequest();
    let url = "https://pokeapi.co/api/v2/pokemon/" + nombre
    miLlamada.open("GET", url);
    miLlamada.onreadystatechange = function () {
    if (miLlamada.readyState < 4) {

    }
    else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
        let pokemon = JSON.parse(miLlamada.responseText);
        document.getElementById("lista").innerHTML += `<li>${pokemon.forms[0].name}</li>`
        
    }};
    
    miLlamada.send();

}
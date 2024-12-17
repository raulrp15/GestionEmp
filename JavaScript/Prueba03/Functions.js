window.onload = inicializaEventos;

function inicializaEventos() {
    mostrarDatos("https://pokeapi.co/api/v2/pokemon");
}

function mostrarDatos(url) {
    var miLlamada = new XMLHttpRequest();

    miLlamada.open("GET", url);

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var arrayPokemon = JSON.parse(miLlamada.responseText);
            listarPokemon(arrayPokemon);
        }
    };
    miLlamada.send();
}

function listarPokemon(array) {
    document.getElementById("pokemons").innerHTML += array.results.map((pokemon) =>
        `<option id="${pokemon.name}" value="${pokemon.url}">
            ${pokemon.name[0].toUpperCase()}${pokemon.name.substring(1)}
        </option>`
    ).join("");

    document.getElementById("pokemons").addEventListener("change", function() {
        mostrarPokemon(this.value);
    });
}

function mostrarPokemon(url) {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", url);

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var pokemon = JSON.parse(miLlamada.responseText);
            console.log(pokemon);
            document.getElementById("calta").innerHTML = `<card id="detalles">
        <img id="imagen" src="${pokemon.sprites.front_default}">
        <h1 id="nombre">${pokemon.name}</h1>
        <h2 id="Tipo">Tipos: 
        </h2>
        <audio id="audio" src="${pokemon.cries.latest}" controls ></audio>
        </card>`;
        if(pokemon.types[0].type.name!=null){
            document.getElementById("Tipo").innerHTML += `${pokemon.types[0].type.name[0].toUpperCase()}${pokemon.types[0].type.name.substring(1)} `;
        }
        if(pokemon.types[1].type.name!=null){
            document.getElementById("Tipo").innerHTML += `${pokemon.types[1].type.name[0].toUpperCase()}${pokemon.types[1].type.name.substring(1)} `;
        }
    }
    };
    miLlamada.send();
}
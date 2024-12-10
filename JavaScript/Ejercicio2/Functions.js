class Persona {

    constructor(nombre, apellido) {
        this.nombre = nombre;
        this.apellido = apellido;
    }
}

window.onload = inicializaEventos;

function inicializaEventos() {
    document.getElementById("saludar").addEventListener("click", saludar, false);
}

function saludar() {
    let persona = new Persona(document.getElementById("nombre").value, document.getElementById("apellido").value);
    alert("Hola " + persona.nombre + " " + persona.apellido);
}
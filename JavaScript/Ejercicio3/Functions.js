class Marca
{
    constructor(id, nombre)
    {
        this.id = id;
        this.nombre = nombre;
    }
}

class Modelo
{
    constructor(id, nombre, marca)
    {
        this.id = id;
        this.nombre = nombre;
        this.marca = marca;
    }
}
window.onload = listadoMarcas;

let listMarcas = [
    new Marca(1, "Toyota"),
    new Marca(2, "Honda"),
    new Marca(3, "Nissan"),
    new Marca(4, "Hyundai"),
    new Marca(5, "Kia"),
    new Marca(6, "Mazda"),
    new Marca(7, "Ford"),
    new Marca(8, "Chevrolet"),
    new Marca(9, "Dodge"),
];

let listModelos = [
    new Modelo(1, "Corolla", 1),
    new Modelo(2, "Civic", 2),
    new Modelo(3, "Camry", 1),
    new Modelo(4, "Accord", 2),
    new Modelo(5, "Rav4", 3),
    new Modelo(6, "Altima", 3),
    new Modelo(7, "Elantra", 4),
    new Modelo(8, "Sonata", 4),
    new Modelo(9, "Genesis", 5),
    new Modelo(10, "Fusion", 5),
    new Modelo(11, "Mazda3", 6),
    new Modelo(12, "F-150", 7),
    new Modelo(13, "Mustang", 7),
    new Modelo(14, "Cruze", 8),
    new Modelo(15, "Camaro", 8),
];

function listadoMarcas() {
    const select = document.getElementById("marcas");
    const option = listMarcas
        .map((marca) => `<option value="${marca.id}">${marca.nombre}</option>`)
        .join("");
    select.innerHTML += option;
}

function showModels() {
    const marca = parseInt(document.getElementById("marcas").value); 
    const listaModelos = document.getElementById("modelos");
    listaModelos.innerHTML = ""; 

    const modelos = listModelos
        .filter((modelo) => modelo.marca === marca)
        .map((modelo) => `<li>${modelo.nombre}</li>`)
        .join("");

    listaModelos.innerHTML = modelos;
}
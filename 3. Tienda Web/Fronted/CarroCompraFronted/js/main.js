const div = document.getElementById('productos')
const divbuscar = document.getElementById('productosBuscar')
const mirar = document.getElementById('mirar')
const container = document.querySelector('.container')
const agregar = document.querySelector('.cantidadProductos')
const resgistro = document.querySelectorAll('#cuentasRegistro')
const sesionIniciada = document.getElementById('sesionIniciada')
const cuentas = document.getElementById('cuentas')
const cerrarSesion = document.getElementById('cerrarSesion')

let productos
let cantidadProductos = 0

function DeterminarInicioSesion(){
    const datos = localStorage.getItem('InicioSesion')
    if(datos){
        sesionIniciada.style.display = 'flex'
        cuentas.style.display = 'none'
    }

    cerrarSesion.addEventListener('click', () => {
        localStorage.removeItem('InicioSesion')
        window.location.reload()
    })
}

function pintarTarjetas(response) {
    response.forEach(element => {
        div.innerHTML += `
            <div class="tarjeta">
                <img class="imagen" src=${element["urlImage"]} alt="Producto">
                <h3>${element["titulo"]}</h3>
                <strong>${element["precio"]} $</strong>
                <span>${element["descripcion"]}</span>
            </div>
        `
    });
    productos = document.querySelectorAll('.tarjeta')

    productos.forEach(element => {
        element.addEventListener('click', () => {
            if(window.screen.width <= 500){
                container.style.display = 'none'
            }
            mirar.style.display = 'flex'
            mirar.innerHTML = `
                <img class="imagen" src="${element.childNodes[1].currentSrc}" alt="imagen">
                <h2>${element.childNodes[3].innerText}</h2>
                <strong>${element.childNodes[5].innerText}</strong>
                <p>${element.childNodes[7].innerText}</p>
    
                <a class="btn" href="#" onclick="AgregarCarrito('${element.childNodes[3].innerText}','${element.childNodes[5].innerText}')">Agregar Al Carrito</a>
            `
        })
    })

    const datos = localStorage.getItem('productos')
    let datosArrays = []

    if (datos) {
        datosArrays = JSON.parse(datos);
        if (!Array.isArray(datosArrays)) {
            datosArrays = [];
        }
    }
    agregar.style.display = 'flex'
    cantidadProductos = datosArrays.length
    agregar.innerHTML = cantidadProductos

}

async function iniciarCarrito() {
    divbuscar.style.display = 'none'
    await fetch('https://localhost:7176/api/Datos/Producto', {
        method: 'GET',
        body: JSON.stringify(),
        headers: {
            "Context-Type": "application/json",
        }
    })
        .then((res) => res.json())
        .catch((error) => div.innerHTML = '<p>Activa el server mardito</p>')
        .then((response) => {
            pintarTarjetas(response)
        })
}

function AgregarCarrito(titulo, precio) {
    const productos = {
        Titulo: titulo,
        Precio: precio
    }
    const datos = localStorage.getItem('productos')
    let datosArrays = []

    if (datos) {
        datosArrays = JSON.parse(datos);
        if (!Array.isArray(datosArrays)) {
            datosArrays = [];
        }
    }

    datosArrays.push(productos)
    cantidadProductos++
    agregar.style.display = 'flex'
    agregar.innerHTML = cantidadProductos
    localStorage.setItem('productos', JSON.stringify(datosArrays))
}

function BuscarProductos() {
    setTimeout(() => {
        MostrarProducto()
    }, 1500)
}

async function MostrarProducto() {
    const productoABuscar = document.getElementById('texto').value
    console.log("Producto: " + productoABuscar)
    try {
        await fetch(`https://localhost:7176/api/Datos/Buscar?nombreProducto=${productoABuscar}`, {
            method: 'GET',
            headers: {
                "Context-Type": "application/json",
            },
            body: JSON.stringify(productoABuscar.value)
        })
            .then((res) => res.json())
            .catch((error) => alert('no funca'))
            .then((rep) => imprimirresultado(rep))
    } catch {
        volverPintar()
    }
}

function imprimirresultado(rep) {
    console.log(rep);
    let texto = ""
    
    div.style.display = 'none'
    divbuscar.style.display = 'grid'
    if(rep == ""){
        divbuscar.style.display = 'flex'
        divbuscar.style.textAlign = 'center'
        divbuscar.innerHTML = '<h1>No se encuentran resultado</h1>'
        return
    }

    rep.forEach(element => {
        texto += `
            <div class="tarjeta">
                <img class="imagen" src=${element["urlImage"]} alt="Producto">
                <h3>${element["titulo"]}</h3>
                <strong>${element["precio"]} $</strong>
                <span>${element["descripcion"]}</span>
            </div>
        `
    })
    divbuscar.innerHTML = texto
}

function volverPintar() {
    div.style.display = 'grid'
    divbuscar.style.display = 'none'
}

function AdministradorCuenta(){
    resgistro.forEach((elem) => {
        elem.addEventListener('click', () => {
            elem.href = "./view/AgregarUsuario.html"
            sessionStorage.setItem("datoRegistro",elem.innerText)
        })
    })
    
}
AdministradorCuenta()
iniciarCarrito()
DeterminarInicioSesion()
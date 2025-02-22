const input = document.getElementById('correo')
const contrasenia = document.getElementById('contrasenia')
const div = document.getElementById('warning')
const botones = document.querySelectorAll('.proximo')
const sectionRegistrar = document.getElementById('registrar')
const sectionDatosExtras = document.getElementById('datosExtras')
const sectionSobreTi = document.getElementById('sobreTi')
const sectionTerminosCondicionales = document.getElementById('TerminosCondicionales')
const barraProgreso = document.getElementById('Progreso')
const activo = document.getElementById('mirar')
const desativado = document.getElementById('ocultar')
const flechasIndicador = document.querySelectorAll('.flecha')
const nombreUsuario = document.getElementById('nombre')
const dia = document.getElementById('dia')
const selectMes = document.querySelector('select[name="select"]')
const anio = document.getElementById('anio')
const botonesGenero = document.querySelectorAll('input[name="genero"]')
const terminos = document.querySelectorAll('#terminos')

let mesSeleccionado = 0
let genero = ""
let activador = true;

selectMes.addEventListener('change', () => {
    mesSeleccionado = selectMes.value
})

botonesGenero.forEach(btn => {
    btn.addEventListener('click', () => {
        const btnSeleccionado = document.querySelector('input[name="genero"]:checked')
        genero = btnSeleccionado.nextElementSibling
    })
})

activo.addEventListener('click', () => {
    if (activador) {
        activo.style.display = 'none'
        desativado.style.display = 'block'
        activador = false;
        contrasenia.type = 'text'
    }
})

desativado.addEventListener('click', () => {
    if (!activador) {
        desativado.style.display = 'none'
        activo.style.display = 'block'
        activador = true;
        contrasenia.type = 'password'
    }
})

input.addEventListener('focusout', () => {
    if (input.value == '') {
        div.style.display = 'flex'
        input.style.border = '1px solid rgb(214,109,117)'
    }
})

botones.forEach((boton,i) => {
    boton.addEventListener('click', (event) => {
        if (i < botones.length - 1) {
            event.preventDefault();
        }
        if (i === 0 && DeterminarCorreo()) {
            barraProgreso.style.display = 'flex'
            sectionRegistrar.style.display = 'none'
            sectionDatosExtras.style.display = 'block'
        } else {
            div.style.display = 'flex'
            input.style.border = '1px solid rgb(214,109,117)'
        }
        if (i === 1) {
            if (DeterminarContrasenia()) {
                sectionDatosExtras.style.display = 'none'
                sectionSobreTi.style.display = 'block'
            }else {
                const div = contrasenia.parentNode
                div.style.border = '1px solid red'
            }
        } 
        if (i === 2) {
            if (DeterminarSobreTi()) {
                sectionSobreTi.style.display = 'none'
                sectionTerminosCondicionales.style.display = 'block'
            }
        }
        if (i === 3) {
            if (DeterminarTerminos()) {
                console.log('aaa')
            }
        }
    })
})

flechasIndicador.forEach((flecha, i) => {
    flecha.addEventListener('click', () => {
        if (i == 0) {
            barraProgreso.style.display = 'none'
            sectionRegistrar.style.display = 'block'
            sectionDatosExtras.style.display = 'none'
        } else if (i == 1) {
            sectionDatosExtras.style.display = 'block'
            sectionSobreTi.style.display = 'none'
        } else if (i == 2) {
            sectionSobreTi.style.display = 'block'
            sectionTerminosCondicionales.style.display = 'none'
        }
    })
})

function DeterminarCorreo() {
    let Correo = input.value;

    for (let i = 0; i < Correo.length; i++) {
        if (Correo[i] === '@') {
           return true
        }
    }
    return false
}

function DeterminarContrasenia() {
    return contrasenia.value != ""
}

function DeterminarSobreTi() {
    const diaValue = parseInt(dia.value);
    const mesValue = parseInt(selectMes.value);
    const anioValue = parseInt(anio.value);

    return nombreUsuario.value != ""
        && FechaValida(diaValue, mesValue, anioValue)
        && genero.innerText != ""
}

function FechaValida(dia, mes, anio) {
    const fecha = new Date(anio, mes - 1, dia)
    return fecha.getFullYear() === anio && fecha.getMonth() === mes - 1  && fecha.getDate() === dia
}

function DeterminarTerminos() {
    let aceptar = false

    if (Array.from(terminos).every(checkbox => checkbox.checked)) {
        aceptar = true
    }

    return aceptar
}
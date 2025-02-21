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

let activador = true;

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
    boton.addEventListener('click', () => {
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
            sectionSobreTi.style.display = 'none'
            sectionTerminosCondicionales.style.display = 'block'
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
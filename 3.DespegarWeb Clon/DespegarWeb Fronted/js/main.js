import { HeaderPagina } from "./../models/header.js"
import { FooterPagina } from "./../models/footer.js"
import { NavegacionPagina } from "./../models/navegacion.js"
import { AlojamientoPagina } from "./../models/navegacion.js"

const header = document.getElementById('header')
const footer = document.getElementById('footer')
const navegacion = document.querySelector('.navegacion')
const alojamiento = document.querySelector('.alojamientos')
const principal = document.getElementById('principal')
const volver = document.getElementById('volver')

let botonUsuario
let menuUsuario
let navegacionesPaginas

function determinarPagina() {
    navegacionesPaginas = document.querySelectorAll('#secciones')
    navegacionesPaginas.forEach(element => {

        valoresPordefecto(element)
        navegacionesPaginas[0].style.padding = '5px'
        navegacionesPaginas[0].style.borderBottom = ' 2px solid rgb(39, 5, 112)'
        navegacionesPaginas[0].childNodes[1].style.backgroundColor = 'rgb(39, 5, 112)'
        navegacionesPaginas[0].childNodes[3].style.color = 'rgb(39, 5, 112)'
        element.addEventListener('click', () => {
            navegacionesPaginas.forEach(el => {
                valoresPordefecto(el)
            })

            element.style.padding = '5px'
            element.style.borderBottom = ' 2px solid rgb(39, 5, 112)'
            element.childNodes[1].style.backgroundColor = 'rgb(39, 5, 112)'
            element.childNodes[3].style.color = 'rgb(39, 5, 112)'
        })
    })
}

function valoresPordefecto(element) {
    element.style.padding = '0px'
    element.style.borderBottom = 'none'
    element.childNodes[1].style.backgroundColor = 'transparent'
    element.childNodes[3].style.color = 'black'
}

function EscucharBotonUsuario() {
    botonUsuario.addEventListener('click', (e) => {
        e.preventDefault()
        principal.style.display = 'none'
        menuUsuario.style.display = 'flex'
    })


    volver.addEventListener('click', () => {
        principal.style.display = 'block'
        menuUsuario.style.display = 'none'
    })
}

window.addEventListener('load', () => {
    header.innerHTML = HeaderPagina
    footer.innerHTML = FooterPagina
    navegacion.innerHTML = NavegacionPagina
    alojamiento.innerHTML = AlojamientoPagina

    botonUsuario = document.getElementById('botonUsuario')
    menuUsuario = document.getElementById('menuUsuario')
    determinarPagina()
    if (document.body.clientWidth < 500) {
        EscucharBotonUsuario()
    }
})
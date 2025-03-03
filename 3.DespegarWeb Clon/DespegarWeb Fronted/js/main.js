import { HeaderPagina } from "./header.js"
import { FooterPagina } from "./footer.js"
import { NavegacionPagina } from "./navegacion.js"
import { AlojamientoPagina } from "./navegacion.js"

const header = document.getElementById('header')
const footer = document.getElementById('footer')
const navegacion = document.querySelector('.navegacion')
const alojamiento = document.querySelector('.alojamientos')

window.addEventListener('load', () => {
    header.innerHTML = HeaderPagina
    footer.innerHTML = FooterPagina
    navegacion.innerHTML = NavegacionPagina
    alojamiento.innerHTML = AlojamientoPagina
})
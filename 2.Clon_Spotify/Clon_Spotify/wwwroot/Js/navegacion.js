const cerrarSesion = document.getElementById('cerrarsesion')
const menu = document.getElementById('menuDesplegable')

let band = false

menu.addEventListener('click', () => {
    if (band) {
        cerrarSesion.style.display = 'flex'
        band = false
    } else {
        cerrarSesion.style.display = 'none'
        band = true
    }
})

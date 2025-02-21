const activo = document.getElementById('mirar')
const desativado = document.getElementById('ocultar')
const input = document.getElementById('contrasenia')

let activador = true;

activo.addEventListener('click', () => {
    if (activador) {
        activo.style.display = 'none'
        desativado.style.display = 'block'
        activador = false;
        input.type = 'text'
    }
})

desativado.addEventListener('click', () => {
    if (!activador) {
        desativado.style.display = 'none'
        activo.style.display = 'block'
        activador = true;
        input.type = 'password'
    }
})
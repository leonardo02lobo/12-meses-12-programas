const activo = document.getElementById('activo')
const desativado = document.getElementById('desactivado')

let activador = true;

activo.addEventListener('click', () => {
    if (activador) {
        activo.style.display = 'none'
        desativado.style.display = 'block'
        activador = false;
    }
})

desativado.addEventListener('click', () => {
    if (!activador) {
        desativado.style.display = 'none'
        activo.style.display = 'block'
        activador = true;
    }
})
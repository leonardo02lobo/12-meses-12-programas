const botones = document.querySelectorAll('#btn-index')
const artistas = document.getElementById('artistas')

let btnPresionado = null

botones[0].style.background = 'white';
botones[0].style.color = 'black';

botones.forEach((btn, i) => {
    btn.addEventListener('click', function () {
        if (btnPresionado) {
            btnPresionado.style.background = 'rgb(42,42,42)';
            btnPresionado.style.color = 'rgb(237,237,237)';
        }
        if (i == 1) {
            artistas.style.display = 'none'
        } else {
            artistas.style.display = 'block'
        }

        btnPresionado = btn

        botones[0].style.background = 'rgb(42,42,42)';
        botones[0].style.color = 'rgb(237,237,237)';
        btnPresionado.style.background = 'white';
        btnPresionado.style.color = 'black';
    })
})
const cancion = document.querySelectorAll('.cancion')

cancion.forEach(can => {
    can.addEventListener('click', () => {
        document.querySelector('.datos-cancion-sonando').children[0].innerHTML = can.querySelector('.musica').children[0].textContent
        document.querySelector('.datos-cancion-sonando').children[1].innerHTML = can.querySelector('.musica').children[1].textContent
        document.querySelector('.datos-cancion').children[0].src = document.querySelector('.VistaPlayList').children[0].src
    })
})
const flechasIzquierda = document.querySelectorAll('#li1');
const flechasDerecha = document.querySelectorAll('#li2');

flechasIzquierda.forEach((flecha, i) => {
    flecha.addEventListener('click', function () {
        moverCarrusel(this, -1);
    });
});

flechasDerecha.forEach((flecha, i) => {
    flecha.addEventListener('click', function () {
        moverCarrusel(this, 1);
    });
});

function moverCarrusel(flecha, direccion) {
    const ul = flecha.parentNode;
    const section = ul.parentNode;
    const divGrande = section.querySelector('#divGrande');
    const elementos = divGrande.children;
    const totalElementos = elementos.length;
    const elementosPorSeccion = 4;
    const totalSecciones = Math.ceil(totalElementos / elementosPorSeccion);

    let posicionActual = parseInt(divGrande.getAttribute('data-posicion')) || 0;
    posicionActual += direccion;

    if (posicionActual < 0) {
        posicionActual = 0;
    } else if (posicionActual >= totalSecciones) {
        posicionActual = totalSecciones - 1;
    }

   
    const desplazamiento = posicionActual * -50;
    divGrande.style.transform = `translateX(${desplazamiento}%)`;
    divGrande.setAttribute('data-posicion', posicionActual);
}

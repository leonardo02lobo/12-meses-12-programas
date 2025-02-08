const flecha = document.querySelectorAll('#li1');

flecha.forEach((flechas, i) => {
    flecha[i].addEventListener('click', function () {
        const ul = this.parentNode;
        const section = ul.parentNode;

        const divGrande = section.querySelector('#divGrande');
        let posicion = i * -50;

        divGrande.style.transform = `translateX(${posicion}%)`;
    });
})

const flecha1 = document.querySelectorAll('#li2');

flecha1.forEach((flechas, i) => {
    flecha1[i].addEventListener('click', function () {
        const ul = this.parentNode;
        const section = ul.parentNode;

        const divGrande = section.querySelector('#divGrande');
        let posicion = i * -50;

        divGrande.style.transform = `translateX(${posicion}%)`;
    });
})
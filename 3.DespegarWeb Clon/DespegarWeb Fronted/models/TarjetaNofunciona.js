const tarjetaDiv = document.getElementById('tarjeta')

let tarjetas = []

class Tarjeta {
    constructor(titulo, imagen, destinos) {
        this.titulo = titulo;
        this.imagen = imagen;
        this.destinos = Array.isArray(destinos) ? destinos : [];
    }
}

const tarjeta1 = new Tarjeta("Hoteles","https://img.icons8.com/ios/32/empty-bed.png", ["Hoteles en Caracas","Hoteles en Aruba","Hoteles en Panama","Hoteles en Buenos aires","Hoteles en Quito"])
const tarjeta2 = new Tarjeta("Vuelos","https://img.icons8.com/fluency-systems-regular/32/airport.png", ["Vuelos a Caracas","Vuelos a Panama","Vuelos a Buenos aires","Vuelos a Madrid","Vuelos a Miami"])
const tarjeta3 = new Tarjeta("Paquetes","https://img.icons8.com/ios/32/neighborhood.png", ["Paquetes a Miami","Paquetes a Rio de Janeiro","Paquetes a New York","Paquetes a Caracas","Paquetes a Panama"])
const tarjeta4 = new Tarjeta("Carros","https://img.icons8.com/ios/32/suv.png", ["Alquiler de carros en Cusco","Alquiler de carros en Miami","Alquiler de carros en Buenos Aires","Alquiler de carros en Panamá","Alquiler de carros en Curazao"])

tarjetas.push(tarjeta1)
tarjetas.push(tarjeta2)
tarjetas.push(tarjeta3)
tarjetas.push(tarjeta4)

export function ImprimirTarjetas() {
    tarjetas.forEach(tarjeta => {
        tarjetaDiv.innerHTML += `
                <div class="tarjeta">
                    <div class="titulo">
                        <img width="32" height="32" src="${tarjeta.imagen}" alt="empty-bed" />
                        <p>${tarjeta.titulo}</p>
                    </div>
                    <article>
                    ${tarjeta.destinos.map(destino => {
                        return `<a href="#">${destino}</a>`}).join('')}
                    </article>
                </div>
        `
    })
    
}

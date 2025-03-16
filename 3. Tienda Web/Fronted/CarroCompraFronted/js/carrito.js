const producto = localStorage.getItem('productos')
const tbody = document.getElementById('tbody')


if (producto) {
    const datosProducto = JSON.parse(producto)
    RellenarTabla(datosProducto)
  } else {
    console.log('User data not found in local storage')
  }


  function RellenarTabla(datosProducto){
    datosProducto.forEach(element => {
        let filas = `
            <tr>
                <td>${element.Titulo}</td>
                <td>${element.Precio}</td>
                <td>
                    <a href="" class="comprar">Comprar Producto</a>
                </td>
            </tr>
        `  
        tbody.innerHTML += filas
    });
    
  }
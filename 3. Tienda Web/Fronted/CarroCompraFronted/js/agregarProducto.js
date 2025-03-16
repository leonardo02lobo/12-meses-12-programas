const btn = document.getElementById('datos')

btn.addEventListener('submit', async function (e) {
    e.preventDefault()

    const form = e.target

    const producto = {
        titulo: form.producto.value.trim(),
        descripcion: form.descripcion.value.trim(),
        Imagen: form.imagen.value.trim(),
        Precio: form.precio.value
    }
    
    try {
        const response = await fetch('https://localhost:7176/api/CRUD/Create', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(producto) 
        });

        if (response.ok) {
            console.log('funca')
            form.reset()
            window.location.href = '/CarroCompraFronted/index.html'
        } else {
            console.log('no funca');
            const errorData = await response.json();
            console.error('Error del servidor:', errorData);
        }
    } catch (e) {
        console.error(e)
        alert('Ocurrio un error al intentar agregar el producto')
    }
})
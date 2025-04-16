const iniciar = document.getElementById('iniciarSesion')
const crear = document.getElementById('crearCuenta')
const registrarse = document.getElementById('registrarse')
const iniciarsesion = document.getElementById('iniciarsesion')
const enviarDatos = document.getElementById('datos')
const iniciarSesionForm = document.getElementById('IniciarSesionFrom')

function CrearCuenta(){
    iniciarsesion.addEventListener('click', () => {
        iniciar.style.display = 'block'
        crear.style.display = 'none'
    })
}

function IniciarSesion(){
    registrarse.addEventListener('click', () => {
        iniciar.style.display = 'none'
        crear.style.display = 'block'
    })
}

function EscucharFormularioCrearCuenta(){
    enviarDatos.addEventListener('submit',async function (e)  {
        e.preventDefault()

        const form = e.target

        const UsuarioJSON = {
            usuario: form.usuario.value.trim(),
            contrasenia: form.contrasenia.value.trim()
        }
        try{
            const response = await fetch('https://localhost:7176/api/Usuario/CreateUser',{
                method: "POST",
                headers:{
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(UsuarioJSON),
            })

            if(response.ok){
                console.log('funca');  
                form.reset()
                iniciar.style.display = 'block'
                crear.style.display = 'none'        
            }else{
                console.log('no funca'); 
                const errorData = await response.json();
                console.error('Error del servidor:', errorData);           
            }
        }catch(e){
            console.log(e);
            console.log('no funca no se porque')            
        }
        
    })
}

function EscucharFormularioIniciarSesion(){
    iniciarSesionForm.addEventListener('submit', async function (e) {
        e.preventDefault()

        const form = e.target

        const DatosUsuario = {
            usuario: form.usuario.value.trim(),
            contrasenia: form.contrasenia.value.trim()
        }

        try{
            const response = await fetch('https://localhost:7176/api/Usuario/GetUser',{
                method: "POST",
                headers: {
                    "content-Type": "application/json",
                },
                body: JSON.stringify(DatosUsuario)
            })

            if(response.ok){
                const res = response.json()

                localStorage.setItem("InicioSesion",res)
                window.location.href = '/index.html'
            }else{
                alert('No a podido iniciar Sesion')
            }
        }catch(e){
            console.log(e)
            console.log('error al iniciar el fetch')
        }
    })
}

window.addEventListener('load', () => {
    if(sessionStorage.getItem("datoRegistro") === "Iniciar Sesion"){
        iniciar.style.display = 'block'
    }else {
        crear.style.display = 'block'
    }
    IniciarSesion()
    CrearCuenta()
    EscucharFormularioCrearCuenta()
    EscucharFormularioIniciarSesion()
})


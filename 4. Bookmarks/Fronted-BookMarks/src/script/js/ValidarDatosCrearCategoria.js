import { AddCategory } from "../../services/DataCategories"

const formCategory = document.getElementById("formCategory")

formCategory.addEventListener("submit", async (e) => {
    e.preventDefault()
    const data = ValidarDatos()
    if(!data){
        alert("Faltan datos por rellenar")
        return
    }
    const dataForm = {
        name: formCategory.elements[0].value
    }
    const result = await AddCategory(dataForm)
    if(result.status === 200){
        window.location.href = "/"
    }else{
        alert("La categoria ya existe, por favor elige otra")
    }
})

function ValidarDatos(){
    return formCategory.elements[0].value !== ""
}
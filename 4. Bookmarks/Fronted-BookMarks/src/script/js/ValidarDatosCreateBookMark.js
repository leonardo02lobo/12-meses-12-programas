import { AddBokMark } from "../../services/DataBookMarks";

const formBookMark = document.getElementById("formBookMark");

formBookMark.addEventListener("submit", async (e) => {
    e.preventDefault()
    const band = ValidarDatos()

    if (band) {
        const formData = {
            title: formBookMark.elements[0].value,
            url: formBookMark.elements[1].value,
            description: formBookMark.elements[2].value,
            categoryId: formBookMark.elements[3].value,
            createdAt: formBookMark.elements[4].value,
        }
        const response = await AddBokMark(formData)
        if (response.ok) {
            alert("Se ha creado el BookMark")
            window.location.href = "/"
        }
        else if (response.status == 400) {
            alert("Error al crear el BookMark")
        }
    }
})

function ValidarDatos() {
    if (formBookMark.elements[0].value == "") {
        alert("El campo nombre no puede estar vacio")
        return false
    } else if (formBookMark.elements[1].value == "") {
        alert("El campo url no puede estar vacio")
        return false
    } else if (formBookMark.elements[2].value == "") {
        alert("El campo descripcion no puede estar vacio")
        return false
    } else if (formBookMark.elements[3].value == "") {
        alert("El campo categoria no puede estar vacio")
        return false
    } else if (formBookMark.elements[4].value == "") {
        alert("El campo Fecha no puede estar vacio")
        return false
    }
    return true
}
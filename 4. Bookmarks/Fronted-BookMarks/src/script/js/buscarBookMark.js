import { CardSearch } from "../../modules/CardBookMarkSearch"
import { SearchBookMark } from "../../services/Search"

const buscar = document.getElementById('buscar')
const search = document.getElementById('search')
const result = document.getElementById('result')

buscar.addEventListener('click', async () => {
    const datos = await SearchBookMark(search.value)
    console.log(datos)
    if (Array.isArray(datos)) {
        let data = '';
        datos.map(element => {
            data += CardSearch(element.title, element.url,element.id)
        })
        if (data == '') {
            result.innerHTML = "No Existen BookMark con ese nombre"
            return null;
        }

        result.innerHTML = data;
    }
})
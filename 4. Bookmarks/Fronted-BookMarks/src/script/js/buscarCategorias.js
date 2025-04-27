import { CardSearch } from "../../modules/CardBookMarkSearch"
import { GetBookMarks } from "../../services/DataBookMarks"
import { FindCategories } from "../../services/DataCategories"

const grupoBotones = document.querySelectorAll('#grupoBotones')
const categories = document.getElementById('categories')

grupoBotones[0].addEventListener('click', async () => {
    const datos = await GetBookMarks();
    PintarCategorias(datos)
})

grupoBotones.forEach(element => {
    element.classList.add('text-gray-500')
    
    element.addEventListener('click', async () => {
        grupoBotones.forEach(btn => {
            btn.classList.remove('underline')
            btn.classList.remove('text-white')
        })
        element.classList.add('underline');
        element.classList.add('text-white');
        if (element.textContent.replace(/\s+/g, ' ').trim() !== 'Todos') {
            const datos = await FindCategories(element.innerHTML);
            PintarCategorias(datos)
        }else{
            const datos = await GetBookMarks();
            PintarCategorias(datos)
        }
    })
})

function PintarCategorias(datos) {
    let data = ""
    datos.map(element => {
        data += CardSearch(element.title, element.url, element.id)
    })
    categories.innerHTML = data
}
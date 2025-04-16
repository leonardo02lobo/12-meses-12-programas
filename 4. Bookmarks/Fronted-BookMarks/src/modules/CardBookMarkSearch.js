export function CardSearch(title,url,id){
    return `
    <div class="bg-gray-900 border-2 border-gray-700 rounded-2xl p-4 text-2xl flex flex-col gap-4 justify-center hover:bg-gray-800 transition-all ">
        <h1 class="text-white">${title}</h1>
        <span>Url: <a href=${url} target="_blank" class="text-blue-700 hover:underline hover:text-blue-800">${url}</a></span>
        <a href="/Mirar/${id}" class="text-blue-500 underline">Mirar Mas Detalles</a>
    </div>
    `
}
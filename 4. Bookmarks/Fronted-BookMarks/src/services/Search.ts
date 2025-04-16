export async function SearchBookMark(bookmark:string){
    try {
        const response = await fetch(`http://localhost:5299/api/BookMark/FindSearchBookMark?Title=${bookmark}`,{
            method: "GET",
            headers: {
                "Content-Type": "application/json"
            }
        });
        const data = await response.json();
        return data;
    } catch (error) {
        console.log((error as Error).message)
        return null;
    }
}
import type { BookMark } from "../Models/BookMarks";

export async function GetBookMarks(): Promise<BookMark[]>{
    try{
        const response = await fetch("http://localhost:5299/api/BookMark/GetBookMarks");
        const data = await response.json();
        return data;
    }catch(e){
        return []
    }
}

export async function GetBookMarksByID(id: number){
    try{
        const response = await fetch(`http://localhost:5299/api/BookMark/FindId?id=${id}`);
        if(!response.ok){
            return null;
        }
        const data = await response.json()
        return data;
    }catch(e){
        return null;
    }
}
import type { Category } from "../Models/Category";

export async function GetCategories(): Promise<Category[]> {
    try {
        const response = await fetch('http://localhost:5299/api/Categories/GetCategories');

        if (!response.ok) {
            return [];
        }

        const data: Category[] = await response.json();
        return data;
    } catch (e) {
        console.log((e as Error).message)
        return [];
    }
}

export async function FindCategories(name: string): Promise<Category[]> {
    try {
        const response = await fetch(`http://localhost:5299/api/BookMark/FindByCategory?categories=${name.replace(' ','')}`,{
            method: "GET",
            headers:{
                "Content-Type": "application/json"
            }
        });

        if (!response.ok) {
            return [];
        }

        const data: Category[] = await response.json();
        return data;
    } catch (e) {
        console.log((e as Error).message)
        return [];
    }
}

export async function AddCategory(category: Category){
    try {
        const response = await fetch('http://localhost:5299/api/Categories/AddCategory',{
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(category)
        })
        return response
    } catch (error) {
        console.log((error as Error).message)
    }
}
import type { Category } from "./Category";

export interface BookMark{
    id: number;
    title:string;
    url:string;
    description?:string;
    categoryId:number;
    createAt:Date;
    category: Category;
}
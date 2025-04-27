# 4. BookMarks

#### El bookmark es una manera de poder guardar las urls y tenerlas de manera ordenadas, esto es muy util para poder tener las cosas bien ordenadas. Ahora bien el proyecto fue creado con el fin de mejorar mis habilidades con las uniones en SQL


## Modelo de la Base de datos

```
BookMarks
    id -> Primary Key
    Title -> Varchar, not null 
    url -> Varchar, not null 
    Description -> Varchar, not null 
    categoryId -> Varchar, not null 
    CreatedAt -> Varchar, not null 

BookMarks_Tags
    BookMarkId -> Foreign Key
    tagId -> Foreign Key

Categories
    id -> primary Key
    name -> Varchar, not null 

Tags
    id -> primary Key
    name -> Varchar, not null 
```

## API de la aplicacion

### El backend esta realizado completamente con C# (ASP.NET) junto a EntityFramework para el manejo de la Base de datos de una manera mas Comoda, al igual que usamos C# en modo de API para poder consumirla luego en el Frontend

## Frontend de la aplciacion

### El Frontend esta realizado con Astro, Typescript y Javascript, son tecnologias las cuales son tecnologias que tienen un buen potencial juntos y se pueden construir aplicaciones de buena robustes
import projectJSON from "./../data/project.json"
import type { project } from "../models/projectModel"


export function ObtenerDatos() {
    const datos: project[] = []

    projectJSON.forEach((element: project) => {
        datos.push(element)
    })
    return datos
}
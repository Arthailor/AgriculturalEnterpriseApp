import { $host } from "./index"

//Animals
export const fetchAnimals = async (page, limit) => {
    const { data } = await $host.get('api/animals', {
        params: {
            page, limit
        }
    })
    return data
}

export const createAnimal = async (pastureid, animal) => {
    const { data } = await $host.post(`api/animals?PastureId=${pastureid}`, animal)
    return data
}

export const deleteAnimal = async (id) => {
    const { data } = await $host.delete('api/animals/' + id)
    return data
}

export const updateAnimal = async (id, animal) => {
    const { data } = await $host.put(`api/animals/${id}`, animal)
    return data
}
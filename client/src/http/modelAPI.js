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

//Pastures
export const fetchPastures = async (page, limit) => {
    const { data } = await $host.get('api/pastures', {
        params: {
            page, limit
        }
    })
    return data
}

export const createPasture = async (fieldid, pasture) => {
    const { data } = await $host.post(`api/pastures?FieldId=${fieldid}`, pasture)
    return data
}

export const deletePasture = async (id) => {
    const { data } = await $host.delete('api/pastures/' + id)
    return data
}

export const updatePasture = async (id, pasture) => {
    const { data } = await $host.put(`api/pastures/${id}`, pasture)
    return data
}

//Crops
export const fetchCrops = async (page, limit) => {
    const { data } = await $host.get('api/crops', {
        params: {
            page, limit
        }
    })
    return data
}

export const createCrop = async (crop) => {
    const { data } = await $host.post(`api/crops`, crop)
    return data
}

export const deleteCrop = async (id) => {
    const { data } = await $host.delete('api/crops/' + id)
    return data
}

export const updateCrop = async (id, crop) => {
    const { data } = await $host.put(`api/crops/${id}`, crop)
    return data
}

//Fields
export const fetchFields = async (page, limit) => {
    const { data } = await $host.get('api/fields', {
        params: {
            page, limit
        }
    })
    return data
}

export const createField = async (cropid, field) => {
    const { data } = await $host.post(`api/fields?CropId=${cropid}`, field)
    return data
}

export const deleteField = async (id) => {
    const { data } = await $host.delete('api/fields/' + id)
    return data
}

export const updateField = async (id, field) => {
    const { data } = await $host.put(`api/fields/${id}`, field)
    return data
}

//Employees
export const fetchEmployees = async () => {
    const { data } = await $host.get('api/employees')
    return data
}

export const createEmployee = async (crop) => {
    const { data } = await $host.post(`api/employees`, crop)
    return data
}

export const deleteEmployee = async (id) => {
    const { data } = await $host.delete('api/employees/' + id)
    return data
}

export const updateEmployee = async (id, crop) => {
    const { data } = await $host.put(`api/employees/${id}`, crop)
    return data
}

//Field Jobs
export const fetchFieldJobs = async () => {
    const { data } = await $host.get('api/workonfields')
    return data
}

export const createFieldJob = async (employeeid, fieldid) => {
    const { data } = await $host.post(`api/workonfields?EmployeeId=${employeeid}&FieldId=${fieldid}`)
    return data
}

export const deleteFieldJob = async (employeeid, fieldid) => {
    const { data } = await $host.delete('api/workonfields/' + employeeid + "&" + fieldid)
    return data
}

//Warehouses
export const fetchWarehouses = async () => {
    const { data } = await $host.get('api/warehouses')
    return data
}

export const createWarehouse = async (warehouse) => {
    const { data } = await $host.post(`api/warehouses`, warehouse)
    return data
}

export const deleteWarehouse = async (id) => {
    const { data } = await $host.delete('api/warehouses/' + id)
    return data
}

export const updateWarehouse = async (id, warehouse) => {
    const { data } = await $host.put(`api/warehouses/${id}`, warehouse)
    return data
}

//Equipment
export const fetchEquipment = async (page, limit) => {
    const { data } = await $host.get('api/equipment', {
        params: {
            page, limit
        }
    })
    return data
}

export const createEquipment = async (warehouseid, equipment) => {
    const { data } = await $host.post(`api/equipment?WarehouseId=${warehouseid}`, equipment)
    return data
}

export const deleteEquipment = async (id) => {
    const { data } = await $host.delete('api/equipment/' + id)
    return data
}

export const updateEquipment = async (id, equipment) => {
    const { data } = await $host.put(`api/equipment/${id}`, equipment)
    return data
}

//Repairs
export const fetchRepairs = async (page, limit) => {
    const { data } = await $host.get('api/repairlogs', {
        params: {
            page, limit
        }
    })
    return data
}

export const createRepair = async (equipmentid, employeeid, repair) => {
    const { data } = await $host.post(`api/repairlogs?EquipmentId=${equipmentid}&EmployeeId=${employeeid}`, repair)
    return data
}

export const deleteRepair = async (id) => {
    const { data } = await $host.delete('api/repairlogs/' + id)
    return data
}

export const updateRepair = async (id, repair) => {
    const { data } = await $host.put(`api/repairlogs/${id}`, repair)
    return data
}

//Field Equipment
export const fetchFieldEquipment = async () => {
    const { data } = await $host.get('api/equipmentonfields')
    return data
}

export const createFieldEquipment = async (equipmentid, fieldid) => {
    const { data } = await $host.post(`api/equipmentonfields?EquipmentId=${equipmentid}&FieldId=${fieldid}`)
    return data
}

export const deleteFieldEquipment = async (equipmentid, fieldid) => {
    const { data } = await $host.delete('api/equipmentonfields/' + equipmentid + "&" + fieldid)
    return data
}
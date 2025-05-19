using server.DTO;
using server.Models;

namespace server.Contracts
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> GetAllAnimals(bool trackChanges);
        Animal GetAnimal(Guid id, bool trackChanges);
        Animal CreateAnimal(AnimalForCreationDto animal, Guid PastureId, bool trackChanges);
        void DeleteAnimal(Guid Id, bool trackChanges);
        void UpdateAnimal(Guid Id, AnimalForCreationDto animalForUpdate, bool trackChanges);
        AnimalPagedResult GetAnimalsWithPagination(int limit, int offset, bool trackChanges);
    }
    public interface ICropRepository
    {
        IEnumerable<Crop> GetAllCrops(bool trackChanges);
        Crop GetCrop(Guid id, bool trackChanges);
        Crop CreateCrop(CropForCreationDto crop, bool trackChanges);
        void DeleteCrop(Guid Id, bool trackChanges);
        void UpdateCrop(Guid Id, CropForCreationDto cropForUpdate, bool trackChanges);
        CropPagedResult GetCropsWithPagination(int limit, int offset, bool trackChanges);
    }
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees(bool trackChanges);
        Employee GetEmployee(Guid id, bool trackChanges);
        Employee CreateEmployee(EmployeeForCreationDto employee, bool trackChanges);
        void DeleteEmployee(Guid Id, bool trackChanges);
        void UpdateEmployee(Guid Id, EmployeeForCreationDto employeeForUpdate, bool trackChanges);
    }
    public interface IEquipmentOnFieldsRepository
    {
        IEnumerable<EquipmentOnFields> GetAllEquipmentOnFields(bool trackChanges);
        EquipmentOnFields GetEquipmentOnFields(Guid EquipmentId, Guid FieldId, bool trackChanges);
        EquipmentOnFields CreateEquipmentOnFields(Guid EquipmentId, Guid FieldId, bool trackChanges);
        void DeleteEquipmentOnFields(Guid EquipmentId, Guid FieldId, bool trackChanges);
    }
    public interface IFieldRepository
    {
        IEnumerable<Field> GetAllFields(bool trackChanges);
        Field GetField(Guid id, bool trackChanges);
        Field CreateField(FieldForCreationDto field, Guid CropId, bool trackChanges);
        void DeleteField(Guid Id, bool trackChanges);
        void UpdateField(Guid Id, FieldForCreationDto fieldForUpdate, bool trackChanges);
        FieldPagedResult GetFieldsWithPagination(int limit, int offset, bool trackChanges);
    }
    public interface IEquipmentRepository
    {
        IEnumerable<Equipment> GetAllEquipment(bool trackChanges);
        Equipment GetEquipment(Guid id, bool trackChanges);
        Equipment CreateEquipment(EquipmentForCreationDto equipment, Guid WarehouseId, bool trackChanges);
        void DeleteEquipment(Guid Id, bool trackChanges);
        void UpdateEquipment(Guid Id, EquipmentForCreationDto equipmentForUpdate, bool trackChanges);
        EquipmentPagedResult GetEquipmentWithPagination(int limit, int offset, bool trackChanges);
    }
    public interface IPastureRepository
    {
        IEnumerable<Pasture> GetAllPastures(bool trackChanges);
        Pasture GetPasture(Guid id, bool trackChanges);
        Pasture CreatePasture(PastureForCreationDto pasture, Guid FieldId, bool trackChanges);
        void DeletePasture(Guid Id, bool trackChanges);
        void UpdatePasture(Guid Id, PastureForCreationDto pastureForUpdate, bool trackChanges);
        PasturePagedResult GetPasturesWithPagination(int limit, int offset, bool trackChanges);
    }
    public interface IRepairLogRepository
    {
        IEnumerable<RepairLog> GetAllRepairLogs(bool trackChanges);
        RepairLog GetRepairLog(Guid id, bool trackChanges);
        RepairLog CreateRepairLog(RepairLogForCreationDto repairlog, Guid EquipmentId, Guid EmployeeId, bool trackChanges);
        void DeleteRepairLog(Guid Id, bool trackChanges);
        void UpdateRepairLog(Guid Id, RepairLogForCreationDto repairlogForUpdate, bool trackChanges);
        RepairLogPagedResult GetRepairLogsWithPagination(int limit, int offset, bool trackChanges);
    }
    public interface IWarehouseRepository
    {
        IEnumerable<Warehouse> GetAllWarehouses(bool trackChanges);
        Warehouse GetWarehouse(Guid id, bool trackChanges);
        Warehouse CreateWarehouse(WarehouseForCreationDto warehouse, bool trackChanges);
        void DeleteWarehouse(Guid Id, bool trackChanges);
        void UpdateWarehouse(Guid Id, WarehouseForCreationDto warehouseForUpdate, bool trackChanges);
    }
    public interface IWorkOnFieldsRepository
    {
        IEnumerable<WorkOnFields> GetAllWorkOnFields(bool trackChanges);
        WorkOnFields GetWorkOnFields(Guid EmployeeId, Guid FieldId, bool trackChanges);
        WorkOnFields CreateWorkOnFields(Guid EmployeeId, Guid FieldId, bool trackChanges);
        void DeleteWorkOnFields(Guid EmployeeId, Guid FieldId, bool trackChanges);
    }
}

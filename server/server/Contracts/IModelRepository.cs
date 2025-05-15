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
        Crop GetCrop(int id, bool trackChanges);
    }
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees(bool trackChanges);
        Employee GetEmployee(int id, bool trackChanges);
    }
    public interface IEquipmentOnFieldsRepository
    {
        IEnumerable<EquipmentOnFields> GetAllEquipmentOnFields(bool trackChanges);
        EquipmentOnFields GetEquipmentOnFields(Guid EquipmentId, Guid FieldId, bool trackChanges);
    }
    public interface IFieldRepository
    {
        IEnumerable<Field> GetAllFields(bool trackChanges);
        Field GetField(int id, bool trackChanges);
    }
    public interface IEquipmentRepository
    {
        IEnumerable<Equipment> GetAllEquipment(bool trackChanges);
        Equipment GetEquipment(int id, bool trackChanges);
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
        RepairLog GetRepairLog(int id, bool trackChanges);
    }
    public interface IWarehouseRepository
    {
        IEnumerable<Warehouse> GetAllWarehouses(bool trackChanges);
        Warehouse GetWarehouse(int id, bool trackChanges);
    }
    public interface IWorkOnFieldsRepository
    {
        IEnumerable<WorkOnFields> GetAllWorkOnFields(bool trackChanges);
        WorkOnFields GetWorkOnFields(Guid EmployeeId, Guid FieldId, bool trackChanges);
    }
}

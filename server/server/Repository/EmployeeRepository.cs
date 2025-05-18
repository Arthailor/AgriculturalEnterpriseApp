using AutoMapper;
using server.Contracts;
using server.DTO;
using server.Models;

namespace server.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        private readonly IMapper _mapper;
        public EmployeeRepository(MyDBContext context, IMapper mapper) : base(context) {
            _mapper = mapper;
        }
        public IEnumerable<Employee> GetAllEmployees(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(g => g.Id)
                .ToList();
        }
        public Employee GetEmployee(Guid id, bool trackChanges)
        {
            return FindByCondition(g => g.Id.Equals(id), trackChanges).SingleOrDefault();
        }
        public Employee CreateEmployee(EmployeeForCreationDto employee, bool trackChanges)
        {
            var employeeEntity = _mapper.Map<Employee>(employee);

            Create(employeeEntity);

            return employeeEntity;
        }
        public void DeleteEmployee(Guid Id, bool trackChanges)
        {
            var employee = FindByCondition(g => g.Id.Equals(Id), trackChanges).SingleOrDefault();
            Delete(employee);
            _context.SaveChanges();
        }
        public void UpdateEmployee(Guid Id, EmployeeForCreationDto employeeForUpdate, bool trackChanges)
        {
            var employeeEntity = FindByCondition(g => g.Id.Equals(Id), trackChanges).SingleOrDefault();
            _mapper.Map(employeeForUpdate, employeeEntity);
            _context.SaveChanges();
        }
    }
}

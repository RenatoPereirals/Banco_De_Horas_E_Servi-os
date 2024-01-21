using Bsd.Domain.Entities;
using Bsd.Domain.Enums;
using Bsd.Domain.Repository.Interfaces;
using Bsd.Domain.Services.Interfaces;

namespace Bsd.Domain.Services
{
    public class BsdService : IBsdService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRubricService _rubricService;
        private readonly IDayTypeChecker _daytypeChecker;

        public BsdService(IEmployeeRepository employeeRepository,
                          IRubricService rubricService,
                          IDayTypeChecker dayTypeChecker)
        {
            _employeeRepository = employeeRepository;
            _rubricService = rubricService;
            _daytypeChecker = dayTypeChecker;
        }

        public async Task<BsdEntity> CreateBsdAsync(int bsdNumber, DateTime dateService, IEnumerable<int> employeeRegistrations)
        {
            var dayType = _daytypeChecker.GetDayType(dateService);
            var bsdEntity = new BsdEntity(bsdNumber, dateService)
            {
                DayType = dayType
            };
            await AddEmployeesToBsdAsync(bsdEntity, employeeRegistrations);
            return bsdEntity;
        }

        public async Task AddEmployeesToBsdAsync(BsdEntity bsdEntity, IEnumerable<int> employeeRegistrations)
        {
            foreach (var registration in employeeRegistrations)
            {
                var employee = await _employeeRepository.GetEmployeeByRegistrationAsync(registration)
                    ?? throw new Exception("Mátricula do funcionário não encontrada.");

                var employeeBsdEntity = new EmployeeBsdEntity(registration, employee, bsdEntity.BsdNumber, bsdEntity);
                bsdEntity.EmployeeBsdEntities.Add(employeeBsdEntity);

                await AssignRubricsToEmployeeByServiceTypeAndDayAsync(employeeBsdEntity, bsdEntity.DayType);
            }
        }

        public async Task AssignRubricsToEmployeeByServiceTypeAndDayAsync(EmployeeBsdEntity employeeBsdEntity, DayType dayType)
        {
            var employee = employeeBsdEntity.Employee;
            var filteredRubrics = await _rubricService.FilterRubricsByServiceTypeAndDayAsync(employee.ServiceType, dayType);
            employeeBsdEntity.Rubrics = filteredRubrics;
        }
    }
}
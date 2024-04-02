using BTL_Platform.Intrface;
using BTL_Platform.Models;

namespace BTL_Platform.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        BTLContext bTLContext;
        public EmployeeRepository(BTLContext _bTLContext)
        {
            bTLContext = _bTLContext;

        }
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(string id)
        {
            Employee employee = bTLContext.Employees.FirstOrDefault(a => a.Id == id);
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return bTLContext.Employees.ToList();
        }

        public void Insert(Employee employee)
        {
           // employee.Id = GenerateUniqueId(); // Generate unique ID
            bTLContext.Employees.Add(employee);
            bTLContext.SaveChanges();
        }



        public void Save()
        {
            bTLContext.SaveChanges();
        }

        public void Update(string id, Employee employee)
        {
            Employee oldemployee = GetEmployee(id);
            oldemployee.Name = employee.Name;
            oldemployee.Email = employee.Email;
            bTLContext.SaveChanges();
        }




    }
}

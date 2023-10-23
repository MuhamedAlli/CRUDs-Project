using AspCoreMVCDay2.Models;

namespace AspCoreMVCDay2.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        ITIContext context;
        public DepartmentRepository(ITIContext _context)
        {
            context = _context;
        }

        public List<Department> GellAll()
        {
            return context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(d=>d.DepartmentID==id);
        }
    }
}

using AspCoreMVCDay2.Models;

namespace AspCoreMVCDay2.Repository
{
    public interface IDepartmentRepository
    {
        List<Department> GellAll();

        public Department GetById(int id);
    }
}

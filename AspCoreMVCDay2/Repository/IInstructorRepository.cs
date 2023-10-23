using AspCoreMVCDay2.Models;

namespace AspCoreMVCDay2.Repository
{
    public interface IInstructorRepository
    {
        Instructor GetById(int id);
        List<Instructor> GetAll();
        Task<string> UploadImage(IFormFile formFile);
        void Create(Instructor instructor);
        void Update(int id, Instructor ins);
        void Delete(int id);
    }
}

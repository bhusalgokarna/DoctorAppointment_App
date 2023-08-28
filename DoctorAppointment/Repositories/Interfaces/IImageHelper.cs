namespace DoctorAppointment.Repositories.Interfaces
{
    public interface IImageHelper
    {
        string GetImageUrl(string fileName);
        string StoreImage(IFormFile file);
    }
}

using DoctorAppointment.Repositories.Interfaces;

namespace DoctorAppointment.Repositories.Implimentation
{
    public class ImageHelper : IImageHelper
    {
        private readonly string _imageFolderPath;
        public ImageHelper(IWebHostEnvironment hostEnvironment)
        {
            _imageFolderPath = Path.Combine(hostEnvironment.WebRootPath, "images");
        }

        public string GetImageUrl(string fileName)
        {
            string imagePath = Path.Combine(_imageFolderPath, fileName);
            if (File.Exists(imagePath))
            {
                string imageUrl = "/images/" + fileName;
                return imageUrl;
            }
            return "/images/Defult.png";

        }

        public string StoreImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return string.Empty;
            }
            //string fileName=Guid.NewGuid().ToString()+Path.GetExtension(file.FileName);
            //string fileName = Guid.NewGuid() + Path.GetExtension(file + ".jpg");
            string fileName = file.FileName;
            string filepath = Path.Combine(_imageFolderPath, file + ".jpg");
            using (var stream = new FileStream(filepath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return fileName;
        }
    }
}

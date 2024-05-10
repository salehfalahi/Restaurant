namespace Restaurant2
{
    public class UploadFile
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UploadFile(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public string Upload(IFormFile file)
        {
            if (file == null) return "";
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName); // تولید نام فایل منحصر به فرد
            var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName); // ترکیب مسیر
            using (var f = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(f);
            }
            return "/images/" + fileName; // برگرداندن مسیر فایل
        }
    }
}

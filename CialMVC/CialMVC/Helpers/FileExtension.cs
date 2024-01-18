namespace CialMVC.Helpers
{
    public static class FileExtension
    {
        public static async Task<string> SaveAsync(this IFormFile formFile, string path)
        {
            string extension = Path.GetExtension(formFile.FileName);
            string fileName = Path.GetFileNameWithoutExtension(formFile.FileName);

            fileName = Path.Combine(path + fileName + extension);

            using (FileStream fs = File.Create(Path.Combine(PathConstants.RootPath, fileName)))
            {
                await formFile.CopyToAsync(fs);
            }
            return fileName;
        }
    }
}

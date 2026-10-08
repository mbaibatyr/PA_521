using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost("Upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Файл не выбран");

            // Находим директорию приложения программно
            var folder = Path.Combine(AppContext.BaseDirectory, "Files");

            Directory.CreateDirectory(folder);

            var extension = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{extension}";

            //var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(folder, fileName);

            await using var stream = new FileStream(
                filePath,
                FileMode.Create
            );

            await file.CopyToAsync(stream);

            return Created("Created", filePath);
        }

        [HttpPost("UploadMulty")]
        public async Task<IActionResult> UploadMulty(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                return BadRequest("Файлы не выбраны");

            var folder = Path.Combine(AppContext.BaseDirectory, "Files");

            Directory.CreateDirectory(folder);

            var uploadedFiles = new List<string>();

            foreach (var file in files)
            {
                if (file.Length == 0)
                    continue;

                var extension = Path.GetExtension(file.FileName);

                // Уникальное имя для каждого файла
                var fileName = $"{Guid.NewGuid()}{extension}";

                var filePath = Path.Combine(folder, fileName);

                await using var stream = new FileStream(
                    filePath,
                    FileMode.Create
                );

                await file.CopyToAsync(stream);

                uploadedFiles.Add(fileName);
            }

            return Ok(uploadedFiles);
        }
    }
}

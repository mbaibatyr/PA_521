using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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

        [HttpPost("UploadXLSX")]
        public async Task<IActionResult> UploadXLSX(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Файл не выбран");

            var extension = Path.GetExtension(file.FileName);

            if (!extension.Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                return BadRequest("Можно загрузить только Excel-файл (.xlsx)");

            var folder = Path.Combine(AppContext.BaseDirectory, "Files");

            Directory.CreateDirectory(folder);

            var fileName = $"{Guid.NewGuid()}{extension}";

            var filePath = Path.Combine(folder, fileName);

            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return Ok(new
            {
                FileName = fileName,
                Path = filePath
            });
        }

        [HttpGet("DownloadTXT")]
        public IActionResult DownloadTxt()
        {
            string text = "Привет!\r\nЭто динамический TXT-файл.";

            var bytes = System.Text.Encoding.UTF8.GetBytes(text);

            return File(
                bytes,
                "text/plain",
                "result.txt"
            );
        }

        [HttpGet("DownloadFile")]
        public IActionResult DownloadFile(string fileName)
        {
            //StringBuilder sb = new StringBuilder();
            //string st = null;
            //for (int i = 0; i < 100000; i++)
            //{
            //    sb.AppendLine("qeqqe");
            //    st += "qeqqe";
            //}
            //sb.ToString();

            var folder = Path.Combine(AppContext.BaseDirectory, "Files");

            var filePath = Path.Combine(folder, fileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound("Файл не найден");

            var contentType = Path.GetExtension(fileName).ToLowerInvariant() switch
            {
                ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                ".xls" => "application/vnd.ms-excel",

                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ".doc" => "application/msword",

                ".pdf" => "application/pdf",

                ".txt" => "text/plain",

                ".csv" => "text/csv",

                ".zip" => "application/zip",

                _ => "application/octet-stream"
            };

            return PhysicalFile(
                filePath,
                contentType,
                fileName
            );
        }
    }
}

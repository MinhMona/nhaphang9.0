using Application.Extensions;
using Application.Utilities;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Files
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        protected IWebHostEnvironment _env;
        public FileController(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _env = env;
        }

        [HttpPost("upload-file")]
        public async Task<string> UploadFile(IFormFile file)
        {
            var httpContextHost = HttpContext.Request.Host;
            string result = "";
            await Task.Run(() =>
            {
                if (file != null && file.Length > 0)
                {
                    string fileName = string.Format("{0}-{1}", Guid.NewGuid().ToString(), file.FileName);
                    string fileUploadPath = Path.Combine(_env.ContentRootPath, FolderConstant.UPLOAD_FOLDER_NAME);
                    string path = Path.Combine(fileUploadPath, fileName);
                    FileUtilities.CreateDirectory(fileUploadPath);
                    var fileByte = FileUtilities.StreamToByte(file.OpenReadStream());
                    FileUtilities.SaveToPath(path, fileByte);
                    result = $"https://{httpContextHost}/{fileName}";
                }
                else
                {
                    throw new AppException("Không tìm thấy tệp");
                }
            });
            return result;
        }
    }
}

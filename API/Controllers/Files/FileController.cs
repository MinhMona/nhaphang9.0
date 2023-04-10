using Application.Extensions;
using Application.Utilities;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Files
{
    /// <summary>
    /// FileController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        /// <summary>
        /// IWebHostEnvironment
        /// </summary>
        protected IWebHostEnvironment _env;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="env"></param>
        /// <param name="httpContextAccessor"></param>
        public FileController(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _env = env;
        }

        /// <summary>
        /// Upload single file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        [HttpPost("upload-file")]
        [AppAuthorize((int)PermissionEnum.Upload)]
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

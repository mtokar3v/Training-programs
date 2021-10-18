using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using WebApiServer.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;

namespace WebApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IWebHostEnvironment _appEnvironment;
        public UserController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        [HttpGet("{id}")]
        public FileResult Get(int id) => new FileContentResult(System.IO.File.ReadAllBytes(String.Concat(_appEnvironment.ContentRootPath, "\\wwwroot\\data\\", id, "\\user.json")), "application/json") { FileDownloadName = "user.json" };

        [HttpPost]
        public async Task<UserInfo> Post([FromForm] UserView userView)
        {
            string path = _appEnvironment.ContentRootPath + "\\wwwroot\\data";
            
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string[] files = Directory.GetDirectories(path);
            int id = files.Length + 1;
            path = path + '\\' + id;
            var dir = Directory.CreateDirectory(path);

            User user = (User)userView;

            IFormFile file = userView.Photo;

            //загружаем картинку
            using (Stream fileStream = new FileStream(dir.FullName + '\\' + file.FileName, FileMode.Create))
                await file.CopyToAsync(fileStream);

            JsonSerializer serializer = new JsonSerializer();

            //загружаем информацию
            using (StreamWriter sw = new StreamWriter(dir.FullName + '\\' + "user.json"))
                using (JsonWriter jw = new JsonTextWriter(sw))
                    serializer.Serialize(jw, user);

            return new UserInfo { Path = "api\\user\\" + id, Image = "data\\"+ id + '\\' + file.FileName};
        }
    }

}

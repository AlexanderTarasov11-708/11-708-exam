using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileUpload.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static FileUpload.Models.MyFile;

namespace FileUpload.Controllers
{
    public class UploadController : Controller
    {
        MyDbContext _context;
        IHostingEnvironment _appEnvironment;

        public UploadController(MyDbContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile, string shortDescription, string longDescription)
        {
            if (uploadedFile != null)
            {
                string path = "/Files/" + uploadedFile.FileName;
                string type = uploadedFile.ContentType;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                MyFile file = new MyFile { Name = uploadedFile.FileName, Path = path, SimpleDescr = shortDescription, Description = longDescription };
                _context.Files.Add(file);
                _context.SaveChanges();
            }


            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var file = _context.Files.Find(id);

            if (file == null)
            {
                return NotFound();
            }
            return View(file);
        }

    }
}
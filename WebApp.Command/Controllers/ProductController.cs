using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;
using WebApp.Command.Commands;
using WebApp.Command.Enums;
using WebApp.Command.Models;
using WebApp.Command.Services;

namespace WebApp.Command.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppIdentityDbContext context;

        public ProductController(AppIdentityDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await context.Products.ToListAsync());
        }

        public async Task<IActionResult> CreateFile(int type)
        {
            FileCreateInvoker fileCreateInvoker = new();
            var products = await context.Products.ToListAsync();

            EFileType fileType = (EFileType)type;

            switch (fileType)
            {
                case EFileType.Excel:
                    ExcelFile<Product> excelFile = new(products);
                    fileCreateInvoker.SetCommand(new CreateExcelTableActionService<Product>(excelFile));
                    break;
                case EFileType.Pdf:
                    PdfFile<Product> pdfFile = new(products, HttpContext);
                    fileCreateInvoker.SetCommand(new CreatePdfTableActionService<Product>(pdfFile));
                    break;
                default:
                    break;
            }
            return fileCreateInvoker.CreateFile();
        }

        public async Task<IActionResult> CreateFiles()
        {
            FileCreateInvoker fileCreateInvoker = new();
            var products = await context.Products.ToListAsync();

            ExcelFile<Product> excelFile = new(products);
            PdfFile<Product> pdfFile = new(products, HttpContext);

            fileCreateInvoker.AddCommand(new CreateExcelTableActionService<Product>(excelFile));
            fileCreateInvoker.AddCommand(new CreatePdfTableActionService<Product>(pdfFile));

            var filesResult = fileCreateInvoker.CreateFiles();

            using (var ms =new MemoryStream())
            {
                using (var archive=new ZipArchive(ms,ZipArchiveMode.Create))
                {
                    foreach (var item in filesResult)
                    {
                        var fileContent = item as FileContentResult;
                        var zipFile = archive.CreateEntry(fileContent.FileDownloadName);

                        using (var zipEntryStream=zipFile.Open())
                        {
                            await new MemoryStream(fileContent.FileContents).CopyToAsync(zipEntryStream);
                        }
                    }
                }

                return File(ms.ToArray(),"application/zip","all.zip");
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebApp.Command.Commands;
using WebApp.Command.Interfaces;

namespace WebApp.Command.Services
{
    public class CreatePdfTableActionService<T> : ITableActionCommand
    {
        private readonly PdfFile<T> pdfFile;

        public CreatePdfTableActionService(PdfFile<T> pdfFile)
        {
            this.pdfFile = pdfFile;
        }

        public IActionResult Execute()
        {
            var ms = pdfFile.Create();

            return new FileContentResult(ms.ToArray(), pdfFile.FileType)
            {
                FileDownloadName = pdfFile.FileName,
            };
        }
    }
}

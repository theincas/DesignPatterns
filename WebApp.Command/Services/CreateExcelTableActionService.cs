using Microsoft.AspNetCore.Mvc;
using WebApp.Command.Commands;
using WebApp.Command.Interfaces;

namespace WebApp.Command.Services
{
    public class CreateExcelTableActionService<T> : ITableActionCommand
    {
        private readonly ExcelFile<T> _excelFile;

        public CreateExcelTableActionService(ExcelFile<T> excelFile)
        {
            _excelFile = excelFile;
        }

        public IActionResult Execute()
        {
            var ms = _excelFile.Create();

            return new FileContentResult(ms.ToArray(), _excelFile.FileType)
            {
                FileDownloadName = _excelFile.FileName,
            };
        }
    }
}

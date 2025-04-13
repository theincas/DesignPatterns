using Microsoft.AspNetCore.Mvc;
using WebApp.Command.Interfaces;

namespace WebApp.Command.Services
{
    public class FileCreateInvoker
    {
        private ITableActionCommand _actionCommand;
        private List<ITableActionCommand> tableActionCommands = new List<ITableActionCommand>();

        public void SetCommand(ITableActionCommand tableActionCommand)
        {
            _actionCommand = tableActionCommand;
        }

        public void AddCommand(ITableActionCommand tableActionCommand)
        {
            tableActionCommands.Add(tableActionCommand);
        }

        public IActionResult CreateFile()
        {
            return _actionCommand.Execute();
        }

        public List<IActionResult> CreateFiles()
        {
            return tableActionCommands.Select(x => x.Execute()).ToList();
        }
    }
}

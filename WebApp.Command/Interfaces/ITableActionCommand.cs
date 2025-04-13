using Microsoft.AspNetCore.Mvc;

namespace WebApp.Command.Interfaces
{
    public interface ITableActionCommand
    {
        IActionResult Execute();
    }
}

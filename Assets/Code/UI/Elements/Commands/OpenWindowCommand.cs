using Code.Infrastructure.Commands;
using Code.UI.Services.Windows;

namespace Code.UI.Elements.Commands
{
    public class OpenWindowCommand : ICommand
    {
        private readonly WindowId _windowId;
        private readonly IWindowService _windowService;

        public OpenWindowCommand(IWindowService windowService, WindowId windowId)
        {
            _windowService = windowService;
            _windowId = windowId;
        }

        public void Execute() =>
            Open();

        private void Open() =>
            _windowService.Open(_windowId);
    }
}

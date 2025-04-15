using Code.UI.Services.Windows;
using UnityEngine.UI;

namespace Code.UI.Elements.Commands
{
    public class OpenWindowCommand : CommandBase
    {
        public Button Button;
        public WindowId WindowId;

        private IWindowService _windowService;

        public void Construct(IWindowService windowService) =>
            _windowService = windowService;

        public override void Execute() =>
            Open();

        private void Open() =>
            _windowService.Open(WindowId);
    }
}

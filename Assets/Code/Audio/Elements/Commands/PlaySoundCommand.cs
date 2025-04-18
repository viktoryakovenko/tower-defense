using Code.Audio.Services.SFXService;
using Code.Infrastructure.Commands;
using Code.UI.Elements.Commands;

namespace Code.Audio.Elements.Commands
{
    public class PlaySoundCommand : ICommand
    {
        private readonly ISFXService _soundService;

        public PlaySoundCommand(ISFXService soundService) =>
            _soundService = soundService;

        public void Execute()
        {
            bool wasEnabled = _soundService.IsEnabled;

            _soundService.SetEnabled(!wasEnabled);

            if (!wasEnabled && _soundService.IsEnabled)
                _soundService.PlaySound("50");
        }
    }
}

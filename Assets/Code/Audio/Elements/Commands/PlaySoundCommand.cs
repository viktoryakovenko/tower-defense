using Code.Audio.Services.SFXService;
using Code.Infrastructure.Commands;

namespace Code.Audio.Elements.Commands
{
    public class PlaySoundCommand : ICommand
    {
        private readonly ISFXService _soundService;
        private readonly SoundId _soundId;

        public PlaySoundCommand(ISFXService soundService, SoundId soundId)
        {
            _soundService = soundService;
            _soundId = soundId;
        }

        public void Execute() =>
            _soundService.PlaySound(_soundId);
    }
}

using Code.Audio.Services;
using Code.Infrastructure.Commands;

namespace Code.Audio.Elements.Commands
{
    public class VolumeSliderCommand : ICommand<float>
    {
        private readonly IVolumeControl _volumeControl;

        public VolumeSliderCommand(IVolumeControl volumeControl) =>
            _volumeControl = volumeControl;

        public void Execute(float volume) =>
            _volumeControl.SetVolume(volume);
    }
}

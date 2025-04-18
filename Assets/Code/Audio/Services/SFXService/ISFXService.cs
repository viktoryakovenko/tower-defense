using UnityEngine;

namespace Code.Audio.Services.SFXService
{
    public interface ISFXService
    {
        bool IsEnabled { get; }
        float CurrentVolume { get; }

        void SetEnabled(bool isEnabled);
        void SetVolume(float volume);
        void PlaySound(SoundId soundId, AudioSource audioSource);
    }
}

using System;
using Code.Audio.Elements;

namespace Code.Audio.Services.AudioEmitterHub
{
    public interface IAudioEmittersHub
    {
        AudioEmitter GetFreeElement(Action<AudioEmitter> onGetAction = null);
        void SetVolumeAll(float volume);
        void StopAll();
    }
}

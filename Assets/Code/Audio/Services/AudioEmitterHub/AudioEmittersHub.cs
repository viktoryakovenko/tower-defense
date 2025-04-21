using System;
using System.Collections.Generic;
using Code.Audio.Elements;
using Code.Infrastructure.Services.GameObjectPool;

namespace Code.Audio.Services.AudioEmitterHub
{
    public class AudioEmittersHub : IAudioEmittersHub
    {
        private readonly IGameObjectPool<AudioEmitter> _objectPool;

        private HashSet<AudioEmitter> _activeEmitters = new();

        public AudioEmittersHub(IGameObjectPool<AudioEmitter> objectPool) =>
            _objectPool = objectPool;

        public AudioEmitter GetFreeElement(Action<AudioEmitter> onGetAction = null)
        {
            var freeEmitter = _objectPool.GetFreeElement(onGetAction);
            _activeEmitters.Add(freeEmitter);
            return freeEmitter;
        }

        public void SetVolumeAll(float volume)
        {
            foreach (var emitter in _activeEmitters)
                emitter.SetVolume(volume);
        }

        public void StopAll()
        {
            foreach (var emitter in _activeEmitters)
                emitter.Stop();

            _activeEmitters.Clear();
        }
    }
}

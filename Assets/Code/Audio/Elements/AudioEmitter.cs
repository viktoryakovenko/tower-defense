using UnityEngine;

namespace Code.Audio.Elements
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioEmitter : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        public void Play(AudioClip clip, float volume = 1f, bool loop = false)
        {
            _audioSource.clip = clip;
            _audioSource.volume = volume;
            _audioSource.loop = loop;
            _audioSource.Play();
        }
    }
}

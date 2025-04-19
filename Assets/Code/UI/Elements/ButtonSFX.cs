using Code.Audio.Services.SFXService;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Elements
{
    [RequireComponent(typeof(Button))]
    public class ButtonSFX : MonoBehaviour
    {
        [SerializeField] private SoundId _soundId;

        private ISFXService _soundService;

        [Inject]
        public void Construct(ISFXService soundService)
        {
            _soundService = soundService;
            Debug.Log("INJECTED");
        }

        public void PlayClickSound() =>
            _soundService.PlaySound(_soundId);
    }
}

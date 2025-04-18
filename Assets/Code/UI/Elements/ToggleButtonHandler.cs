using Code.Audio.Services.SFXService;
using Code.Infrastructure.Commands;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Elements
{
    [RequireComponent(typeof(Button))]
    public class ToggleButtonHandler : MonoBehaviour
    {
        public AudioSource AudioSource;

        [SerializeField] private SoundId _soundId;
        [SerializeField] private Image _toggleImage;
        [SerializeField] private Sprite _activatedSprite;
        [SerializeField] private Sprite _deactivatedSprite;
        [SerializeField] private Button _button;

        private ICommand _command;
        private bool _isActive;
        private ISFXService _soundsService;

        public void Construct(ICommand command, bool isActive, ISFXService soundsService)
        {
            _soundsService = soundsService;
            _command = command;
            _isActive = isActive;

            SetCurrentSprite();
        }

        private void OnEnable() =>
            _button.onClick.AddListener(ExecuteCommand);

        private void OnDisable() =>
            _button.onClick.RemoveListener(ExecuteCommand);

        private void ExecuteCommand()
        {
            _command.Execute();
            ToggleSprite();
            _soundsService.PlaySound(_soundId, AudioSource);
        }

        private void ToggleSprite()
        {
            _isActive = !_isActive;
            SetCurrentSprite();
        }

        private void SetCurrentSprite() =>
            _toggleImage.sprite = _isActive ? _activatedSprite : _deactivatedSprite;
    }
}

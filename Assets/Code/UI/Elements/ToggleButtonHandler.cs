using Code.Audio.Services;
using Code.Infrastructure.Commands;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Elements
{
    [RequireComponent(typeof(Button))]
    public class ToggleButtonHandler : MonoBehaviour
    {
        [SerializeField] private Image _toggleImage;
        [SerializeField] private Sprite _activatedSprite;
        [SerializeField] private Sprite _deactivatedSprite;
        [SerializeField] private Button _button;

        private ICommand _command;
        private IToggleable _toggleable;

        public void Construct(ICommand command, IToggleable toggleable)
        {
            _command = command;
            _toggleable = toggleable;
            _toggleable.ToggleChanged += SetCurrentSprite;

            SetCurrentSprite(_toggleable.IsEnabled);
        }

        private void OnEnable() =>
            _button.onClick.AddListener(ExecuteCommand);

        private void OnDisable() =>
            _button.onClick.RemoveListener(ExecuteCommand);

        private void ExecuteCommand()
        {
            _command.Execute();
            SetCurrentSprite(_toggleable.IsEnabled);
        }

        private void SetCurrentSprite(bool isActive) =>
            _toggleImage.sprite = isActive ? _activatedSprite : _deactivatedSprite;
    }
}

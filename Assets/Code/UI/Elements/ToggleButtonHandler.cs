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
        private bool _isActive;

        public void Construct(ICommand command, bool isActive)
        {
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

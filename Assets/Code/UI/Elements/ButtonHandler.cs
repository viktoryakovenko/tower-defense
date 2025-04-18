using Code.UI.Elements.Commands;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Elements
{
    [RequireComponent(typeof(Button))]
    public class ButtonHandler : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private ICommand _command;

        public void Construct(ICommand command) =>
            _command = command;

        private void OnEnable() =>
            _button.onClick.AddListener(ExecuteCommand);

        private void OnDisable() =>
            _button.onClick.RemoveListener(ExecuteCommand);

        private void ExecuteCommand() =>
            _command.Execute();
    }
}

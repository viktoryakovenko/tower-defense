using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Elements
{
    [RequireComponent(typeof(Button))]
    public class ButtonHandler : MonoBehaviour
    {
        [SerializeField] private List<CommandBase> _commands;

        private Button _button;

        private void Awake() =>
            _button = GetComponent<Button>();

        private void OnEnable() =>
            _button.onClick.AddListener(ExecuteCommands);

        private void OnDisable() =>
            _button.onClick.RemoveListener(ExecuteCommands);

        private void ExecuteCommands()
        {
            foreach (var command in _commands)
                command.Execute();
        }
    }
}
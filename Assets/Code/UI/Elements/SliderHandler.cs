using Code.UI.Elements.Commands;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Elements
{
    [RequireComponent(typeof(Slider))]
    public class SliderHandler : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private ICommand _command;
        private bool _isActive;

        public void Construct(ICommand command) =>
            _command = command;

        private void OnEnable() =>
            _slider.onValueChanged.AddListener(ExecuteCommand);

        private void OnDisable() =>
            _slider.onValueChanged.RemoveListener(ExecuteCommand);

        private void ExecuteCommand(float value) =>
            _command.Execute();
    }
}

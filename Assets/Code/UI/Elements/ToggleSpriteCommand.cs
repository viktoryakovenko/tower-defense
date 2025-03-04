using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Elements
{
    public class ToggleSpriteCommand : CommandBase
    {
        public Image Image;
        public Sprite ActivatedSprite;
        public Sprite DeactivatedSprite;

        [SerializeField] private bool _toggleEnabled;

        public void Construct(bool toggleEnabled) =>
            _toggleEnabled = toggleEnabled;

        public override void Execute() =>
            ToggleSprite();

        private void Awake() =>
            UpdateCurrentSprite();

        private void ToggleSprite()
        {
            _toggleEnabled = !_toggleEnabled;
            UpdateCurrentSprite();
        }

        private void UpdateCurrentSprite() =>
            Image.sprite = _toggleEnabled ? ActivatedSprite : DeactivatedSprite;
    }
}

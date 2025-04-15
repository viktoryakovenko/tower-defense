using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Elements.Commands
{
    public class AdPurchaseCommand : CommandBase
    {
        public Image Image;
        public Sprite ActivatedSprite;

        [SerializeField] private bool _isBought;

        public void Construct(bool isBought) =>
            _isBought = isBought;

        private void Awake()
        {
            if (_isBought)
                UpdateSprite();
        }

        public override void Execute() =>
            Buy();

        private void Buy()
        {
            if (_isBought) return;

            _isBought = !_isBought;
            UpdateSprite();
        }

        private void UpdateSprite() =>
            Image.sprite = ActivatedSprite;
    }
}

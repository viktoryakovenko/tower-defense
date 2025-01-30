using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    public Button Button;
    public Image Image;
    public Sprite ActivatedSprite;
    public Sprite DeactivatedSprite;

    private bool _enabled;

    public void Construct(bool enabled) =>
        _enabled = enabled;

    private void Awake()
    {
        Construct(true);
        Button.onClick.AddListener(ToggleSprite);
        UpdateCurrentSprite();
    }

    private void ToggleSprite()
    {
        _enabled = !_enabled;
        UpdateCurrentSprite();
    }

    private Sprite UpdateCurrentSprite() =>
        Image.sprite = _enabled ? ActivatedSprite : DeactivatedSprite;
}

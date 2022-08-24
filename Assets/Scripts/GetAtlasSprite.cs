using UnityEngine;
using UnityEngine.UI;

public class GetAtlasSprite : MonoBehaviour
{
    [SerializeField] private Image _image;

    [SerializeField] private string _spriteName;

    private void Start() => _image.sprite = SpriteAtlasManager.Instance.GetSpriteAtlas(_spriteName);
}

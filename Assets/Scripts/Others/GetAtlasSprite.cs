using UnityEngine;
public class GetAtlasSprite : CustomManager
{
    [SerializeField] private string _spriteName;
    private void Start() => Image.sprite = SpriteAtlasManager.Instance.GetSpriteAtlas(_spriteName);
}

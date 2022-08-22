using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SpriteAtlasManager : MonoBehaviour
{
    [SerializeField] private SpriteAtlas _spriteAtlas;

    public Sprite GetSpriteAtlas(string name) => _spriteAtlas.GetSprite(name);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItemScript : MonoBehaviour
{
    public enum Type {Barrack, PowerPlate, Soldier}

    [SerializeField] Type type;

    [SerializeField] private bool _soldierType;

    [SerializeField] Image image;

    private void Start()
    {
        image.sprite = SpriteAtlasManager.Instance.GetSpriteAtlas(type == Type.Soldier ? (_soldierType ? "soldier2" : "soldier") : type.ToString());
    }

    public void OnDown()
    {
        if (type == Type.Barrack)
            InputManager.Instance.SetBuilder(PoolManager.Instance.GetBarrackObject(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        else if(type == Type.PowerPlate)
            InputManager.Instance.SetBuilder(PoolManager.Instance.GetPowerPlateObject(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        else if(type == Type.Soldier)
            InputManager.Instance.SetBuilder(PoolManager.Instance.GetSoldierObject(Camera.main.ScreenToWorldPoint(Input.mousePosition), _soldierType ? 1 : 0));
    }
}

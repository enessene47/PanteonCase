using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItemScript : MonoSingleton<MenuItemScript>
{
    public enum Type {Barrack, PowerPlate, Soldier}

    [SerializeField] Type type;

    public void OnDown()
    {
        InputManager.Instance.SetBuilder(PoolManager.Instance.GetBuilderObject(type, Camera.main.ScreenToWorldPoint(Input.mousePosition)));
    }
}

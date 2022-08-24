using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItemScript : MonoBehaviour
{
    public enum Type {Barrack, PowerPlate, Soldier}

    [SerializeField] Type type;

    [SerializeField] private int _soldierType;

    public void OnDown()
    {
        InputManager.Instance.SetBuilder(PoolManager.Instance.GetBuilder(type, _soldierType));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItemScript : MonoBehaviour
{
    public enum Type {Barrack, PowerPlate, Soldier}

    [SerializeField] Type type;

    public void OnDown()
    {
        if (type == Type.Barrack)
            InputManager.Instance.SetBuilder(PoolManager.Instance.GetBarrackObject(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        else if(type == Type.PowerPlate)
            InputManager.Instance.SetBuilder(PoolManager.Instance.GetPowerPlateObject(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        else if(type == Type.Soldier)
            InputManager.Instance.SetBuilder(PoolManager.Instance.GetSoldierObject(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
    }
}

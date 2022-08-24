using UnityEngine;

public class MenuItemScript : MonoBehaviour
{
    public enum Type {Barrack, PowerPlate, Soldier}

    [SerializeField] private Type _type;

    [SerializeField] private int _soldierType;

    public void OnDown() => BuilderManager.Instance.SetBuilder(PoolManager.Instance.GetBuilder(_type, _soldierType));
}

using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    [SerializeField] private int _poolSizeBarrackPowerPlant;

    private Queue<IBuildable> _pooledBarrack;

    private Queue<IBuildable> _pooledPowerPlant;

    private Queue<IBuildable> _pooledSoldier;

    private void Awake() => CreateBarrack();

    private void CreateBarrack()
    {
        _pooledBarrack = new Queue<IBuildable>();

        _pooledPowerPlant = new Queue<IBuildable>();

        _pooledSoldier = new Queue<IBuildable>();

        for (int i = 0; i < _poolSizeBarrackPowerPlant; i++)
        {
            ObjectAddQueue(FactoryManager.Instance.CreateBarrack, _pooledBarrack);

            ObjectAddQueue(FactoryManager.Instance.CreatePowerPlate, _pooledPowerPlant);

            ObjectAddQueue(FactoryManager.Instance.CreateSoldier, _pooledSoldier);
        }
    }

    private void ObjectAddQueue(IBuildable buildable, Queue<IBuildable> queue)
    {
        buildable.gameObject.hideFlags = HideFlags.HideInHierarchy;

        buildable.gameObject.SetActive(false);

        queue.Enqueue(buildable.gameObject.GetComponent<IBuildable>());
    }

    public IBuildable GetBuilder(MenuItemScript.Type type, int soldierType = -1)
    {
        IBuildable obj = null;

        switch(type)
        {
            case MenuItemScript.Type.Barrack:
                if (_pooledBarrack.Count == 0)
                    ObjectAddQueue(FactoryManager.Instance.CreateBarrack, _pooledBarrack);
                obj = _pooledBarrack.Dequeue(); break;
            case MenuItemScript.Type.PowerPlate:
                if (_pooledPowerPlant.Count == 0)
                    ObjectAddQueue(FactoryManager.Instance.CreatePowerPlate, _pooledPowerPlant);
                obj = _pooledPowerPlant.Dequeue(); break;
            case MenuItemScript.Type.Soldier:
                if (_pooledSoldier.Count == 0)
                    ObjectAddQueue(FactoryManager.Instance.CreateSoldier, _pooledSoldier);
                obj = _pooledSoldier.Dequeue();
                ((SoldierScript)obj).SetView(soldierType); break;
        }

        obj.gameObject.SetActive(true);

        return obj;
    }

    public void SetBuilder(IBuildable buildable)
    {
        switch(buildable.GetType)
        {
            case MenuItemScript.Type.Barrack: _pooledBarrack.Enqueue(buildable); break;
            case MenuItemScript.Type.PowerPlate: _pooledPowerPlant.Enqueue(buildable); break;
            case MenuItemScript.Type.Soldier: _pooledSoldier.Enqueue(buildable); break;
        }

        buildable.gameObject.SetActive(false);
    }
}

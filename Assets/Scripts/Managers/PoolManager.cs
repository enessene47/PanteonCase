using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    [SerializeField] private GameObject _objectPrefabBarrack;
    [SerializeField] private GameObject _objectPrefabPowerPlant;
    [SerializeField] private GameObject _objectSoldierPlant;

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
            InstantiateObject(_objectPrefabBarrack, _pooledBarrack);
            InstantiateObject(_objectPrefabPowerPlant, _pooledPowerPlant);
            InstantiateObject(_objectSoldierPlant, _pooledSoldier);
        }
    }

    private void InstantiateObject<T>(GameObject prefab, Queue<T> queue)
    {
        GameObject obj = Instantiate(prefab);

        obj.SetActive(false);

        queue.Enqueue(obj.GetComponent<T>());
    }

    public IBuildable GetBuilder(MenuItemScript.Type type, int soldierType = -1)
    {
        IBuildable obj = null;

        switch(type)
        {
            case MenuItemScript.Type.Barrack:
                if (_pooledBarrack.Count == 0)
                    InstantiateObject(_objectPrefabBarrack, _pooledBarrack);
                obj = _pooledBarrack.Dequeue(); break;
            case MenuItemScript.Type.PowerPlate:
                if (_pooledPowerPlant.Count == 0)
                    InstantiateObject(_objectPrefabPowerPlant, _pooledPowerPlant);
                obj = _pooledPowerPlant.Dequeue(); break;
            case MenuItemScript.Type.Soldier:
                if (_pooledSoldier.Count == 0)
                    InstantiateObject(_objectSoldierPlant, _pooledSoldier);
                obj = _pooledSoldier.Dequeue();
                ((SoldierScript)obj).SetView(soldierType);
                break;
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

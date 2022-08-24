using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    [SerializeField] private GameObject _objectPrefabBarrack;
    [SerializeField] private GameObject _objectPrefabPowerPlant;
    [SerializeField] private GameObject _objectSoldierPlant;

    [SerializeField] private int _poolSizeBarrackPowerPlant;

    private Queue<IInformation> _pooledBarrack;

    private Queue<IInformation> _pooledPowerPlant;

    private Queue<IInformation> _pooledSoldier;

    private void Awake() => CreateBarrack();

    private void CreateBarrack()
    {
        _pooledBarrack = new Queue<IInformation>();

        _pooledPowerPlant = new Queue<IInformation>();

        _pooledSoldier = new Queue<IInformation>();

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

    public IInformation GetBuilder(MenuItemScript.Type type, int soldierType = -1)
    {
        IInformation obj = null;

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

    public void SetBuilder(IInformation obj)
    {
        switch(obj.GetType)
        {
            case MenuItemScript.Type.Barrack: _pooledBarrack.Enqueue(obj); break;
            case MenuItemScript.Type.PowerPlate: _pooledPowerPlant.Enqueue(obj); break;
            case MenuItemScript.Type.Soldier: _pooledSoldier.Enqueue(obj); break;
        }

        obj.gameObject.SetActive(false);
    }
}

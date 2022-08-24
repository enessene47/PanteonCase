using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    [SerializeField] private GameObject _objectPrefabBarrack;
    [SerializeField] private GameObject _objectPrefabPowerPlant;
    [SerializeField] private GameObject _objectSoldierPlant;

    [SerializeField] private int _poolSizeBarrackPowerPlant;

    private Queue<BarrackScript> _pooledBarrack;

    private Queue<PowerPlateScript> _pooledPowerPlant;

    private Queue<SoldierScript> _pooledSoldier;

    private void Awake() => CreateBarrack();

    private void CreateBarrack()
    {
        _pooledBarrack = new Queue<BarrackScript>();

        _pooledPowerPlant = new Queue<PowerPlateScript>();

        _pooledSoldier = new Queue<SoldierScript>();

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

    public void SetBuilder<T>(T t)
    {
        if (t is BarrackScript)
        {
            var obj = (BarrackScript)Convert.ChangeType(t, typeof(BarrackScript));

            BackPool(obj.gameObject, _pooledBarrack, obj);
        }
        else if (t is PowerPlateScript)
        {
            var obj = (PowerPlateScript)Convert.ChangeType(t, typeof(PowerPlateScript));

            BackPool(obj.gameObject, _pooledPowerPlant, obj);
        }
        else if(t is SoldierScript)
        {
            var obj = (SoldierScript)Convert.ChangeType(t, typeof(SoldierScript));

            BackPool(obj.gameObject, _pooledSoldier, obj);
        }
    }

    private void BackPool<T>(GameObject obj, Queue<T> queue, T t)
    {
        queue.Enqueue(t);

        obj.SetActive(false);
    }
}

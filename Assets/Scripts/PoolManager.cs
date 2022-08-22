using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    [SerializeField] private GameObject _objectPrefabBarrack;
    [SerializeField] private GameObject _objectPrefabPowerPlant;

    [SerializeField] private int _poolSizeBarrackPowerPlant;

    private Queue<BuilderScript> _pooledBarrack;

    private Queue<BuilderScript> _pooledPowerPlant;

    private void Awake() => CreateBarrack();

    private void CreateBarrack()
    {
        _pooledBarrack = new Queue<BuilderScript>();

        _pooledPowerPlant = new Queue<BuilderScript>();

        for (int i = 0; i < _poolSizeBarrackPowerPlant; i++)
        {
            GameObject barrack = Instantiate(_objectPrefabBarrack);
            GameObject powerPlant = Instantiate(_objectPrefabPowerPlant);

            barrack.SetActive(false);
            powerPlant.SetActive(false);

            barrack.hideFlags = HideFlags.HideInHierarchy;
            powerPlant.hideFlags = HideFlags.HideInHierarchy;

            _pooledBarrack.Enqueue(barrack.GetComponent<BuilderScript>());
            _pooledPowerPlant.Enqueue(powerPlant.GetComponent<BuilderScript>());
        }
    }

    public BuilderScript GetBuilderObject(MenuItemScript.Type type, Vector2 builderPos)
    {
        BuilderScript builder = null;

        switch (type)
        {
            case MenuItemScript.Type.Barrack: builder = _pooledBarrack.Dequeue(); break;
            case MenuItemScript.Type.PowerPlate: builder = _pooledPowerPlant.Dequeue(); break;
            default: builder = _pooledBarrack.Dequeue(); break;
        }

        builder.gameObject.SetActive(true);

        builder.GetTransform.position = builderPos;

        return builder; 
    }

    public void SetBuilderkObject(BuilderScript builder)
    {
        switch (builder.GetType)
        {
            case MenuItemScript.Type.Barrack: _pooledBarrack.Enqueue(builder); break;
            case MenuItemScript.Type.PowerPlate: _pooledPowerPlant.Enqueue(builder); break;
            default: _pooledBarrack.Enqueue(builder); break;
        }

        builder.gameObject.SetActive(false);

        _pooledBarrack.Enqueue(builder);
    }
}

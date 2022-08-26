using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryManager : MonoSingleton<FactoryManager>
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _barrackPrefab;
    [SerializeField] private GameObject _powerPlatePrefab;
    [SerializeField] private GameObject _soldierPrefab;
    [SerializeField] private GameObject _tilePrefab;

    public IBuildable CreateBarrack => Instantiate(_barrackPrefab).GetComponent<IBuildable>();
    public IBuildable CreatePowerPlate => Instantiate(_powerPlatePrefab).GetComponent<IBuildable>();
    public IBuildable CreateSoldier => Instantiate(_soldierPrefab).GetComponent<IBuildable>();
    public TileScript CreateTile(Vector2 pos, Quaternion quaternion) => Instantiate(_tilePrefab, pos, quaternion).GetComponent<TileScript>();
}

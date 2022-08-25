using UnityEngine;

public class BuilderManager : MonoSingleton<BuilderManager>
{
    [SerializeField] AstarPath astarPath;

    private IBuildable _builder;

    public void SetBuilder(IBuildable builder) => _builder = builder;

    public IBuildable Builder
    {
        get => _builder;
        set => _builder = value;
    }

    private SoldierScript _soldier;

    public SoldierScript Soldier
    {
        get => _soldier;
        set => _soldier = value;
    }

    public void SoldierSetTarget(Transform trs)
    {
        if (_soldier != null)
            _soldier.SetTarget(trs);
    }

    public void ScanPath() => astarPath.Scan();
}

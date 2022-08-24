using UnityEngine;

public class BuilderManager : MonoSingleton<BuilderManager>
{
    private IInformation _builder;

    public void SetBuilder(IInformation builder) => _builder = builder;

    public IInformation Builder
    {
        get => _builder;
        set => _builder = value;
    }

    [SerializeField] AstarPath astarPath;

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

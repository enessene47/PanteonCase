using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    //private Action _onDown;

    private IInformation _builder;

    [SerializeField] AstarPath astarPath;

    private SoldierScript _soldier;

    public SoldierScript Soldier
    {
        set => _soldier = value;
    }


    public void SetBuilder(IInformation builder) => _builder = builder;

    private void Update()
    {
        if (Input.GetMouseButton(0) && _builder != null)
        {
            _builder.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if(Input.GetMouseButtonUp(0) && _builder != null)
        {
            Transform trs = GridManager.Instance.CalculateDistance(_builder);

            if (trs != null)
                _builder.Build(trs.position);
            else
                PoolManager.Instance.SetBuilder(_builder);

            _builder = null;

            _soldier = null;

            astarPath.Scan();
        }
    }

    public void SoldierSetTarget(Transform trs)
    {
        if(_soldier != null)
            _soldier.SetTarget(trs);
    }
}

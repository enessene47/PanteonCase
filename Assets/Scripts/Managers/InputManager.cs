using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    private void Update()
    {
        if (Input.GetMouseButton(0) && BuilderManager.Instance.Builder != null)
        {
            BuilderManager.Instance.Builder.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if(Input.GetMouseButtonUp(0) && BuilderManager.Instance.Builder != null)
        {
            Transform trs = GridManager.Instance.CalculateDistance(BuilderManager.Instance.Builder);

            if (trs != null)
                BuilderManager.Instance.Builder.Build(trs.position);
            else
                PoolManager.Instance.SetBuilder(BuilderManager.Instance.Builder);

            BuilderManager.Instance.Builder = null;

            BuilderManager.Instance.Soldier = null;

            BuilderManager.Instance.ScanPath();
        }
    }


}

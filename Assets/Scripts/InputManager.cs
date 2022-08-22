using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    //private Action _onDown;

    private BuilderScript _builder;


    public void SetBuilder(BuilderScript builder) => _builder = builder;

    private void Update()
    {
        if (Input.GetMouseButton(0) && _builder != null)
        {
            _builder.GetTransform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if(Input.GetMouseButtonUp(0) && _builder != null)
        {
            PoolManager.Instance.SetBuilderkObject(_builder);

            _builder = null;
        }
    }
}

using System;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    public Action tapDown;  
    public Action onTap;  
    public Action tapUp;  

    private bool _gameActive;

    private void Start()
    {
        onTap += () =>
        {
            if(BuilderManager.Instance.Builder != null)
                BuilderManager.Instance.Builder.transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
        };

        tapUp += () =>
        {
            if (BuilderManager.Instance.Builder != null)
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
        };
    }

    private void Update()
    {
        if(!_gameActive && Input.GetMouseButtonUp(0))
        {
            _gameActive = true;

            EventManager.Instance.StartEvent.Invoke();
        }
        else if(_gameActive)
            InputControl();
    }

    private void InputControl()
    {
        if (Input.GetMouseButton(0))
            onTap();
        else if (Input.GetMouseButtonUp(0))
            tapUp();
    }
}

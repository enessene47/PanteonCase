using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private GameObject _barrackPanel;
    [SerializeField] private GameObject _powerPlatePanel;

    public void PanelActive(bool barrack)
    {
        _barrackPanel.SetActive(barrack);
        _powerPlatePanel.SetActive(!barrack);
    }

    public void PanelNotActive()
    {
        _barrackPanel.SetActive(false);
        _powerPlatePanel.SetActive(false);
    }
}

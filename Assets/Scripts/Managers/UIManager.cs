using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private GameObject _barrackPanel;
    [SerializeField] private GameObject _powerPlatePanel;
    [SerializeField] private GameObject _soldierPanel;

    [SerializeField] private Image _soldierImage;
    [SerializeField] private TextMeshProUGUI _soldierName;
    [SerializeField] private TextMeshProUGUI _soldierSpeed;

    public void PanelActive(bool barrack = false, bool powerPlate = false, bool soldier = false)
    {
        _barrackPanel.SetActive(barrack);
        _powerPlatePanel.SetActive(powerPlate);
        _soldierPanel.SetActive(soldier);
    }

    public void SoldierPanelOption(float speed = 3, string sprite = "Soldier1")
    {
        _soldierImage.sprite = SpriteAtlasManager.Instance.GetSpriteAtlas(sprite);

        _soldierName.text = sprite;
        _soldierSpeed.text = "Speed: " + speed;
    }

    public void PanelNotActive()
    {
        _barrackPanel.SetActive(false);
        _powerPlatePanel.SetActive(false);
        _soldierPanel.SetActive(false);
    }
}

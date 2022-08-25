using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoSingleton<UIManager>
{
    [Header("Panel")]
    [SerializeField] private GameObject _building;
    [SerializeField] private GameObject _barrackPanel;
    [SerializeField] private GameObject _powerPlatePanel;
    [SerializeField] private GameObject _soldierPanel;
    [SerializeField] private GameObject _tapToStart;

    [Header("Image")]
    [SerializeField] private Image _soldierImage;

    [Header("TextMeshProGUI")]
    [SerializeField] private TextMeshProUGUI _soldierNameText;
    [SerializeField] private TextMeshProUGUI _soldierSpeedText;
    [SerializeField] private TextMeshProUGUI _totalEnergyText;

    private void Start() => EventManager.Instance.StartEvent.AddListener(() => 
    {
        DataManager.Instance.Energy = 0;

        _building.SetActive(true);

        _tapToStart.SetActive(false);
    });

    public void PanelActive(bool barrack = false, bool powerPlate = false, bool soldier = false)
    {
        _barrackPanel.SetActive(barrack);

        _powerPlatePanel.SetActive(powerPlate);

        _soldierPanel.SetActive(soldier);
    }

    public void SoldierPanelOption(float speed = 3, string sprite = "Soldier1")
    {
        _soldierImage.sprite = SpriteAtlasManager.Instance.GetSpriteAtlas(sprite);

        _soldierNameText.text = sprite;

        _soldierSpeedText.text = "Speed: " + speed;
    }

    public void PanelNotActive()
    {
        _barrackPanel.SetActive(false);

        _powerPlatePanel.SetActive(false);

        _soldierPanel.SetActive(false);
    }

    public void EnergyTextUpdate(int energy) => _totalEnergyText.text = "Total Energy: " + energy;
}

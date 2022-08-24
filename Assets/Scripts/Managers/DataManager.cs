using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    private int _energy;

    public int Energy 
    {
        get => _energy;

        set
        {
            _energy += value;

            PlayerPrefs.SetInt("Energy", _energy);

            UIManager.Instance.EnergyTextUpdate(_energy);
        }
    }

    private void Start() => FirstGetData();

    private void FirstGetData() => _energy = PlayerPrefs.GetInt("Energy");
}

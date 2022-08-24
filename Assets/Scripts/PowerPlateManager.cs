using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlateManager : MonoSingleton<PowerPlateManager>
{
    private List<PowerPlateScript> _powerPlateScripts = new List<PowerPlateScript>();

    public void AddPowerPlate(PowerPlateScript pPS) => _powerPlateScripts.Add(pPS);

    public void Start() => StartCoroutine(EnergyProduction());

    private IEnumerator EnergyProduction()
    {
        foreach (var pPS in _powerPlateScripts)
            if (pPS.IsActive)
                pPS.Production();

        yield return new WaitForSeconds(5f);

        StartCoroutine(EnergyProduction());
    }
}

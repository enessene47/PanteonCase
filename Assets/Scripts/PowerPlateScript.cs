using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PowerPlateScript : MonoBehaviour, IInformation, IPointerClickHandler
{
    private MenuItemScript.Type _type = MenuItemScript.Type.PowerPlate;

    public void Information()
    {
        Debug.Log(gameObject.name);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            Information();
    }
    MenuItemScript.Type IInformation.GetType => _type;

    public Transform GetTransform => transform;
}

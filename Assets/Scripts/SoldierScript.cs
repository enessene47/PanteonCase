using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoldierScript : MonoBehaviour, IInformation, IPointerClickHandler
{
    [SerializeField] private AIDestinationSetter _aIDestinationSetter;

    private MenuItemScript.Type _type = MenuItemScript.Type.Soldier;

    public void Information()
    {
        Debug.Log(gameObject.name);

        InputManager.Instance.Soldier = this;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            Information();
    }

    public Transform GetTransform => transform;

    MenuItemScript.Type IInformation.GetType => _type;

    public void SetTarget(Transform trs) => _aIDestinationSetter.target = trs;
}

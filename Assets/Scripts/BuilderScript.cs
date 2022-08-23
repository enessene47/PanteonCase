using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuilderScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] MenuItemScript.Type type;

    [SerializeField] AIDestinationSetter aIDestinationSetter;

    public Transform GetTransform => transform;

    public MenuItemScript.Type GetType => type;

    public void OnPointerClick(PointerEventData eventData)
    {
        /*if(eventData.button == PointerEventData.InputButton.Left)
            if(type == MenuItemScript.Type.Soldier)*/

    }
}

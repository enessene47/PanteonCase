using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderScript : MonoBehaviour
{
    [SerializeField] MenuItemScript.Type type;

    public Transform GetTransform => transform;

    public MenuItemScript.Type GetType => type;
}

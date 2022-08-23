using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInformation
{
    void Information();

    Transform transform { get; }

    MenuItemScript.Type GetType { get; }
}

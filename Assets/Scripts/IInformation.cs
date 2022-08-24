using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInformation
{
    void Information();

    void Build(Vector2 pos);

    Transform transform { get; }

    MenuItemScript.Type GetType { get; }
}

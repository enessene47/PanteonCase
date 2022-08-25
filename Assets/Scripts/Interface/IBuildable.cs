using UnityEngine;

public interface IBuildable
{
    void Information();

    void Build(Vector2 pos);

    GameObject gameObject { get; }

    Transform transform { get; }

    MenuItemScript.Type GetType { get; }
}

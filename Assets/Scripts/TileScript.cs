using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;

    private bool _build;

    public int x, y;

    public void Init(bool isOffset) => _renderer.color = isOffset ? _offsetColor : _baseColor;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
            InputManager.Instance.SoldierSetTarget(transform);
        else if (eventData.button == PointerEventData.InputButton.Left)
            UIManager.Instance.PanelNotActive();
    }

    public Vector2 GetPos => transform.position;
    public Transform GetTransform => transform;
}

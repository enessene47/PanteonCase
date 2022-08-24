using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;

    [SerializeField] BoxCollider2D boxColl;

    private bool _build;

    public int x, y;

    public void Init(bool isOffset) => _renderer.color = isOffset ? _offsetColor : _baseColor;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Click");

            InputManager.Instance.SoldierSetTarget(transform);
        }
    }

    public Vector2 GetPos => transform.position;
    public Transform GetTransform => transform;
}

using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoldierScript : MonoBehaviour, IInformation, IPointerClickHandler
{
    [SerializeField] private AIDestinationSetter _aIDestinationSetter;

    private MenuItemScript.Type _type = MenuItemScript.Type.Soldier;

    [SerializeField] private BoxCollider2D _boxCollider2D;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    private bool _isActive;

    private bool _builder = true;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Builder") && !_isActive)
        {
            _spriteRenderer.color = Color.red;

            _builder = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Builder") && !_isActive)
        {
            _spriteRenderer.color = Color.white;

            _builder = true;
        }
    }

    public void Build(Vector2 vec)
    {
        if (!_builder)
        {
            _spriteRenderer.color = Color.white;

            PoolManager.Instance.SetBuilder(this);

            return;
        }

        transform.position = vec;

        //_boxCollider2D.isTrigger = false;

        _isActive = true;
    }
}

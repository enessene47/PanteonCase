using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoldierScript : MonoBehaviour, IInformation, IPointerClickHandler
{
    [SerializeField] private AIDestinationSetter _aIDestinationSetter;

    private MenuItemScript.Type _type = MenuItemScript.Type.Soldier;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private Sprite[] _sprites;

    private bool _isActive;

    private bool _builder = true;

    public void SetView(int index = 0) => _spriteRenderer.sprite = SpriteAtlasManager.Instance.GetSpriteAtlas(index == 0 ? "Soldier1" : "Soldier2");

    public void Information()
    {
        UIManager.Instance.PanelNotActive();

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

        _isActive = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PowerPlateScript : MonoBehaviour, IInformation, IPointerClickHandler
{
    private MenuItemScript.Type _type = MenuItemScript.Type.PowerPlate;

    [SerializeField] private BoxCollider2D _boxCollider2D;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] public GameObject _floor;

    [SerializeField] GameObject energyAnim;

    private bool _isActive;

    private bool _builder = true;

    private void Start()
    {
        PowerPlateManager.Instance.AddPowerPlate(this);

        _spriteRenderer.sprite = SpriteAtlasManager.Instance.GetSpriteAtlas("PowerPlate");
    }

    public void Information()
    {
        UIManager.Instance.PanelActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            Information();
    }

    MenuItemScript.Type IInformation.GetType => _type;

    public Transform GetTransform => transform;

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

        _boxCollider2D.isTrigger = false;

        _isActive = true;

        _floor.SetActive(true);
    }

    public void Production()
    {
        energyAnim.SetActive(false);
        energyAnim.SetActive(true);
    }

    public bool IsActive => gameObject.activeSelf;
}

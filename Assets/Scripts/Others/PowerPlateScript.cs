using UnityEngine;
using UnityEngine.EventSystems;

public class PowerPlateScript : CustomManager, IBuildable, IPointerClickHandler
{
    private MenuItemScript.Type _type = MenuItemScript.Type.PowerPlate;

    [SerializeField] public GameObject _floor;

    [SerializeField] GameObject energyAnim;

    private bool _isActive;

    private bool _builder = true;

    private void Start()
    {
        PowerPlateManager.Instance.AddPowerPlate(this);

        SpriteRenderer.sprite = SpriteAtlasManager.Instance.GetSpriteAtlas("PowerPlate");
    }

    public void Information() => UIManager.Instance.PanelActive(powerPlate: true);

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            Information();
    }

    MenuItemScript.Type IBuildable.GetType => _type;

    public Transform GetTransform => transform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Builder") && !_isActive)
        {
            SpriteRenderer.color = Color.red;

            _builder = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Builder") && !_isActive)
        {
            SpriteRenderer.color = Color.white;

            _builder = true;

            BoxCollider2D.enabled = false;

            BoxCollider2D.enabled = true;
        }
    }

    public void Build(Vector2 vec)
    {
        if (!_builder)
        {
            SpriteRenderer.color = Color.white;

            PoolManager.Instance.SetBuilder(this);

            return;
        }

        transform.position = vec;

        BoxCollider2D.isTrigger = false;

        _isActive = true;

        _floor.SetActive(true);

        Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void Production()
    {
        energyAnim.SetActive(false);
        energyAnim.SetActive(true);

        DataManager.Instance.Energy = 1;
    }

    public bool IsActive => gameObject.activeSelf;
}

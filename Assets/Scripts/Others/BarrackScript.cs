using UnityEngine;
using UnityEngine.EventSystems;

public class BarrackScript : CustomManager, IBuildable, IPointerClickHandler
{
    private MenuItemScript.Type _type = MenuItemScript.Type.Barrack;

    [SerializeField] public GameObject _floor;

    private bool _isActive;

    private bool _builder = true;

    private void Start() => SpriteRenderer.sprite = SpriteAtlasManager.Instance.GetSpriteAtlas("Barrack");

    public void Information() => UIManager.Instance.PanelActive(barrack: true);

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            Information();
    }

    MenuItemScript.Type IBuildable.GetType => _type;

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

        Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;

        _isActive = true;

        _floor.SetActive(true);
    }
}

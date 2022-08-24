using UnityEngine;
using UnityEngine.EventSystems;
using Pathfinding;


public class SoldierScript : MonoBehaviour, IInformation, IPointerClickHandler
{
    [SerializeField] private AIDestinationSetter _aIDestinationSetter;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private AIPath _aIPath;

    private MenuItemScript.Type _type = MenuItemScript.Type.Soldier;

    private bool _isActive;

    private bool _builder = true;

    private bool _soldier1;

    public void SetView(int index = 0)
    {
        _soldier1 = index == 0 ? true : false;

        _spriteRenderer.sprite = SpriteAtlasManager.Instance.GetSpriteAtlas(index == 0 ? "Soldier1" : "Soldier2");

        _aIPath.maxSpeed = index == 0 ? 3 : 5;
    }

    public void Information()
    {
        UIManager.Instance.PanelActive(soldier: true);

        if (_soldier1)
            UIManager.Instance.SoldierPanelOption();
        else
            UIManager.Instance.SoldierPanelOption(5, "Soldier2");

        BuilderManager.Instance.Soldier = this;
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

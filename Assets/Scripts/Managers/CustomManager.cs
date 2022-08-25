using UnityEngine;
using UnityEngine.UI;

public abstract class CustomManager : MonoBehaviour
{
    private Animator _animator;

    public Animator Animator
    {
        get
        {
            if (_animator == null)
                _animator = GetComponent<Animator>();

            return _animator;
        }
    }

    private Rigidbody physics;

    public Rigidbody Rigidbody
    {
        get
        {
            if (physics == null)
                physics = GetComponent<Rigidbody>();

            return physics;
        }
    }

    private Rigidbody2D physics2D;

    public Rigidbody2D Rigidbody2D
    {
        get
        {
            if (physics2D == null)
                physics2D = GetComponent<Rigidbody2D>();

            return physics2D;
        }
    }

    private Collider _coll;

    public Collider Collider
    {
        get
        {
            if (_coll == null)
                _coll = GetComponent<Collider>();

            return _coll;
        }
    }

    private Collider2D _coll2D;

    public Collider2D Collider2D
    {
        get
        {
            if (_coll2D == null)
                _coll2D = GetComponent<Collider2D>();

            return _coll2D;
        }
    }

    private BoxCollider _boxCollider;

    public BoxCollider BoxCollider
    {
        get
        {
            if (_boxCollider == null)
                _boxCollider = GetComponent<BoxCollider>();

            return _boxCollider;
        }
    }


    private BoxCollider2D _boxCollider2D;

    public BoxCollider2D BoxCollider2D
    {
        get
        {
            if (_boxCollider2D == null)
                _boxCollider2D = GetComponent<BoxCollider2D>();

            return _boxCollider2D;
        }
    }

    private SphereCollider _sphereCollider;

    public SphereCollider SphereCollider
    {
        get
        {
            if (_sphereCollider == null)
                _sphereCollider = GetComponent<SphereCollider>();

            return _sphereCollider;
        }
    }

    private CapsuleCollider _capsuleCollider;

    public CapsuleCollider CapsuleCollider
    {
        get
        {
            if (_capsuleCollider == null)
                _capsuleCollider = GetComponent<CapsuleCollider>();

            return _capsuleCollider;
        }
    }

    private MeshCollider _meshCollider;

    public MeshCollider MeshCollider
    {
        get
        {
            if (_meshCollider == null)
                _meshCollider = GetComponent<MeshCollider>();

            return _meshCollider;
        }
    }

    private Renderer _rend;

    public Renderer Renderer
    {
        get
        {
            if (_rend == null)
                _rend = GetComponent<Renderer>();

            return _rend;
        }
    }

    private SpriteRenderer _spriteRenderer;

    public SpriteRenderer SpriteRenderer
    {
        get
        {
            if (_spriteRenderer == null)
                _spriteRenderer = GetComponent<SpriteRenderer>();

            return _spriteRenderer;
        }
    }

    private SkinnedMeshRenderer _skinnedMeshRenderer;

    public SkinnedMeshRenderer SkinnedMeshRenderer
    {
        get
        {
            if (_skinnedMeshRenderer == null)
                _skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

            return _skinnedMeshRenderer;
        }
    }

    private MeshFilter _meshFilter;

    public MeshFilter MeshFilter
    {
        get
        {
            if (_meshFilter == null)
                _meshFilter = GetComponent<MeshFilter>();

            return _meshFilter;
        }
    }

    private Camera _camera;

    public Camera Camera
    {
        get
        {
            if (_camera == null)
                _camera = GetComponent<Camera>();

            return _camera;
        }
    }

    private AudioSource _audioSource;

    public AudioSource AudioSource
    {
        get
        {
            if (_audioSource == null)
                _audioSource = GetComponent<AudioSource>();

            return _audioSource;
        }
    }

    private TrailRenderer _trailRenderer;

    public TrailRenderer TrailRenderer
    {
        get
        {
            if (_trailRenderer == null)
                _trailRenderer = GetComponent<TrailRenderer>();

            return _trailRenderer;
        }
    }

    private Image _image;

    public Image Image
    {
        get
        {
            if (_image == null)
                _image = GetComponent<Image>();

            return _image;
        }
    }
}

using UnityEngine;

public class MonsterMoveController : MonoBehaviour
{
    private bool _isFlip = false;
    private float _moveSpeed = 1f; //캐릭터 테이블에있음.
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    private Monster _owner;



    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _owner = GetComponent<Monster>();
    }
    private void Update()
    {
        _spriteRenderer.flipX = _isFlip;
    }
    private void FixedUpdate()
    {
        if (_owner.HealthPoint < 0)
            return;
        Move();
    }
    private void Move()
    {

        if (!_isFlip)
            gameObject.transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
        else
            gameObject.transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            _isFlip = !_isFlip;
        }
    }
}

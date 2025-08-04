using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMoveController : MonoBehaviour
{
    private readonly int MaxJumpNum = 2;
    private bool _isFlip = false;
    private bool _isOnTheFloor = true;
    private float _jumpForce = 5f;
    private float _moveSpeed = 3f; //캐릭터 테이블에있음.
    private int _jumpNum = 0;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();

        _spriteRenderer.flipX = _isFlip;

    }
    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _jumpNum < MaxJumpNum)
        {
            _animator.SetInteger("State", 2);
            _isOnTheFloor = false;
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
            _jumpNum++;
            return;
        }
        else if (!_isOnTheFloor)
        {
            _animator.SetInteger("State", 2);
            return;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _isFlip = true;
            _animator.SetInteger("State", 1);
            _rigidBody.linearVelocity = Vector3.right * _moveSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _isFlip = false;
            _animator.SetInteger("State", 1);
            _rigidBody.linearVelocity = Vector3.left * _moveSpeed;
        }
        else
        {
            _animator.SetInteger("State", 0);
        }


      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tile" && !_isOnTheFloor)
        {
            _animator.SetInteger("State", 0);
            _isOnTheFloor = true;
            _jumpNum = 0;
        }
    }
}

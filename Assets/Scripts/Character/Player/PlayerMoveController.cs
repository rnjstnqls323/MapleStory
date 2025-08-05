using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMoveController : MonoBehaviour
{
    private readonly int MaxJumpNum = 2;
    private bool _isFlip = false;
    private bool _isOnTheFloor = true;
    private float _jumpForce = 7f;
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

        Jump();
        _spriteRenderer.flipX = _isFlip;

    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) &&  _jumpNum < MaxJumpNum)
        {
            _jumpNum++;
            _animator.SetInteger("State", 2);
            _isOnTheFloor = false;
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
    private void Move()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _isFlip = true;
            _animator.SetInteger("State", 1);
            transform.Translate(Vector3.right*Time.deltaTime * _moveSpeed);
            //_rigidBody.linearVelocity = Vector3.right * _moveSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _isFlip = false;
            _animator.SetInteger("State", 1);
            transform.Translate(Vector3.left * Time.deltaTime * _moveSpeed);
        }
        else
        {
            _animator.SetInteger("State", 0);
        }

        if(!_isOnTheFloor)
        {
            _animator.SetInteger("State", 2);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tile" || collision.gameObject.tag == "Wall")
        {
            if (_isOnTheFloor) return;
            _jumpNum = 0;
            _animator.SetInteger("State", 0);
            _isOnTheFloor = true;
        }
    }

}

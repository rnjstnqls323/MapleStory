using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMoveController : MonoBehaviour
{
    private enum CharacterState
    {
        Idle, Move, Jump, Attack, Skill1
    }
    private readonly int MaxJumpNum = 2;
    private bool _isFlip = false;
    private bool _isOnTheFloor = true;
    

    private float _jumpForce = 7f;
    private float _moveSpeed = 3f; //캐릭터 테이블에있음.
    private int _jumpNum = 0;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    private CharacterState _state = CharacterState.Idle;



    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

        Jump();
        Animation();
        ChangeAnimation();
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
            _state = CharacterState.Jump;
            _isOnTheFloor = false;
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
    private void Move()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _isFlip = true;
            transform.Translate(Vector3.right*Time.deltaTime * _moveSpeed);
            //_rigidBody.linearVelocity = Vector3.right * _moveSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _isFlip = false;
            transform.Translate(Vector3.left * Time.deltaTime * _moveSpeed);
        }

    }
    private void Animation()
    {
        if (Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.LeftArrow))
        {
            _state = CharacterState.Move;
        }
        else
        {
            _state = CharacterState.Idle;
        }

        if (!_isOnTheFloor)
        {
            _state = CharacterState.Jump;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            _state = CharacterState.Attack;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            _state = CharacterState.Skill1;
        }
    }
    private void ChangeAnimation()
    {
        switch(_state)
        {
            case CharacterState.Idle:
                _animator.SetInteger("State", 0);
                break;
            case CharacterState.Move:
                _animator.SetInteger("State", 1);
                break;
            case CharacterState.Jump:
                _animator.SetInteger("State", 2);
                break;
            case CharacterState.Attack:
                _animator.SetInteger("State", 3);
                break;
            case CharacterState.Skill1:
                _animator.SetInteger("State", 4);
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tile" || collision.gameObject.tag == "Wall")
        {
            if (_isOnTheFloor) return;
            _jumpNum = 0;
            _state = CharacterState.Idle;
            _isOnTheFloor = true;
        }
    }

}

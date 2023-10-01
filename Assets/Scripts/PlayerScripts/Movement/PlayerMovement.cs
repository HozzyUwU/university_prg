using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    private CharacterController _controller;
    private PlayerController _playerController;

    [SerializeField] private float _jumpVelocity;
    [SerializeField] private float _gravityScale;
    [SerializeField] private float _runningSpeed;

    private Vector3 _moveDirection;


    private void Awake()
    {
        
        _playerController = GetComponent<PlayerController>();
        _controller = GetComponent<CharacterController>();
        _jumpVelocity = 8f;
        _gravityScale = 2f;
    }
    private void OnEnable()
    {
        _playerController.JumpInitiated += PlayerJump;
        _playerController.SwipeUpDetected += ChangePlatformUp;
        _playerController.SwipeDownDetected += ChangePlatformDown;
    }

    private void OnDisable()
    {
        _playerController.JumpInitiated -= PlayerJump;
        _playerController.SwipeUpDetected -= ChangePlatformUp;
        _playerController.SwipeDownDetected -= ChangePlatformDown;
    }

    private void PlayerJump(InputAction.CallbackContext context)
    {
        if(_controller.isGrounded)
        {
            _moveDirection.y = _jumpVelocity;
        }
    }

    private void ChangePlatformUp(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector2.up, out hit, 5))
        {
            Teleport(new Vector3(transform.position.x, hit.point.y + 1f, transform.position.z));
        }
    }

    private void ChangePlatformDown(InputAction.CallbackContext context)
    {
        RaycastHit[] hit = Physics.RaycastAll(transform.position, Vector2.down, 8);
        if(hit[0].distance > hit[1].distance)
        {
            Teleport(new Vector3(transform.position.x, hit[0].point.y + 1f, transform.position.z));
        }
        else
        {
            Teleport(new Vector3(transform.position.x, hit[1].point.y + 1f, transform.position.z));
        }
    }

    private void Teleport(Vector3 _position)
    {
        _controller.transform.position = _position;
    }

    void Update()
    {
        _moveDirection = new Vector3(_runningSpeed, _moveDirection.y, 0f);
        _moveDirection.y += Physics.gravity.y * _gravityScale * Time.deltaTime;
        Physics.SyncTransforms();
        _controller.Move(_moveDirection * Time.deltaTime);
    }
}

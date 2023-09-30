using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    private CharacterController _controller;
    private PlayerController _playerController;

    [SerializeField] private float jumpVelocity;
    [SerializeField] private float gravityScale;
    [SerializeField] private float runningSpeed;

    private Vector3 moveDirection;


    private void Awake()
    {
        
        _playerController = GetComponent<PlayerController>();
        _controller = GetComponent<CharacterController>();
        jumpVelocity = 8f;
        gravityScale = 2f;
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
            moveDirection.y = jumpVelocity;
        }
    }

    private void ChangePlatformUp(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector2.up, out hit))
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
        //Debug.Log("Event 0 is triggered " + hit[0].collider + " " + hit[1].collider);
    }

    private void Teleport(Vector3 _position)
    {
        _controller.enabled = false;
        _controller.transform.position = _position;
        _controller.enabled = true;
    }
    
    void Update()
    {   
        moveDirection = new Vector3(runningSpeed, moveDirection.y, 0f);
        moveDirection.y += Physics.gravity.y * gravityScale * Time.deltaTime;
        _controller.Move(moveDirection * Time.deltaTime);
    }
}

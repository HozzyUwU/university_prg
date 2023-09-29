using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    private CharacterController controller;

    private PlayerInput playerInput;
    private InputManager inputManager;

    [SerializeField] private float jumpVelocity;
    [SerializeField] private float gravityScale;
    [SerializeField] private float runningSpeed;

    private Vector3 moveDirection;


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        inputManager = InputManager.Instance;

        controller = GetComponent<CharacterController>();
        jumpVelocity = 8f;
        gravityScale = 2f;
    }
    private void OnEnable()
    {
        inputManager.OnPerformedTouch += PlayerJump;
    }

    private void OnDisable()
    {
        inputManager.OnPerformedTouch -= PlayerJump;
    }

    private void PlayerJump(InputAction.CallbackContext context)
    {
        if(controller.isGrounded)
        {
            moveDirection.y = jumpVelocity;
        }
    }

    void Update()
    {
        moveDirection = new Vector3(runningSpeed, moveDirection.y, 0f);
        moveDirection.y += Physics.gravity.y * gravityScale * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

}

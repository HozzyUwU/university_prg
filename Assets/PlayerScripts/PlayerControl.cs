using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    //private Rigidbody rb;
    private CharacterController controller;

    private PlayerInput playerInput;
    private InputAction touchPressAction;

    [SerializeField] private float jumpVelocity;
    [SerializeField] private float gravityScale;
    [SerializeField] private float runningSpeed;

    private Vector3 moveDirection;


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions["TouchPress"];

        controller = GetComponent<CharacterController>();
        jumpVelocity = 8f;
        gravityScale = 2f;
    }

    void Update()
    {
        moveDirection = new Vector3(runningSpeed, moveDirection.y, 0f);
        if(controller.isGrounded)
        {
            if (touchPressAction.WasPerformedThisFrame())
            {
                moveDirection.y = jumpVelocity;
            }
        }

        moveDirection.y += Physics.gravity.y * gravityScale * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

}

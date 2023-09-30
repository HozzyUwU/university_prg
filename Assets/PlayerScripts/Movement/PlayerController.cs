using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private TouchControlls _playerInputController;

    private Vector2 _startedPosition = Vector2.zero;
    private Vector2 _currentPosition = Vector2.zero;

    [Header("Swipe Detection Properties")]
    [Space]
    [SerializeField] private byte _swipeThreshold;

    public delegate void OnSwipeDetection(InputAction.CallbackContext context);
    public event OnSwipeDetection SwipeUpDetected;
    public event OnSwipeDetection SwipeDownDetected;
    public delegate void OnJumpStart(InputAction.CallbackContext context);
    public event OnJumpStart JumpInitiated;
    private void Awake() 
    {
        // Instantiating input system object
        _playerInputController = new TouchControlls();

        // Better enabling input actions in action map
        var touchInteraction = _playerInputController.TouchInteraction;
        touchInteraction.Enable();    

        touchInteraction.TouchPosition.performed += t => { _currentPosition = touchInteraction.TouchPosition.ReadValue<Vector2>(); };
        touchInteraction.TouchPress.started += t => {_startedPosition = _currentPosition; };
        touchInteraction.TouchPress.canceled += SwipeDetection;
    }

    private void SwipeDetection(InputAction.CallbackContext context)
    {
        Vector2 delta = _currentPosition - _startedPosition;
        
        if(delta.magnitude < _swipeThreshold)
        {
            ProduceJump(/*delta.magnitude*/ context);
            return;
        }

        //if(Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        //{
        //    Debug.Log("Horizontal Swipe");
        //}

        if(Mathf.Abs(delta.x) < Mathf.Abs(delta.y))
        {
            Debug.Log("Vertical Swipe");
            if (delta.y > 0)
            {
                Debug.Log("Swipe Up" + delta.y + " " + _startedPosition.y);
                if (SwipeUpDetected != null) SwipeUpDetected(context);
            }
            else
            {
                Debug.Log("Swipe Down" + delta.y + " " + _startedPosition.y);
                if (SwipeDownDetected != null) SwipeDownDetected(context);
            }
        }

    }

    private void ProduceJump(/*float magnitude*/ InputAction.CallbackContext context)
    {
        //Debug.Log($"Jump was performed with magnitude: {magnitude}");
        if (JumpInitiated != null) JumpInitiated(context);
    }
}



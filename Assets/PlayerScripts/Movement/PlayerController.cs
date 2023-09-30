using System.Collections;
using System.Collections.Generic;
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
            ProduceJump(delta.magnitude);
            return;
        }

        if(Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            Debug.Log("Horizontal Swipe");
        }else
        {
            Debug.Log("Vertical Swipe");
        }

    }

    private void ProduceJump(float magnitude)
    {
        Debug.Log($"Jump was performed with magnitude: {magnitude}");
    }
}



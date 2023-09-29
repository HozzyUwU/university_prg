using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{

    #region Events
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;
    public delegate void PerformedTouch(InputAction.CallbackContext context);
    public event PerformedTouch OnPerformedTouch;
    #endregion

    private TouchControlls touchControlls;
    private Camera mainCamera;
    private void Awake()
    {
        touchControlls = new TouchControlls();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        touchControlls.Enable();
    }

    private void OnDisable()
    {
        touchControlls.Disable();

    }

    private void Start()
    {
        touchControlls.Touch.TouchPress.started += ctx => StartTouchPrimary(ctx);
        touchControlls.Touch.TouchPress.canceled += ctx => EndTouchPrimary(ctx);
        touchControlls.Touch.TouchInput.performed += ctx => PerformedTouchPrimary(ctx);
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        //if (OnStartTouch != null) OnStartTouch(Utils.ScreenToWorld(mainCamera, touchControlls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
        if (OnStartTouch != null) OnStartTouch(touchControlls.Touch.PrimaryPosition.ReadValue<Vector2>().normalized, (float)context.startTime);
        //Debug.Log("Start " + Touchscreen.current.primaryTouch.position.ReadValue());
    }
    
    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        //if (OnEndTouch != null) OnEndTouch(Utils.ScreenToWorld(mainCamera, touchControlls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
        if (OnEndTouch != null) OnEndTouch(touchControlls.Touch.PrimaryPosition.ReadValue<Vector2>().normalized, (float)context.time);
        //Debug.Log("End" + Touchscreen.current.primaryTouch.position.ReadValue());
    }

    private void PerformedTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnPerformedTouch != null) OnPerformedTouch(context);
        Debug.Log("Button Touch is performed");
    }

    public Vector2 PrimaryPosition()
    {
        return Utils.ScreenToWorld(mainCamera, touchControlls.Touch.PrimaryPosition.ReadValue<Vector2>());
    }
}

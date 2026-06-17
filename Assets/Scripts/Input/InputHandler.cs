using UnityEngine;
using VContainer;
public class InputHandler:MonoBehaviour
{
    [Inject] public IInputReciever reciever;
    public bool isPressed;
    private Vector2 pointerPosition;
    public void OnPress(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (reciever == null) return;
            reciever.OnClickDown(pointerPosition);
            isPressed=true;
        }
        if (context.canceled)
        {
            if (reciever == null) return;
            reciever.OnClickUp(pointerPosition);
            isPressed=false;
        }
    }
    public void OnPoint(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        if (reciever == null) return;
        pointerPosition = ctx.ReadValue<Vector2>();
        
        reciever.OnPointerMoved(pointerPosition, isPressed);
    }
}

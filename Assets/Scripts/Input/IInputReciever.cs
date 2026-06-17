using UnityEngine;

public interface IInputReciever
{
    public void OnClickUp(Vector2 screenPosition);
    public void OnClickDown(Vector2 screenPosition);
    public void OnPointerMoved(Vector2 screenPosition, bool isPressed);
}

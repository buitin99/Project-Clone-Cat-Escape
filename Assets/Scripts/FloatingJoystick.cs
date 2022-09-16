using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public enum JoyStickDirection { Horizontal, Vertical, Both}
public class FloatingJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    Vector2 JoyPosition;
    
    public Vector2 direction;

    public bool isDrag = false;
    private void FixedUpdate() {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDrag = true;
        JoyPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 JoyMovePosition = eventData.position;
        Vector2 temp = JoyMovePosition - JoyPosition;
        if(Vector2.Distance(JoyMovePosition, JoyPosition) >= 20f) {
            direction = temp.normalized;
        } else {
            direction = Vector2.zero;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        direction = Vector2.zero;
        isDrag = false;
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public enum JoyStickDirection { Horizontal, Vertical, Both}
public class FloatingJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform background;
    public JoyStickDirection JoyStickDirection  = JoyStickDirection.Both;
    public RectTransform handler;
    private Vector2 input = Vector2.zero;
    [Range(0,2f)] public float handleLimit;

    public float Vertical {get {return input.y;}}
    public float Horizontal {get {return input.x;}}

    Vector2 JoyPosition = Vector2.zero;

    public void OnPointerDown(PointerEventData eventData)
    {
        background.gameObject.SetActive(true);
        OnDrag(eventData);
        JoyPosition = eventData.position;
        background.position = eventData.position;
        handler.anchoredPosition = Vector2.zero;
        Debug.Log("OnPointerDown");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 JoyDriection = eventData.position - JoyPosition;
        input = (JoyDriection.magnitude > background.sizeDelta.x/2f)? JoyDriection.normalized:JoyDriection/(background.sizeDelta.x/2f);
        handler.anchoredPosition = (input*background.sizeDelta.x/2f)*handleLimit;

        if (JoyStickDirection == JoyStickDirection.Horizontal)
            input = new Vector2 (input.x, 0f);
        if (JoyStickDirection == JoyStickDirection.Vertical)
            input = new Vector2(0f, input.y);
            Debug.Log(input);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        input = Vector2.zero;
        handler.anchoredPosition = Vector2.zero;
        Debug.Log("OnPointerUp");
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick: MonoBehaviour, IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    [SerializeField]private RectTransform handle;
    [SerializeField]private float radius=100f;
    public Vector2 Direction{get; private set;}
    public void OnDrag(PointerEventData eventData){
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform,eventData.position,eventData.pressEventCamera,
        out pos);
        pos=Vector2.ClampMagnitude(pos,radius);
        handle.localPosition=pos;
        Direction=pos/radius;
    }
    public void OnPointerDown(PointerEventData eventData){
        OnDrag(eventData);
    }
    public void OnPointerUp(PointerEventData eventData){
        handle.localPosition=Vector2.zero;
        Direction=Vector2.zero;
    }
}
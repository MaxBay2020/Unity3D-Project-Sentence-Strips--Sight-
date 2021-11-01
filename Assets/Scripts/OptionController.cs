using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionController : MonoBehaviour, IDragHandler
{
    private Vector3 screenPosition;
    private Vector3 mousePositionOnScreen;
    private Vector3 mousePositionInWorld;

    public void OnDrag(PointerEventData eventData)
    {
        screenPosition = Camera.main.WorldToScreenPoint(this.transform.position);

        mousePositionOnScreen = Input.mousePosition;

        mousePositionOnScreen.z = screenPosition.z;
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);

        transform.position = mousePositionInWorld;

    }
}

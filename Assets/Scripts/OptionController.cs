using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionController : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    private Vector3 screenPosition;
    private Vector3 mousePositionOnScreen;
    private Vector3 mousePositionInWorld;

    public AudioClip wordClip, wordWithSentenceClip;

    public void OnDrag(PointerEventData eventData)
    {
        screenPosition = Camera.main.WorldToScreenPoint(this.transform.position);

        mousePositionOnScreen = Input.mousePosition;

        mousePositionOnScreen.z = screenPosition.z;
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);

        transform.position = mousePositionInWorld;
    }



    public void WholeSentencePlay()
    {
        SoundManager._instance.PlayTargetAudioClip(wordWithSentenceClip);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager._instance.PlayTargetAudioClip(wordClip);
        }
    }
}

using Choi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Sticker : MonoBehaviour, IPointerClickHandler, IDragHandler, IDropHandler
{

    public bool attach;

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        /*
        if (eventData.pointerEnter.gameObject.GetComponent<Piece>(). == gameObject)
        {
            eventData.pointerEnter.gameObject.transform.position = transform.position;
        }
        */
    }
}

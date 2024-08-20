using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Choi
{
    public class Piece : MonoBehaviour, IDropHandler
    {
        public GameObject target;
        
        public void OnDrop(PointerEventData eventData)
        {
            if(eventData.pointerEnter.gameObject == target)
            {
                eventData.pointerEnter.gameObject.transform.position = transform.position;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace User257
{
    public class WheelResizer3D : MonoBehaviour
    {
        public bool doResize;
        float wheelAmount;

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log($"resizable object {gameObject.name} is clicked");
                    doResize = true;
                }
            }

            OnResize();
        }

        void OnResize()
        {
            if (!doResize)
                return;

            if (wheelAmount > 0)
                Debug.Log($"make {gameObject.name} bigger");
            else if (wheelAmount < 0)
                Debug.Log($"make {gameObject.name} smaller");

            wheelAmount = Input.GetAxis("Mouse ScrollWheel");

            transform.localScale = transform.localScale * (wheelAmount + 1f);
        }
    }
}

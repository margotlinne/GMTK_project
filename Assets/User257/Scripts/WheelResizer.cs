using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace User257
{
    [RequireComponent(typeof(Selecter))]
    public class WheelResizer : MonoBehaviour
    {
        Selecter selectable;

        bool doResize;
        float wheelAmount;


        private void Awake()
        {
            selectable = GetComponent<Selecter>();
            selectable.OnSelected += DoResize;
        }

        void OnDisable()
        {
            selectable.OnSelected -= DoResize;
        }

        void DoResize(bool doResize)
        {
            this.doResize = doResize;
        }

        private void Update()
        {
            OnResize();
        }

        void OnResize()
        {
            if (!doResize)
                return;

            wheelAmount = Input.GetAxis("Mouse ScrollWheel");

            transform.localScale = transform.localScale * (wheelAmount + 1f);
        }
    }
}

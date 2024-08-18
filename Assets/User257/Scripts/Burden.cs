using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace User257
{
    [RequireComponent(typeof(WheelResizer))]
    public class Burden : MonoBehaviour
    {
        public UnityAction OnDisappear;

        private void Update()
        {
            CompareScale();
        }

        void CompareScale()
        {
            if (transform.localScale.x < 0.1f)
            {
                OnDisappear?.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace User257
{
    [RequireComponent(typeof(Selecter))]
    [RequireComponent(typeof(MouseProtractor))]
    public class Knob : MonoBehaviour
    {
        public bool usingKnob;

        Selecter selecter;
        MouseProtractor mouseProtractor;

        public Transform sandParent;

        List<Transform> sands = new List<Transform>();

        float curScale = 1f;

        [SerializeField] float scaleAmount = 1f;

        private void Awake()
        {
            mouseProtractor = GetComponent<MouseProtractor>();

            selecter = GetComponent<Selecter>();
            selecter.OnSelected += UsingKnob;

            for (int i = 0; i < sandParent.childCount; i++)
            {
                sands.Add(sandParent.GetChild(i));
            }
        }

        void UsingKnob(bool isSelected)
        {
            if (isSelected)
            {
                usingKnob = true;
            }
        }

        void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                usingKnob = false;
            }

            if (usingKnob)
                RotateKnob();
        }

        void RotateKnob()
        {
            Vector2 angle = mouseProtractor.GetAngle();

            if (angle.y < -0.5f)
                return; 

            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + angle.x * -120f);

            ChangeSandScale();
        }

        void ChangeSandScale()
        {
            curScale = -transform.rotation.z * scaleAmount + 1f;

            foreach (Transform element in sands)
                element.localScale = new Vector3(curScale, curScale, curScale);
        }
    }
}

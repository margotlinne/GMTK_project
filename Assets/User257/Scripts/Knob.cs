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

        private void Awake()
        {
            mouseProtractor = GetComponent<MouseProtractor>();

            selecter = GetComponent<Selecter>();
            selecter.OnSelected += UsingKnob;
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
        }
    }
}

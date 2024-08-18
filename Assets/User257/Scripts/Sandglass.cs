using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace User257
{
    public class Sandglass : MonoBehaviour
    {
        [SerializeField] Knob knob;
        [SerializeField] SpriteRenderer knobLight;
        [SerializeField] TMP_Text temp;

        public Transform sandParent;

        List<Transform> sands = new List<Transform>();

        float curScale = 1f;

        [SerializeField] float scaleAmount = 1f;

        private void Awake()
        {
            for (int i = 0; i < sandParent.childCount; i++)
            {
                sands.Add(sandParent.GetChild(i));
            }

            knobLight.color = Color.red;
            temp.text = "unhappy";
        }

        private void Update()
        {
            if (knob.usingKnob)
            {
                ChangeSandScale();
                ChangeEmotion();
            }
        }

        void ChangeSandScale()
        {
            curScale = -knob.gameObject.transform.rotation.z * scaleAmount + 1f;

            foreach (Transform element in sands)
                element.localScale = new Vector3(curScale, curScale, curScale);
        }

        void ChangeEmotion()
        {
            if (knob.transform.rotation.z >= 0.3f && knob.transform.rotation.z <= 0.4f)
            {
                knobLight.color = Color.green;
                temp.text = "happy";
            }
            else
            {
                knobLight.color = Color.red;
                temp.text = "unhappy";
            }
        }
    }

}
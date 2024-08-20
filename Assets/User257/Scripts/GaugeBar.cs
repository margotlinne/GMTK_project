using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace User257
{
    public class GaugeBar : MonoBehaviour
    {
        [SerializeField] GameObject gauge1;
        [SerializeField] GameObject gauge2;
        [SerializeField] GameObject gauge3;

        [SerializeField] Sandglass sandglass;

        private void Start()
        {
            DisActiveGauge();

            sandglass.OnChangeRound += Fill;
        }

        void Fill(int stage)
        {
            DisActiveGauge();

            switch (stage)
            {
                case 1:
                    gauge1.SetActive(true);
                    break;
                case 2:
                    gauge2.SetActive(true);
                    break;
                case 3:
                    gauge3.SetActive(true);
                    break;
            }
        }

        void DisActiveGauge()
        {
            gauge1.SetActive(false);
            gauge2.SetActive(false);
            gauge3.SetActive(false);
        }
    }
}

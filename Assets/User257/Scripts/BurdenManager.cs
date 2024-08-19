using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace User257
{
    public class BurdenManager : MonoBehaviour
    {
        [SerializeField] List<Burden> burdens = new List<Burden>();

        int burdenAmount;

        [SerializeField] TMP_Text clear;

        private void Awake()
        {
            burdenAmount = burdens.Count;

            foreach (Burden element in burdens)
                element.OnDisappear += Discount;

            clear.gameObject.SetActive(false);
        }

        void Discount()
        {
            burdenAmount--;

            if (burdenAmount <= 0)
                GameClear();

        }

        public void GameClear()
        {
            clear.gameObject.SetActive(true);
        }
    }
}

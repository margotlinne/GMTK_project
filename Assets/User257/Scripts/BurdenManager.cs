using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace User257
{
    public class BurdenManager : MonoBehaviour
    {
        [SerializeField] List<Burden> burdens = new List<Burden>();

        [SerializeField] GameObject face_bad;
        [SerializeField] GameObject face_soso;
        [SerializeField] GameObject face_normal;

        int burdenAmount;

        private void Awake()
        {
            burdenAmount = burdens.Count;

            foreach (Burden element in burdens)
                element.OnDisappear += Discount;
        }

        private void Start()
        {
            DisactiveFace();
            face_bad.SetActive(true);
        }

        void Discount()
        {
            burdenAmount--;

            DisactiveFace();

            switch (burdenAmount)
            {
                case 3:
                    face_bad.SetActive(true);
                    break;
                case 2:
                case 1:
                    face_soso.SetActive(true);
                    break;
                case 0:
                    face_normal.SetActive(true);
                    break;
            }

            if (burdenAmount <= 0)
                GameClear();
        }

        public void GameClear()
        {
            SceneManager.LoadScene("Stage_3_3");
        }

        void DisactiveFace()
        {
            face_bad.SetActive(false);
            face_soso.SetActive(false);
            face_normal.SetActive(false);
        }
    }
}

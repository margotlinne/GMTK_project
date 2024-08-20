using Marogt;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Margot
{
    public class StageTwoManager : MonoBehaviour
    {
        public bool pickedUpPhone = false;
        public bool showBox = false;
        public bool interacted = false;
        public bool volumeToZero = false;
        public bool freeze = false;

        public Transform[] positiveBoxPos;
        public Transform[] negativeBoxPos;

        public GameObject phoneObj;
        public GameObject boxObj;

        [HideInInspector]
        public string interactKey;

        Coroutine phone;

        public GameObject InteractUICanavs;

        public float distanceToDetect = 5f;
        public int volumeLevel = 0;

        public GameObject shockWaveObj;
        [HideInInspector]
        public ShockWave shockWave;

        void Awake()
        {
            shockWave = shockWaveObj.GetComponent<ShockWave>();
        }


        void Start()
        {
            boxObj.SetActive(false);
            InteractUICanavs.SetActive(false);

            // i=0�� ���� ���� �� ó�� �ڵ������� ��ȣ�ۿ����� ����
            for (int i = 1; i < positiveBoxPos.Length; i++)
            {
                positiveBoxPos[i].GetComponentInChildren<InteractLight>().order = i;
                positiveBoxPos[i].GetComponentInChildren<InteractLight>().isPositive = true;
            }

            //for (int i = 0; i < negativeBoxPos.Length; i++)
            //{
            //    negativeBoxPos[i].GetComponentInChildren<InteractLight>().order = i;
            //    negativeBoxPos[i].GetComponentInChildren<InteractLight>().isPositive = false;
            //}
        }

        void Update()
        {
            if (!pickedUpPhone)
            {
                if (!showBox && phone == null)
                {
                    phone = StartCoroutine(ReadyToStart());
                }
                else if (showBox)
                {
                    boxObj.transform.position = positiveBoxPos[0].position;
                    boxObj.SetActive(true);
                    interactKey = "E";

                    if (interacted)
                    {
                        Destroy(phoneObj);
                        pickedUpPhone = true;
                        HideInteractBox();
                        interacted = false;
                    }
                }
            }

            if (showBox)
            {
                if (interacted)
                {
                    HideInteractBox();
                }
            }


            if (!freeze)
            {
                shockWave.BackToPlayer();
            }
        }

        public void ShockWaveForInteraction(int order)
        {
            //Debug.Log("call shock wave for interaction");
            shockWaveObj.transform.position = positiveBoxPos[order].position;
            shockWave.CallShockWave();
        }

        IEnumerator ReadyToStart()
        {
            yield return new WaitForSeconds(2f);

            Debug.Log("waited");
            showBox = true;
        }

        public void ShowInteractBox(int num, string keyCode)
        {
           // Debug.Log("_------------------" + keyCode);
            showBox = true;

            boxObj.transform.position = positiveBoxPos[num].position;
            boxObj.SetActive(true);
            interactKey = keyCode;
            //interacted = false;
        }

        public void HideInteractBox()
        {
            ///Debug.Log("HideInteractBox called"); 
            boxObj.GetComponent<InteractionBox>().Disappearing();
            InteractUICanavs.SetActive(true);
            showBox = false;
        }
    }
}

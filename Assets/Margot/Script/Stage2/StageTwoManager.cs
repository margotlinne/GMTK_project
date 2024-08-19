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

        public Transform[] boxPos;
        public GameObject phoneObj;
        public GameObject boxObj;

        [HideInInspector]
        public string interactKey;

        Coroutine phone;

        public GameObject InteractUICanavs;

        public float distanceToDetect = 0f;

        void Start()
        {
            boxObj.SetActive(false);
            InteractUICanavs.SetActive(false);

            // i=0은 게임 시작 시 처음 핸드폰과의 상호작용으로 제외
            for (int i = 1; i < boxPos.Length; i++)
            {
                boxPos[i].GetComponentInChildren<InteractLight>().order = i;
            }
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
                    boxObj.transform.position = boxPos[0].position;
                    boxObj.SetActive(true);
                    interactKey = "E";

                    if (interacted)
                    {
                        Destroy(phoneObj);
                        pickedUpPhone = true;
                        HideInteractBox();
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
        }

        IEnumerator ReadyToStart()
        {
            yield return new WaitForSeconds(2f);

            Debug.Log("waited");
            showBox = true;
        }

        public void ShowInteractBox(int num, string keyCode)
        {
            showBox = true;

            boxObj.transform.position = boxPos[num].position;
            boxObj.SetActive(true);
            interactKey = keyCode;
        }

        public void HideInteractBox()
        {
            Debug.Log("HideInteractBox called"); // Debug 로그 추가
            boxObj.GetComponent<InteractionBox>().Disappearing();
            InteractUICanavs.SetActive(true);
            showBox = false;
            interacted = false;
        }
    }
}

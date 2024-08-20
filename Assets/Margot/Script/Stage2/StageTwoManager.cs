using Marogt;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

namespace Margot
{
    public class StageTwoManager : MonoBehaviour
    {
        public bool pickedUpPhone = false;
        public bool showBox = false;
        public bool interacted = false;
        public bool volumeToZero = false;
        public bool freeze = false;
        public bool withNegativeLight = false;
        public bool interactingWNegativeLight = false;
        public bool hideInteractions = false;

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

        public int interactedNum = 0;

        public Light2D bgLight;

        public float brightnessUpStrength = 5f;

        public Image warningBG;
        // -------------------------------------------------------------------->>>>>>
        public int finishedNegativeNum = 0;
        public int finishedPositiveNum = 0;
        public bool stageClear = false;
        public GameObject UIPhoneImg;
        // -------------------------------------------------------------------->>>>>>



        
        void Awake()
        {
            shockWave = shockWaveObj.GetComponent<ShockWave>();
        }


        void Start()
        {
            boxObj.SetActive(false);
            InteractUICanavs.SetActive(false);

            for (int i = 1; i < positiveBoxPos.Length; i++)
            {
                positiveBoxPos[i].GetComponentInChildren<InteractLight>().order = i;
                positiveBoxPos[i].GetComponentInChildren<InteractLight>().isPositive = true;
            }

            for (int i = 0; i < negativeBoxPos.Length; i++)
            {
                negativeBoxPos[i].GetComponentInChildren<InteractLight>().order = i;
                negativeBoxPos[i].GetComponentInChildren<InteractLight>().isPositive = false;
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
                    boxObj.transform.position = positiveBoxPos[0].position;
                    boxObj.SetActive(true);
                    interactKey = "E";

                    if (interacted)
                    {
                        Destroy(phoneObj);
                        SfxManager.instance.PhoneGrabSoundPlay();
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

            if (warningBG.color.a > 0)
            {
                interactingWNegativeLight = true;
            }
            else if (warningBG.color.a == 0)
            {
                interactingWNegativeLight = false;
            }

            // -------------------------------------------------------------------->>>>>>
            if (finishedNegativeNum == negativeBoxPos.Length && finishedPositiveNum == positiveBoxPos.Length-1)
            {
                stageClear = true;
                UIPhoneImg.SetActive(false);
            }
            // -------------------------------------------------------------------->>>>>>


            if (hideInteractions)
            {
                for (int i = 0; i < positiveBoxPos.Length; i++)
                {
                    positiveBoxPos[i].gameObject.SetActive(false);
                }
            }
        }

        public void AdjustWarningBGColour(float val, bool isIncreasing)
        {
            // 알파 값이 0이었기 때문에 (아래 배경 빛 조정 때와 마찬가지) 아무 변화 없는것처럼 보였던 것
            // 곱셈에서 덧셈으로 바꿈
            Color newColor = warningBG.color;
            if (isIncreasing)
            {
                newColor.a += val;
            }
            else
            {
                newColor.a -= val;
            }
            warningBG.color = newColor;
        }


        public void IncreaseBGLight()
        {
            Color lightColor = bgLight.color;
            lightColor.r *= brightnessUpStrength;
            lightColor.g *= brightnessUpStrength;
            lightColor.b *= brightnessUpStrength;
            bgLight.color = lightColor;
        }

        public void ShockWaveForInteraction(int order)
        {
            SfxManager.instance.ShockwaveNegSoundPlay();
           // Debug.Log("call shock wave for interaction" + order);
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

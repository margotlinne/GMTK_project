using Margot;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Marogt
{
    public class InteractLight : MonoBehaviour
    {
        public GameObject player;
        public StageTwoManager manager;
        public ShowUpMoments momentImg;

        public bool isDetectable = false;
        public bool isPositive = false;
        public bool isInteracted = false;
        public bool deleteLight = false;


        bool isFinished = false;

        Light2D soundLight;
        Coroutine adjustLight;

        public int order = 0;

        Coroutine adjustLightCoroutine;

        [SerializeField]
        float distance = 0f;

        private float targetLightSize = 0f;
        private float lightChangeDuration = 1f; // Duration for changing light size


        void Awake()
        {
            soundLight = GetComponent<Light2D>();
        }

        void Update()
        {
            distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
            bool currentlyDetectable = distance <= manager.distanceToDetect;

            if (!isFinished)
            {
                if (currentlyDetectable != isDetectable)
                {
                    isDetectable = currentlyDetectable;

                    // Update target light size based on detectability
                    targetLightSize = isDetectable ? manager.volumeLevel * 1.5f : 0f;

                    // Stop any existing coroutine and start a new one to adjust light size
                    if (adjustLightCoroutine != null)
                    {
                        StopCoroutine(adjustLightCoroutine);
                    }
                    adjustLightCoroutine = StartCoroutine(AdjustLight(targetLightSize));
                }
                else if (isDetectable)
                {
                    // Update target light size when detectable but no change in detectability

                    targetLightSize = manager.volumeLevel * 1.5f;

                    // Continue adjusting light size to the updated target value
                    if (adjustLightCoroutine != null)
                    {
                        StopCoroutine(adjustLightCoroutine);
                    }
                    adjustLightCoroutine = StartCoroutine(AdjustLight(targetLightSize));
                }

                // 부정적 소리의 스크립트에서 거리가 멀 때 키박스를 감추게 해서 계속 사라졌다 떴다 하는 오류가 떴던 것
                if (isDetectable && manager.pickedUpPhone && isPositive)
                {
                    if (distance <= 3 && manager.volumeLevel == 5)
                    {
                         Debug.Log(order + " time to show box");
                        manager.ShowInteractBox(order, "E");
                    }
                    else
                    {
                        Debug.Log("hide");
                        manager.HideInteractBox();
                    }
                }
                else if (!isDetectable && manager.pickedUpPhone && isPositive)
                {
                    //Debug.Log("hide");
                    manager.HideInteractBox();
                }

                if (isDetectable && !isPositive && !isFinished)
                {
                    manager.withNegativeLight = true;
                }
                else if ((!isDetectable && !isPositive) || (isPositive && isDetectable))
                {
                    manager.withNegativeLight = false;
                }


            }
            
            // positive light --------------------

            if (isPositive && manager.interacted && !isFinished)
            {
                adjustLightCoroutine = StartCoroutine(AdjustLight(0f));
                manager.ShockWaveForInteraction(order);
                isInteracted = true;
                isFinished = true;
                manager.interacted = false;
                manager.volumeLevel = 0;
                manager.interactedNum++;
                manager.IncreaseBGLight();
                manager.volumeToZero = true;
                manager.freeze = true;
            }

            if (isFinished && manager.freeze && isPositive)
            {
                momentImg.ShowingUpMoment();
            }


            // negative light ---------------------
            // 플레이어가 부정적 빛과 상호작용하고 있으며 해당 빛이 감지 가능한 거리에 있을 때 즉 해당 빛과 상호작용 중일 때
            if (!isPositive && manager.interactingWNegativeLight && isDetectable)
            {
                deleteLight = true;
            }

            if (deleteLight)
            {
                // 상호작용 후에 붉은 배경이 원래대로 돌아왔다면 부정적 상호작용이 끝난 상태
                if (manager.warningBG.color.a == 0)
                {
                    isFinished = true;
                    manager.withNegativeLight = false;
                }
            }


        }

        IEnumerator AdjustLight(float target)
        {
            float initialLightSize = soundLight.pointLightOuterRadius;
            float currentTime = 0f;

            while (currentTime < lightChangeDuration)
            {
                currentTime += Time.deltaTime;
                float progress = Mathf.Clamp01(currentTime / lightChangeDuration);
                soundLight.pointLightOuterRadius = Mathf.Lerp(initialLightSize, target, progress);
                yield return null;
            }

            // Ensure final target value is set
            soundLight.pointLightOuterRadius = target;
        }

    }
}
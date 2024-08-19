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
        public bool isFinished = false;

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

                if (isDetectable && manager.pickedUpPhone)
                {
                    if (distance <= 3 && manager.volumeLevel == 5 && isPositive)
                    {
                        // Debug.Log(order + " time to show box");
                        manager.ShowInteractBox(order, "E");
                    }
                    else
                    {
                        //Debug.Log("hide");
                        manager.HideInteractBox();
                    }
                }
                else if (!isDetectable && manager.pickedUpPhone)
                {
                    //Debug.Log("hide");
                    manager.HideInteractBox();
                }
            }
            


            if (isPositive && manager.interacted && !isFinished)
            {
                adjustLightCoroutine = StartCoroutine(AdjustLight(0f));
                manager.ShockWaveForInteraction(order);
                isInteracted = true;
                isFinished = true;
                manager.interacted = false;
                manager.volumeLevel = 0;
                manager.volumeToZero = true;
                manager.freeze = true;
            }

            if (isFinished && manager.freeze)
            {
                momentImg.ShowingUpMoment();
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
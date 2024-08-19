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

        public bool isDetectable = false;

        Light2D soundLight;
        Coroutine adjustLight;

        public int order = 0;

        [SerializeField]
        float distance = 0f;

        void Awake()
        {
            soundLight = GetComponent<Light2D>();
        }

        void Update()
        {
            distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
            bool currentlyDetectable = distance <= manager.distanceToDetect;

            if (currentlyDetectable != isDetectable)
            {
                isDetectable = currentlyDetectable;

                if (adjustLight != null)
                {
                    StopCoroutine(adjustLight); // 이미 실행 중인 코루틴이 있으면 중지
                }

                if (isDetectable)
                {
                    adjustLight = StartCoroutine(AdjustLight(1f)); // 목표 값을 1f로 설정하여 조명 크기를 조정                    
                }
                else
                {                   
                    adjustLight = StartCoroutine(AdjustLight(0f)); // 목표 값을 0f로 설정하여 조명 크기를 조정
                }
            }


            /* 빛은 코루틴을 사용해서 점진적으로 밝아지고 어두워지기에 한 번만 실행해줬어야 했는데(위의 if문)
               상호작용 박스의 경우 가까워질 때마다 보여야 하기 때문에 밑에처럼 빼줌
             */

            if (isDetectable && manager.pickedUpPhone)
            {
                if (distance <= 3)
                {
                    Debug.Log(order + "time to show box");
                    manager.ShowInteractBox(order, "E");
                }
                else
                {
                    Debug.Log("hide");
                    manager.HideInteractBox();
                }
            }
            else if (!isDetectable && manager.pickedUpPhone) 
            {
                Debug.Log("hide");
                manager.HideInteractBox();
            }
        }

        IEnumerator AdjustLight(float target)
        {
            float initialLightSize = soundLight.pointLightOuterRadius;
            float currentTime = 0.0f;
            float time = 1f;

            while (currentTime <= time)
            {
                // 스케일을 점진적으로 변경
                soundLight.pointLightOuterRadius = Mathf.Lerp(initialLightSize, target, currentTime / time);
                currentTime += Time.deltaTime; // 경과 시간 증가
                yield return null; // 다음 프레임까지 대기
            }

            soundLight.pointLightOuterRadius = target; // 최종적으로 목표 스케일에 맞춤
        }
    }
}

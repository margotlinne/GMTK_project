using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Margot
{
    public class SwingLight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Image lightImg;

        Vector3 lightScale_org = new Vector3 (1f, 1f, 1f);

        [SerializeField]
        bool readyToHover = false;
        [SerializeField]
        bool isHover = false;
        [SerializeField]
        bool isSwinging = false;
        bool brightnessChange = false;

        float currentTime = 0f;
        float duration = 1f;

        Animator anim;

        Coroutine wait;
        Coroutine light;

        void Awake()
        {
            anim = GetComponent<Animator>();
        }

        void Start()
        {
            readyToHover = true;
            lightScale_org = lightImg.transform.localScale;
        }

        void Update()
        {
            if (isHover && !isSwinging)
            {
                anim.SetTrigger("Swing");

                isSwinging = true;
                light = StartCoroutine(ScaleOverTime(duration, new Vector3(0.8f, 0.8f, 0.8f)));

                Debug.Log("swing starts");
            }

        }


        public void BackToIdle()
        {
            Debug.Log("back to idle");
            isSwinging = false;

            wait = StartCoroutine(WaitForNextHover(1f));
            light = StartCoroutine(ScaleOverTime(duration, lightScale_org));
        }


        public void OnPointerEnter(PointerEventData eventData)
        {
            if (readyToHover)
            {
                isHover = true;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isHover = false;
        }


        IEnumerator WaitForNextHover(float second)
        {
            readyToHover = false;

            yield return new WaitForSeconds(second);

            Debug.Log("watied");
            readyToHover = true;

            StopCoroutine(wait);
        }

        IEnumerator ScaleOverTime(float time, Vector3 targetScale)
        {
            float currentTime = 0.0f; 

            while (currentTime <= time)
            {
                // 스케일을 점진적으로 변경
                lightImg.transform.localScale = Vector3.Lerp(lightImg.transform.localScale, targetScale, currentTime / time);
                currentTime += Time.deltaTime; // 경과 시간 증가
                yield return null; // 다음 프레임까지 대기
            }

            lightImg.transform.localScale = targetScale; // 최종적으로 목표 스케일에 맞춤

            StopCoroutine(light);
        }

    }

}

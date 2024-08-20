using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Margot
{
    public class Ending : MonoBehaviour
    {
        Animator anim;

        public StageTwoManager manager;

        public SpriteRenderer BGClassRoom1;
        public SpriteRenderer BGClassRoom2;

        public Light2D DarkLight;

        public GameObject friendsSilhouette;
        public GameObject playerLight;
        
        

        void Awake()
        {
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            if (manager.stageClear)
            {
                anim.SetTrigger("Start");
            }
        }

        public void SetEnvironment()
        {

            // 뒷 배경색 밝게 변화

            Color newColor = BGClassRoom1.color;
            newColor.r = 1;
            newColor.g = 1;
            newColor.b = 1;

            BGClassRoom1.color = newColor;
            BGClassRoom2.color = newColor;


            // 어두운 불 밝혀주기
            DarkLight.color = newColor;

            // 친구들 실루엣 보여주기
            friendsSilhouette.SetActive(true);

            // 플레이어 주변 빛 비활성화 및 웃음 활성화
            playerLight.SetActive(false);

            // 시각화된 긍정적 상호작용 비활성화
            manager.hideInteractions = true;

        }


        public void ToNextStage()
        {
            // 다음 씬으로
        }
    }

}

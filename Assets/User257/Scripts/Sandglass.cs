using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace User257
{
    public class Sandglass : MonoBehaviour
    {
        [SerializeField] Knob knob;
        [SerializeField] SpriteRenderer knobLight;
        [SerializeField] GameObject face_good;
        [SerializeField] GameObject face_normal;

        public float minSize = 0.1f;
        public float maxSize = 2f;

        public Transform sandParent;

        List<Transform> sands = new List<Transform>();

        float curScale = 1f;

        [SerializeField] float scaleAmount = 1f;

        int curRound = 0;
        int wholeRound = 3;

        /// <summary>
        /// 다이얼 로테이션 타이밍
        /// </summary>
        [SerializeField] float[] timing;

        public UnityAction<int> OnChangeRound;

        [SerializeField] GameObject light_sandglass;

        private void Awake()
        {
            for (int i = 0; i < sandParent.childCount; i++)
            {
                sands.Add(sandParent.GetChild(i));
            }

            knobLight.color = Color.red;

            face_normal.SetActive(true);
            face_good.SetActive(false);

            light_sandglass.SetActive(false);
        }

        private void Start()
        {
            knob.OnMouseUp += CheckClear;
        }

        private void OnDisable()
        {
            knob.OnMouseUp -= CheckClear;
        }

        private void Update()
        {
            if (knob.usingKnob)
            {
                ChangeSandScale();
                ChangeEmotion();
            }

            CheckFail();
        }

        void ChangeSandScale()
        {
            curScale += -knob.gameObject.transform.rotation.z * scaleAmount;
            
            switch (curRound)
            {
                case 0:
                    curScale = Mathf.Clamp(curScale, minSize, 1);
                    break;
                case 1:
                    curScale = Mathf.Clamp(curScale, 1, maxSize);
                    break;
                case 2:
                    curScale = Mathf.Clamp(curScale, minSize, maxSize);
                    break;
            }

            foreach (Transform element in sands)
                element.localScale = new Vector3(curScale, curScale, curScale);
        }

        void ChangeEmotion()
        {
            if (knob.transform.rotation.z >= timing[curRound] && knob.transform.rotation.z <= timing[curRound] + 0.1f) //0.1f 정도의 허용범위
            {
                knobLight.color = Color.green;
                face_normal.SetActive(false);
                face_good.SetActive(true);
            }
            else
            {
                knobLight.color = Color.red;
            }
        }

        void CheckClear()
        {
            if (knob.transform.rotation.z >= timing[curRound] && knob.transform.rotation.z <= timing[curRound] + 0.1f)
            {
                curRound++;
                OnChangeRound?.Invoke(curRound);

                knobLight.color = Color.red;

                face_normal.SetActive(true);
                face_good.SetActive(false);
            }
            else
                Restart();

            if (curRound == wholeRound)
            {
                face_normal.SetActive(false);
                face_good.SetActive(true);


                light_sandglass.SetActive(true);

                Debug.Log("Clear");
            }
        }

        void Restart()
        {
            SceneManager.LoadScene("Stage_3_4"); //실패하면 씬 재시작
        }

        void CheckFail()
        {
            if (sands[0].transform.localScale.x <= minSize || sands[0].transform.localScale.x >= maxSize)
                Restart();
        }
    }

}
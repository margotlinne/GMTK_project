using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace User257
{
    public class Stage : MonoBehaviour
    {
        [SerializeField] GameObject off;
        [SerializeField] GameObject on;

        [SerializeField] GameManager.Stage myStage;

        private void Start()
        {
            if (GameManager.Instance.GetStageClear(myStage))
            {
                on.SetActive(true);
                off.SetActive(false);
            }
            else
            {
                on.SetActive(false);
                off.SetActive(true);
            }
        }

    }
}

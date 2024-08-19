using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace User257
{
    [RequireComponent(typeof(Selecter))]
    public class Seat : MonoBehaviour
    {
        Selecter selecter;

        private void Awake()
        {
            selecter = GetComponent<Selecter>();
            selecter.OnSelected += ChangeScene;
        }

        void ChangeScene(bool isSelected)
        {
            if (isSelected)
                SceneManager.LoadScene("Stage_3_Burden");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace User257
{
    [RequireComponent(typeof(Selecter))]
    public class SceneChangeButton : MonoBehaviour
    {
        Selecter selecter;
        [SerializeField] string sceneName;

        private void Awake()
        {
            selecter = GetComponent<Selecter>();
            selecter.OnSelected += ChangeScene;
        }

        void ChangeScene(bool isSelected)
        {
            if (isSelected)
                SceneManager.LoadScene(sceneName);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Margot
{
    public class StartGame : MonoBehaviour
    {
        public void StartGameBtn()
        {
            // 스테이지 씬 명 추가
            SceneManager.LoadScene("");
        }
    }
}


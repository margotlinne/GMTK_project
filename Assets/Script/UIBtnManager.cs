using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIBtnManager : MonoBehaviour
{
    public void GoToMenu()
    {
        GameManager.Instance.ChangeScene("MainMenu");
    }

    public void GoToStageSelection()
    {
        GameManager.Instance.ChangeScene("StageSelection_User257");
    }

    public void Replay()
    {
        GameManager.Instance.ChangeScene(SceneManager.GetActiveScene().name);
    }
}

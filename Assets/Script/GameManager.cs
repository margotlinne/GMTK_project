using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public enum Stage { None, Child, Student, Adult, Grandpa }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /* Get int 했을 때 0이면 clear 아직 안 됨, 1이면 clear 되어있음 */

    /// <summary>
    /// 각 스테이지 마지막에 넣어주세요
    /// </summary>
    /// <param name="stage"></param>
    public void SetStageClear(Stage stage)
    {
        PlayerPrefs.SetInt(stage.ToString(), 1);
    }

    public bool GetStageClear(Stage stage)
    {
        if (PlayerPrefs.GetInt(stage.ToString()) == 0)
            return false;
        else
            return true;
    }
}

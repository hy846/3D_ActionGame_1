using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    //シーンを変える関数
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

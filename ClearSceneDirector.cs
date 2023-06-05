using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearSceneDirector : MonoBehaviour
{
    void Update()
    {
        //クリックされたらメニューに戻る
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}

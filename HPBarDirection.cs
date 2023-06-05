using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarDirection : MonoBehaviour
{
    public Canvas canvas;

    void Start()
    {
        Application.targetFrameRate = 60;
    }
    
    void Update()
    {
        //敵のＨPバーを操作キャラのほうに向かせる
        canvas.transform.rotation = Camera.main.transform.rotation;
    }
}

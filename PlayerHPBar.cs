using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHPBar : MonoBehaviour
{
    int maxHp = 100;
    int currentHp;
    public Slider slider;

    void Start()
    {
        Application.targetFrameRate = 60;
        slider.value = 1;
        currentHp = maxHp;
    }

    //敵の剣が当たったらＨPバーを１減らす。０になったらゲームオーバー
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemySword")
        {
            currentHp -= 1;
            slider.value = (float)currentHp / (float)maxHp;
            if (currentHp == 0)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }
}

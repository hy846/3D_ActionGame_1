using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHPBar : MonoBehaviour
{
    int maxHp = 20;
    int currentHp;
    public Slider slider;
    private GameObject enemy;

    void Start()
    {
        Application.targetFrameRate = 60;
        slider.value = 1;
        currentHp = maxHp;
        enemy = GameObject.Find("Enemy");
    }

    //操作キャラの剣が当たったらＨPバーを１減らす。０になったらゲームクリア
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword" && Input.GetKey(KeyCode.A))
        {
            currentHp -= 1;
            slider.value = (float)currentHp / (float)maxHp;
            if (currentHp == 0)
            {
                Destroy(enemy);
                SceneManager.LoadScene("ClearScene");
            }
        }
    }
}

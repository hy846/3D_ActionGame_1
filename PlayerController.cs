using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;            
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] Animator anim;

    void Start()
    {
        Application.targetFrameRate = 60;
    }
    
    void Update()
    {
        //速度初期化
        velocity = Vector3.zero;

        //前に走る
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            velocity.z += 1;
            anim.SetBool("Run",true);
        }
        
        //前に歩く
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity.z += 1;
            anim.SetBool("Walk",true);
        }

        //後ろに走る
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            velocity.z -= 1;
            anim.SetBool("Run",true);
        }

        //後ろに歩く
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity.z -= 1;
            anim.SetBool("Walk",true);
        }

        //右に走る
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            velocity.x += 1;
            anim.SetBool("Run",true);
        }

        //右に歩く
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity.x += 1;
            anim.SetBool("Walk",true);
        }
        
        //左に走る
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            velocity.x -= 1;
            anim.SetBool("Run",true);
        }
    
        //左に歩く
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity.x -= 1;
            anim.SetBool("Walk",true);
        }

        //矢印キーを離すと歩くアニメーションを止める
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            anim.SetBool("Walk",false);

        //左シフトキーを押すと速くなる
        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = 1.0f;

        //左Shiftキーを離すと走るアニメーションを止める
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("Run",false);
            moveSpeed = 5.0f;
        }

        //速度調整
        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        //その他の操作のアニメーション
        if (Input.GetKey(KeyCode.A))
            anim.SetBool("Attack",true);

        if (Input.GetKeyUp(KeyCode.A))
            anim.SetBool("Attack",false);

        if (Input.GetKey(KeyCode.S))
            anim.SetBool("RollLeft",true);

        if (Input.GetKeyUp(KeyCode.S))
            anim.SetBool("RollLeft",false);

        if (Input.GetKey(KeyCode.X))
            anim.SetBool("RollRight",true);

        if (Input.GetKeyUp(KeyCode.X))
            anim.SetBool("RollRight",false);

        if (Input.GetKey(KeyCode.Space))
            anim.SetBool("Jump",true);

        if (Input.GetKeyUp(KeyCode.Space))
            anim.SetBool("Jump",false);

        //動く方向に向きを変える
        if(velocity.magnitude > 0)
        {   
            transform.rotation = Quaternion.LookRotation(velocity);
            transform.position += velocity;
        }

        //海に落ちたらゲームオーバー
        if (this.transform.position.y < 2.8)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    //敵の剣が当たったらHitアニメーション
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemySword")
        {
            anim.SetTrigger("Hit");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform goal;
    Rigidbody rigid;
    Animator anim;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid = GetComponent<Rigidbody>();
        this.anim = GetComponent<Animator>();
    }

    void Update()
    {
        //操作キャラと敵の距離
        float diff = Vector3.Distance(transform.position, goal.position);

        //距離によって敵の行動を分岐
        if (diff >= 10)
        {
            anim.SetBool("Idle",true);
        }
        else if (diff >= 2 && diff < 10)
        {
            anim.SetBool("Walk",true);
            anim.SetBool("Attack",false);
            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.destination = goal.position;
        }
        else if (diff < 2)
        {
            anim.SetBool("Attack",true);
        }
    }

    //操作キャラの剣が当たったらHitアニメーション
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword" && Input.GetKey(KeyCode.A))
        {
            anim.SetTrigger("Hit");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;          //注視対象プレイヤー
    [SerializeField] private float distance = 3.0f;     //注視対象プレイヤーからカメラを離す距離
    [SerializeField] private Quaternion vRotation;      //カメラの垂直回転
    [SerializeField] public  Quaternion hRotation;      //カメラの水平回転

    void Start()
    {
        Application.targetFrameRate = 60;
        //回転の初期化
        vRotation = Quaternion.Euler(10, 0, 0);         //垂直回転は30度見下ろす回転
        hRotation = Quaternion.Euler(0, 0, 0);          //水平回転は無回転
        transform.rotation = hRotation * vRotation;     //最終的なカメラの回転は垂直回転してから水平回転する合成回転

        //位置の初期化
        //操作キャラの位置から距離だけ手前に引いた位置を設定
        transform.position = player.position - transform.rotation * Vector3.forward * distance; 
    }

    void Update()
    {
        //カメラの位置の更新
        //操作キャラ位置からの距離だけ手前に引いた位置を設定
        transform.position = player.position - transform.rotation * Vector3.forward * distance + new Vector3(0, 1.4f, 0); 
    }

}

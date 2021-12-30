using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl: MonoBehaviour
{
    //刚体
    private Rigidbody rBody;
    //音频组件
    private AudioSource footPlayer;
    //是否在地面
    private bool isGround;

    void start()
    {
        //获取刚体组件
        rBody = GetComponent<Rigidbody>();
        //获取声音组件
        footPlayer  = GetComponent<AudioSource>();
    }

    void update()
    {
        //如果按下空格键且角色在地面上
        if(Input.GetKeyDown(KeyCode.Space)&&isGround == true )
        {
            //跳跃
            rBody.AddForce(Vector3.up * 200);
        }
        float horizontal = Input.GetAxis("Horizontal" );
        float vertical = Input.GetAxis("Vertical" );
        if ((horizontal != 0 || vertical != 0) && isGround == true) 
        {
            //移动且当前未播放
            if(footPlayer .isPlaying == false)
            {
                //播放脚步声
                footPlayer.Play();
            }
        }else
        {
            //没有移动，停止脚步
            footPlayer.Stop();
        }
    }
}

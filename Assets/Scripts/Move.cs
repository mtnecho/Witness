using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //设置默认移动速度
    public float player_speed = 0.5f;
    //设置玩家刚体组件
    private Rigidbody rBody;
    // Start is called before the first frame update
    void Start()
    {
        //初始化玩家刚体组件
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //获取玩家水平移动方向
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //将两个方向合成一个向量 0 
        Vector3 dir = new Vector3(horizontal, 0, vertical);
        if (dir != Vector3.zero)
        {
            //将移动方向传给刚体组件
            rBody.velocity = dir * player_speed;
        }

    }
    
}

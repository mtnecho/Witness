using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject txt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //unity提供的进入触发函数
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //检测到玩家的触发，销毁自身
            Destroy(gameObject);
            txt.SetActive(true);
        }
    }
}

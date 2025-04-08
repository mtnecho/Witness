using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end : MonoBehaviour
{
    //得到文本
    public GameObject txt;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //设置激活
            txt.SetActive(true);
            button.SetActive(true);
            Destroy(gameObject);
        }

    }
}

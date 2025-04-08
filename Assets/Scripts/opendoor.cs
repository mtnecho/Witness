using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour
{
    public GameObject door;
    public Texture2D img;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //当子对象为0时，销毁大门，然后销毁自身
        if (transform.childCount <= 0)
        {
            
            Destroy(door);
            Destroy(gameObject);
        }
    }
}


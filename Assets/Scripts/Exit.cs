using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // 在Unity编辑器中结束运行 
        #else
            Application.Quit(); // 在可执行程序中结束运行 
        #endif
    }
}

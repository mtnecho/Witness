using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AndrolMove : MonoBehaviour
{     
    public Joystick moveJoystick;
    private float moveSpeed = 10f;
    public GameInputActions gameInputActions;
    public Transform targetFollowTransform;
    public Transform cameraTransform;
    //Update生命周期函数
    private void Update()
    {
        getTouchScreenMove();
    }
    private void getTouchScreenMove()
    {
        //使用获取到的虚拟摇杆Joystick的Horizontal和Vertical返回值作为角色移动的参数
        playerMove(moveJoystick.Horizontal, moveJoystick.Vertical);
    }
    //使角色真正移动的方法
    private void playerMove(float horizontal, float vertical)
    {
        transform.Translate(new Vector3(horizontal, 0, vertical) * Time.deltaTime * moveSpeed, Space.World);
    }
    //获取CameraControl输入方法
    private void getCameraControlInput()
    {
        //将读取到的CameraControl返回值赋值给cameraOffset 
        Vector2 cameraOffset = gameInputActions.PC.CameraControl.ReadValue<Vector2>();
        //判断是否有鼠标是否有产生偏移
        if (cameraOffset != Vector2.zero)
        {
            // 	//将获取到的鼠标偏移值打印出来
            cameraTransform.RotateAround(targetFollowTransform.position, Vector3.up, cameraOffset.x);
            cameraTransform.RotateAround(targetFollowTransform.position, cameraTransform.right, -cameraOffset.y);
        }
    }
    //将物体移动方法和视角转动方法都放到该方法内进行统一判定
    private void touchControl()
    {
        //因为在触摸屏上有多点触发的可能性，因此我们需要获取到每个触发点的顺序
        for (int i = 0; i < Input.touchCount; i++)
        {
            //按照触发点的顺序来获取在屏幕上的对应位置进行功能判定
            Vector3 touchPos = Input.GetTouch(i).position;
            //如果触发点在屏幕左半屏即为移动功能触发，我们执行移动方法即可
            if (touchPos.x < Screen.width / 2)
            {
                getTouchScreenMove();
            }
            //如果触发点在屏幕右半屏即为视角转动功能触发，我们执行视角转动方法即可
            if (touchPos.x > Screen.width / 2 && touchPos.y > Screen.height / 2)
            {
                getCameraControlInput();
            }
        }
    }
}
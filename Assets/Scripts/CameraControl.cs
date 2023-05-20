using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera camera;
    public Transform rotateCenter;
    private float slideSpeed = 20;
    private float moveSpeed = 0.1f;
    private float rotateSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        camera.transform.position = new Vector3(0.0f, 0.0f, -2.0f);
        //camera.transform.LookAt(rotateCenter);
    }

    // Update is called once per frame
    void Update()
    {
        ZoomView();
        MoveCamera();
    }

    private void ZoomView()
    {
        //获取虚拟按键(鼠标中轴滚轮)
        float mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");
        //鼠标滑动中键滚轮,实现摄像机的镜头放大和缩放          
        //mouseScrollWheel < 0 = 负数 往后滑动,缩放镜头
        if (mouseScrollWheel < 0)
        {
            //滑动限制
            if (camera.fieldOfView <= 170)
            {
                camera.fieldOfView += 10 * slideSpeed * Time.deltaTime;
                if (camera.fieldOfView >= 170)
                {
                    camera.fieldOfView = 170;
                }

            }
        }
        //mouseScrollWheel >0 = 正数 往前滑动,放大镜头
        else if (mouseScrollWheel > 0)
        {
            //滑动限制     
            if (camera.fieldOfView >= 10)
            {

                camera.fieldOfView -= 10 * slideSpeed * Time.deltaTime;

                if (camera.fieldOfView <= 10)
                {
                    camera.fieldOfView = 10;
                }
            }
        }
    }

    private void MoveCamera()
    {
        float dx = 0;
        float dy = 0;
        float dz = 0;
        if (Input.GetKey(KeyCode.D))
        {
            dx = -moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dx = moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            dy = -moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dy = moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            dz = -moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            dz = moveSpeed * Time.deltaTime;
        }
        camera.transform.Translate(dx, 0, 0, Space.Self);
        camera.transform.Translate(0, dy, 0, Space.Self);
        camera.transform.Translate(0, 0, dz, Space.Self);

        //if (input.getmousebuttondown(1))
        //{
        //    var mouse_x = input.getaxis("mouse x");     // 获取鼠标 x 轴移动
        //    var mouse_y = -input.getaxis("mouse y");    // 获取鼠标 y 轴移动
        //    camera.transform.rotate(mouse_y * rotatespeed, mouse_x * rotatespeed, 0);
        //}

        //var mouse_x = input.getaxis("mouse x");     // 获取鼠标 x 轴移动
        //var mouse_y = -input.getaxis("mouse y");    // 获取鼠标 y 轴移动
        //if (input.getkey(keycode.mouse1))
        //{
        //    camera.transform.rotatearound(rotatecenter.position, vector3.up, mouse_x * 5);
        //    camera.transform.rotatearound(rotatecenter.position, transform.right, mouse_y * 5);
        //}
        //if (input.getkey(keycode.mouse0))
        //{
        //    camera.transform.translate(vector3.left * (mouse_x * 15f) * time.deltatime);
        //    camera.transform.translate(vector3.up * (mouse_y * 15f) * time.deltatime);
        //}

    }
}

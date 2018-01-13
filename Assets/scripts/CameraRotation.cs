using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

    public Transform target;//获取旋转目标
    public float speed = 30;

    private void Update()
    {
        camerarotate();
        camerazoom();
    }

    private void camerarotate() //摄像机围绕目标旋转操作
    {
        //transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime); //摄像机围绕目标旋转
        var mouse_x = Input.GetAxis("Mouse X");//获取鼠标X轴移动
        var mouse_y = -Input.GetAxis("Mouse Y");//获取鼠标Y轴移动
        if (Input.GetKey(KeyCode.Mouse1))
        {
            //Debug.Log("移动物体");
            transform.Translate(Vector3.left * (mouse_x * 15f) * Time.deltaTime);
            transform.Translate(Vector3.up * (mouse_y * 15f) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            //Debug.Log("旋转物体");
            transform.RotateAround(target.transform.position, Vector3.up, mouse_x * 5);
            transform.RotateAround(target.transform.position, transform.right, mouse_y * 5);
        }
    }

    private void camerazoom() //摄像机滚轮缩放
    {

       
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && Vector3.Distance(this.transform.position, target.transform.position) >6)
        {
           
            transform.Translate(Vector3.forward * 0.5f);
        }



        if (Input.GetAxis("Mouse ScrollWheel") < 0 && Vector3.Distance(this.transform.position, target.transform.position) < 12) {
           
            transform.Translate(Vector3.forward * -0.5f);
        }
          
    }
}

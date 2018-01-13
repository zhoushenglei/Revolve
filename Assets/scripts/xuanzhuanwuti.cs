using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xuanzhuanwuti : MonoBehaviour {
    /*围绕挂在脚本的物体旋转
        */

    public GameObject target;//目标移动物体

    private Touch oldTouch1;  //上次触摸点1(手指1)  
    private Touch oldTouch2;  //上次触摸点2(手指2)  


    void Update()
    {
        //var mouse_x = Input.GetAxis("Mouse X");//获取鼠标X轴移动
        //var mouse_y = -Input.GetAxis("Mouse Y");//获取鼠标Y轴移动
        //没有触摸  
        if (Input.touchCount <= 0)
        {
            return;
        }
        //单点触摸， 水平上下旋转  
        if (1 == Input.touchCount)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 deltaPos = touch.deltaPosition;
            target.transform.Rotate(Vector3.down * deltaPos.x, Space.World);//左右旋转
            target.transform.Rotate(Vector3.right * deltaPos.y, Space.World);//前后旋转


        }

        //多点触摸, 放大缩小  
        Touch newTouch1 = Input.GetTouch(0);
        Touch newTouch2 = Input.GetTouch(1);

        //第2点刚开始接触屏幕, 只记录，不做处理  
        if (newTouch2.phase == TouchPhase.Began)
        {
            oldTouch2 = newTouch2;
            oldTouch1 = newTouch1;
            return;
        }

        //计算老的两点距离和新的两点间距离，变大要放大模型，变小要缩放模型  
        float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);
        float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);

        //两个距离之差，为正表示放大手势， 为负表示缩小手势  
        float offset = newDistance - oldDistance;

        //放大因子， 一个像素按 0.01倍来算(100可调整)  
        float scaleFactor = offset / 150f;
        Vector3 localScale = target.transform.localScale;

        Vector3 scale = new Vector3(localScale.x + scaleFactor,
                                     localScale.y + scaleFactor,
                                     localScale.z + scaleFactor);

        //最小缩放到 0.3 倍  
        if (scale.x > 1f && scale.x < 2f && scale.y > 1f && scale.y < 2f && scale.z > 1f && scale.z < 2f)
        {
            DebugUtil.log("scale==========" + scale);
            target.transform.localScale = scale;
        }
        //记住最新的触摸点，下次使用  
        oldTouch1 = newTouch1;
        oldTouch2 = newTouch2;
    }
}

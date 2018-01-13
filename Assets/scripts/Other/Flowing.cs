using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowing : MonoBehaviour
{
    /*烤羊肉窜的旋转
     */
    private Vector3 startFingerPos;
    private Vector3 nowFingerPos;
    private float xMoveDistance;
    private float yMoveDistance;
    private int backValue = 0;
    public GameObject target;

    private void Update()
    {
        JudgeFinger();
    }

    public void JudgeFinger()
    {
        //没有触摸  
        if (Input.touchCount <= 0)
        {
            return;
        }

        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {

            //Debug.Log("开始触摸--------");  

            startFingerPos = Input.GetTouch(0).position;


        }

        nowFingerPos = Input.GetTouch(0).position;

        if ((Input.GetTouch(0).phase == TouchPhase.Stationary) || (Input.GetTouch(0).phase == TouchPhase.Ended))
        {

            startFingerPos = nowFingerPos;
            //Debug.Log("------结束触摸-----");  
            return;
        } 
        if (startFingerPos == nowFingerPos)
        {
            return;
        }
        xMoveDistance = Mathf.Abs(nowFingerPos.x - startFingerPos.x);

        yMoveDistance = Mathf.Abs(nowFingerPos.y - startFingerPos.y);

        if (xMoveDistance > yMoveDistance)
        {

            if (nowFingerPos.x - startFingerPos.x > 0)
            {

                //Debug.Log("------沿着X轴负方向移动----------");  

                backValue = -1; //沿着X轴负方向移动  

            }
            else
            {

                //Debug.Log("-------沿着X轴正方向移动-------");  

                backValue = 1; //沿着X轴正方向移动  

            }

        }
        else
        {

            if (nowFingerPos.y - startFingerPos.y > 0)
            {

                //Debug.Log("-----沿着Y轴正方向移动------");  

                backValue = 2; //沿着Y轴正方向移动  

            }
            else
            {

                //Debug.Log("--------沿着Y轴负方向移动-----");  

                backValue = -2; //沿着Y轴负方向移动  

            }

        }
        if (backValue == -1)
        {
            target.transform.Rotate(Vector3.back * Time.deltaTime * 300, Space.World); 
        }
        else if (backValue == 1)
        {
            target.transform.Rotate(Vector3.back * -1 * Time.deltaTime * 300, Space.World);            
        }
    }
}

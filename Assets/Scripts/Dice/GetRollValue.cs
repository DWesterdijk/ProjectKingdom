using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRollValue : MonoBehaviour
{
    // X Axis | Z Axis | Value
    // 0 | 0 | 6
    // (-)360 | 0 | 6
    // 0 | (-)360 | 6
    // 90 | 0 | 5
    // -270 | 0 | 5
    // 0 | 90 | 4
    // 0 | -270 | 4
    // 0 | 270 | 3
    // 0 | -90 | 3
    // 270 | 0 | 2
    // -90 | 0 | 2
    // (-)180 | 0 | 1
    // 0 | (-)180 | 1

    public void GetRoll()
    {
        GetValue((int)this.gameObject.transform.eulerAngles.x, (int)this.transform.eulerAngles.z);
        Debug.Log(GetValue((int)this.gameObject.transform.eulerAngles.x, (int)this.transform.eulerAngles.z));
    }

    public int GetValue(float rotationX, float rotationZ)
    {
        int value;

        if (rotationX == 0 || rotationZ == 0)
        {
            value = 6;
            return value;
        }
        else if (rotationX == 360 || rotationX == -360 || rotationZ == 360 && rotationZ == -360)
        {
            value = 6;
            return value;
        }
        else if (rotationX == 90 || rotationX == -270)
        {
            value = 5;
            return value;
        }
        else if (rotationZ == 90 || rotationZ == -270)
        {
            value = 4;
            return value;
        }
        else if (rotationZ == 270 || rotationZ == -90)
        {
            value = 3;
            return value;
        }
        else if (rotationX == 270 || rotationX == -90)
        {
            value = 2;
            return value;
        }
        else if (rotationX == 180 || rotationX == -180 || rotationZ == 180 || rotationZ == -180)
        {
            value = 1;
            return value;
        }
        else
        {
            return 0;
        }
    }
}

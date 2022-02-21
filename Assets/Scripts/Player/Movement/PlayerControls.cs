using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private static float _axisThreshold = 0.2f;

    public static bool Up()
    {
        return Input.GetAxis(StaticManager.Movement.VERTICAL) > _axisThreshold;
    }

    public static bool Down()
    {
        return Input.GetAxis(StaticManager.Movement.VERTICAL) < -_axisThreshold;
    }

    public static bool Left()
    {
        return Input.GetAxis(StaticManager.Movement.HORIZONTAL) < -_axisThreshold;
    }

    public static bool Right()
    {
        return Input.GetAxis(StaticManager.Movement.HORIZONTAL) > _axisThreshold;
    }
}

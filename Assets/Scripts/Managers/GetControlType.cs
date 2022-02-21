using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This will check wether an Xbox controller, playstation controller or no controller is connected.
/// Depending on the input type the UI will change according to it.
/// </summary>
public class GetControlType : MonoBehaviour
{
    private int _xboxControllerConnected = 0;
    private int _psControllerConnected = 0;

    //Execute at start of game
    private void Awake()
    {
        string[] names = Input.GetJoystickNames();

        for (int i = 0; i < names.Length; i++)
        {
            if (names[i].Length == 19)
            {
                _psControllerConnected = 1;
                _xboxControllerConnected = 0;
            }
            if (names[i].Length == 33)
            {
                _psControllerConnected = 0;
                _xboxControllerConnected = 1;
            }
        }

        if (_xboxControllerConnected == 1)
        {
            //Change UI to Xbox controller.
            Debug.Log("Xbox controller connected");
        }
        else if (_psControllerConnected == 1)
        {
            //Change UI to Playstation controller.
            Debug.Log("Playstation controller connected");
        }
        else
        {
            //Change  UI to Keyboard.
            Debug.Log("No Controller connected");
        }
    }
}

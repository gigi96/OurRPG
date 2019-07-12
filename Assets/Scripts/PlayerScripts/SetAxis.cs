using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAxis : MonoBehaviour
{
    [SerializeField] private string movementAxis = "Vertical";
    [SerializeField] private string rotateAxis = "Horizontal";
    [SerializeField] private string jumpAxis = "Jump";
    //[SerializeField] private KeyCode switchSpeedButton = KeyCode.LeftShift;

    public float ForwardInput { get; set; }
    public float RotateInput { get; set; }
    public bool JumpInput { get; set; }
    //public bool SwitchInput { get; set; }

    public void GetInput()
    {
        ForwardInput = Input.GetAxis(movementAxis);
        RotateInput = Input.GetAxis(rotateAxis);
        JumpInput = Input.GetButton(jumpAxis);
        //SwitchInput = Input.GetKey(switchSpeedButton);
    }
}

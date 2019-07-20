using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAxisScript : MonoBehaviour
{
    [SerializeField] private string movementAxis = "Vertical";
    [SerializeField] private string rotateAxis = "Horizontal";
    //[SerializeField] private KeyCode switchSpeedButton = KeyCode.LeftShift;
    [SerializeField] private string switchSpeedButton = "Speed";
    [SerializeField] private string jumpAxis = "Jump";

    public float ForwardInput { get; set; }
    public float RotateInput { get; set; }
    public bool SwitchInput { get; set; }
    public bool JumpInput { get; set; }

    public void GetInput()
    {
        ForwardInput = Input.GetAxis(movementAxis);
        RotateInput = Input.GetAxis(rotateAxis);
        SwitchInput = Input.GetButton(switchSpeedButton);
        JumpInput = Input.GetButton(jumpAxis);
    }
}

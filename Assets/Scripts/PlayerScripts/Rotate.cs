using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SetAxis))]
public class Rotate : MonoBehaviour
{
    [SerializeField] [Range(1, 20)] private int rotationSensitivity = 2;

    private SetAxis _axis;

    private void Start()
    {
        _axis = GetComponent<SetAxis>();
    }

    private void Update()
    {
        transform.Rotate(0, _axis.RotateInput * rotationSensitivity, 0);
    }
}

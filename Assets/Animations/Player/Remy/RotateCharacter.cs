using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SetAxisScript))]
public class RotateCharacter : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1;

    private SetAxisScript _setAxis;

    void Start()
    {
        _setAxis = GetComponent<SetAxisScript>();
    }

    void Update()
    {
        transform.Rotate(0, _setAxis.RotateInput * sensitivity, 0);
    }
}

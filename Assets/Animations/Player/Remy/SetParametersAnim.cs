using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SetAxisScript))]
[RequireComponent(typeof(Animator))]
public class SetParametersAnim : MonoBehaviour
{
    [SerializeField] private string moveParameter = "move";
    [SerializeField] private string jumpParameter = "jump";

    private SetAxisScript _setAxis;
    private Animator _animator;

    void Start()
    {
        _setAxis = GetComponent<SetAxisScript>();
        _animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        _setAxis.GetInput();

        _animator.SetFloat(moveParameter, _setAxis.ForwardInput);
        _animator.SetBool(jumpParameter, _setAxis.JumpInput);
    }

}

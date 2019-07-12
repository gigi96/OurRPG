using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private float gravity = -9.81f;

    private CharacterController _char;
    private Vector3 _move;
    private AnimationController _ac;

    private void Start()
    {
        _char = GetComponent<CharacterController>();
        _ac = GetComponent<AnimationController>();
    }

    private void Update()
    {
        if (_char.isGrounded)
            _move = Vector3.zero;
            
        if (!_ac.ClipInfo[0].clip.name.Contains("jump"))
        {
            _move.y += gravity * Time.deltaTime * Time.deltaTime;
            _char.Move(_move);
        }
    }
}

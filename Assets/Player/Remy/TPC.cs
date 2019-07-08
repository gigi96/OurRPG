using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(SetAxisScript))]
[RequireComponent(typeof(Animator))]
public class TPC : MonoBehaviour
{
    [SerializeField] [Range(0, 20)] private float runSpeed = 7;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private float jumpingStay = 4;
    [SerializeField] private float delayStay = 0.2f;
    [SerializeField] private float jumpingRun = 8;
    [SerializeField] private float delayRun = 0.1f;
    [SerializeField] private float jumpingBack = 6;
    [SerializeField] private float delayBack = 0.1f;


    private CharacterController _characterController;
    private SetAxisScript _setAxis;
    private Vector3 _movement;
    private Animator _animator;
    private bool _isJumping = false;
    private float _timeClips = 0;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _setAxis = GetComponent<SetAxisScript>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Debug.Log();
        _setAxis.GetInput();
        _timeClips = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (_characterController.isGrounded && !_isJumping)
        {
            _movement = new Vector3(0, 0, _setAxis.ForwardInput);
            _movement *= runSpeed;
            _movement = transform.TransformDirection(_movement);

            if (_setAxis.JumpInput)
            {
                _isJumping = true;
            }
        }
        else
        {
            if (_isJumping)
            {
                float delay;
                if (_movement.z > Mathf.Epsilon)
                    delay = delayRun;
                else if (_movement.z < -Mathf.Epsilon)
                    delay = delayBack;
                else
                    delay = delayStay;

                if (_timeClips > delay)
                {
                    if (_movement.z > Mathf.Epsilon)
                        _movement.y = jumpingRun;
                    else if (_movement.z < -Mathf.Epsilon)
                        _movement.y = jumpingBack;
                    else
                        _movement.y = jumpingStay;
                    _isJumping = false;
                }
            }
            _movement += transform.forward * _setAxis.ForwardInput * Time.deltaTime;
        }

        _movement.y -= (gravity * Time.deltaTime);
        _characterController.Move(_movement * Time.deltaTime);

    }
}

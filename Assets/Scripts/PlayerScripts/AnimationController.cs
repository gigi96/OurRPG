using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private string moveParameter = "move";
    [SerializeField] private string jumpParameter = "jump";

    private SetAxis _axis;
    private Animator _animator;
    private float _clipNormalizedTime;

    public AnimatorClipInfo[] ClipInfo { get; private set; }

    void Start()
    {
        _axis = GetComponent<SetAxis>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        ClipInfo = _animator.GetCurrentAnimatorClipInfo(0); //Teniamo aggiornato le info del Clip in esecuzione 
        _clipNormalizedTime = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime; //Teniamo aggiornato lo stato del Clip in esecuzione

        _axis.GetInput();

        _animator.SetFloat(moveParameter, _axis.ForwardInput);
        _animator.SetBool(jumpParameter, _axis.JumpInput);
    }
}
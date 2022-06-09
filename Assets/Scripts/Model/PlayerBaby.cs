using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerBaby : PlayerBase
{
    private Rigidbody _rigidbodyBaby;
    private static Animator _babyAnim;
    private static CapsuleCollider _collider;
    [SerializeField]
    private Joystick _joystick;

    private static float _timeToWait = 3f;
    
    private static readonly int Moving = Animator.StringToHash("Moving");
    private static readonly int Clap = Animator.StringToHash("Clap");
    private static readonly int Cry = Animator.StringToHash("Cry");


    private void Awake()
    {
        GetReferences();
    }


    private void GetReferences()
    {
        _collider = GetComponent<CapsuleCollider>();
        _rigidbodyBaby = GetComponent<Rigidbody>();
        _babyAnim = GetComponent<Animator>();
    }
    
    public override void Move(float x, float y, float z)
    {
        _rigidbodyBaby.velocity = new Vector3(x, y, z) * _speed;
    }
    
    public override void RotationMove()
    {
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbodyBaby.velocity);
            isWalk = true;
            isIdle = false;
            isClap = false;
            isCry = false;
        }
        
        if (_joystick.Horizontal == 0 || _joystick.Vertical == 0)
        {
            isWalk = false;
            isIdle = true;
            isClap = false;
            isCry = false;
        }
        
        
    }

    public override void BabyAnim()
    {
        if (isIdle)
        {
            _babyAnim.SetFloat(Moving, 0);
        }

        if (isWalk)
        {
            _babyAnim.SetFloat(Moving, 1);
        }
        
        if (isCry)
        {
            _babyAnim.SetBool(Cry, true);
        }

        if (isClap)
        {
            _babyAnim.SetBool(Clap, true);
        }
    }
    
    public static IEnumerator TimeIdle()
    {
        isWalk = false;
        isIdle = true;
        isClap = false;
        isCry = false;
        _collider.isTrigger = false;
        yield return new WaitForSeconds(_timeToWait);
        isIdle = false;
        _collider.isTrigger = true;
    }
    
    public static IEnumerator TimeCry()
    {
        isWalk = false;
        isIdle = false;
        isClap = false;
        isCry = true;
        _collider.isTrigger = false;
        yield return new WaitForSeconds(_timeToWait);
        isCry = false;
        isIdle = true;
        _collider.isTrigger = true;
    }
    
    public static IEnumerator TimeClap()
    { 
        isWalk = false;
        isIdle = false;
        isClap = true;
        isCry = false;
        _collider.isTrigger = false;
        yield return new WaitForSeconds(_timeToWait);
        isClap = false;
        isIdle = true;
        _collider.isTrigger = true;
    }
}

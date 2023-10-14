using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stats : MonoBehaviour
{
    protected float _health;
    protected float _armor;
    protected float _strength;
    protected float _attackSpeed;

    protected bool _isAttacking;
    protected bool _isInCombat;

    private float _nextDamageEvent;
    
    public void TakeDamage(float damage)
    {
        _health -= damage * _armor;
        //Debug.Log(_health);
    }

    public float DoDamage()
    {
        if(Time.time >= _nextDamageEvent)
        {
            _nextDamageEvent = Time.time + _attackSpeed;
            Debug.Log("HITHITHIT");
            return _strength;
        }
        else
        {
            //_nextDamageEvent = Time.time + _attackSpeed;
            Debug.Log("Waiting");
            return 0.0f;
        }
    }
}

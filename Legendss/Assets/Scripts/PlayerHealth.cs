using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float timeBetweenHits = 1f;
    [SerializeField] private int startingHealth = 100;
    private float lastHitTime = 0;
    private int _currentHealth;
    private Animator animator;
    public static bool isAlive = true;       //viens uz visiem klases objektiem (rezultāts)

    public int CurrentHealth
    {
        get { return _currentHealth; }
        set
        {
            if (value < 0)
                _currentHealth = 0;
            else
            {
                _currentHealth = value;
            }
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        _currentHealth = startingHealth;
        isAlive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("EnemyWeapon") && isAlive && Time.time - lastHitTime > timeBetweenHits)
        {
            TakeDamage(5);
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log("current health" + _currentHealth);
        if (_currentHealth > 0)
            animator.SetTrigger("Hurt");
        else
        {
            animator.SetTrigger("Dead");
            isAlive = false;
        }
    }
}

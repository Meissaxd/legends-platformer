using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 30;
    private int _currentHealth;
    private Animator animator;
    void Start()
    {
        _currentHealth = startingHealth;
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("PlayerWeapon"))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth > 0)
            animator.SetTrigger("hurt");
        else
        {
            animator.SetTrigger("Dead");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _maxHealth = 100;
    private int _currentHealth = 100;
    private bool _isDead;

    public float TakeDamage(int amount, out bool isDead)
    {
        if (_currentHealth - amount >= 0)
        {
            _currentHealth -= amount;
        }
        else
        {
            _currentHealth = 0;
        }
        _isDead = _currentHealth == 0 ? true : false;
        isDead = _isDead;

        Debug.Log(_currentHealth);
        return (float)_currentHealth / (float)_maxHealth;
    }

    public void Heal(int amount)
    {
        if (_currentHealth + amount <= _maxHealth)
        {
            _currentHealth += amount;
        }
        else
        {
            _currentHealth = _maxHealth;
        }
        Debug.Log(_currentHealth);
    }
}

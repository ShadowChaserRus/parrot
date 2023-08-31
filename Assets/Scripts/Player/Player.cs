using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    private Character _character = new Character("ShadowChaser", 1);
    [SerializeField] private Movement _movement;
    [SerializeField] private Attack _attack;
    [SerializeField] private Health _health;
    public void TakeDamage(int amount)
    {
        _health.TakeDamage(amount, out bool isDead);
        Debug.Log("player");
    }
}

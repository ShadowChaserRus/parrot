using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private MonsterMovement _movement;

    public void TakeDamage(int amount)
    {
        float percent = _health.TakeDamage(amount, out bool isDead);
        transform.localScale = new Vector3(percent, percent, 0f);
        if(isDead) _movement.LeaveCell();
        Debug.Log("monster");
    }
}

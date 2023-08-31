using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] private Monster _monster;
    private Cell _currentPosition;

    public void SetPosition(Cell cell)
    {
        cell.SetPlayer(_monster);
        _currentPosition = cell;
    }

    public void LeaveCell()
    {
        _currentPosition.SetAvalible(true);
        _currentPosition = null;
    }
}

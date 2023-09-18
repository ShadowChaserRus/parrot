using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] private Monster _monster;
    private Cell _currentPosition;

    public void SetPosition(Cell cell)
    {
        if (cell.PutIn(_monster))
        {
            _currentPosition = cell;
        }
    }

    public void LeaveCell()
    {
        _currentPosition.SetAvalible();
        _currentPosition = null;
    }
}

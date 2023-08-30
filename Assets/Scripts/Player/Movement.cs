using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    private Cell _currentPosition;
    private bool _isMoving;
    private Vector3 _distance;
    private Vector3 _currentPlayerPosition, _destinationPosition, _moveVector;
    public void SetPosition(Cell cell)
    {
        _currentPosition = cell;
    }
    private void Update()
    {
        if (_isMoving)
        {
            var deltaVector = _moveVector * _speed * Time.deltaTime;
            if (_distance.magnitude > deltaVector.magnitude)
            {
                transform.position += deltaVector;
                _distance -= deltaVector;
            }
            else
            {
                transform.position += _distance;
                _isMoving = false;
            }
            return;
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (_currentPosition.GetArrayY() + 1 <= EarthGrid.WorldGrid.GetLength(1) - 1)
            {
                Debug.Log("Вверх");

                Move(EarthGrid.WorldGrid[_currentPosition.GetArrayX(), _currentPosition.GetArrayY() + 1]);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (_currentPosition.GetArrayY() - 1 >= 0)
            {
                Debug.Log("Вниз");

                Move(EarthGrid.WorldGrid[_currentPosition.GetArrayX(), _currentPosition.GetArrayY() - 1]);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (_currentPosition.GetArrayX() - 1 >= 0)
            {
                Debug.Log("Влево");

                Move(EarthGrid.WorldGrid[_currentPosition.GetArrayX() - 1, _currentPosition.GetArrayY()]);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (_currentPosition.GetArrayX() + 1 <= EarthGrid.WorldGrid.GetLength(0) - 1)
            {
                Debug.Log("Вправо");

                Move(EarthGrid.WorldGrid[_currentPosition.GetArrayX() + 1, _currentPosition.GetArrayY()]);
            }
        }


    }

    private void Move(Cell nextCell)
    {
        if (!nextCell.isEmpty) return;
        // transform.position = nextCell.GetPosition();
        _currentPlayerPosition = _currentPosition.GetPosition();
        _destinationPosition = nextCell.GetPosition();
        _moveVector = _destinationPosition - _currentPlayerPosition;
        _distance = _moveVector;
        _currentPosition.SetAvalible(true);
        _currentPosition = nextCell;
        _currentPosition.SetAvalible(false);
        _isMoving = true;
    }
}

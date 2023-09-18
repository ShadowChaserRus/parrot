using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Transform _vectorImage;
    [SerializeField] private Player _player;
    [SerializeField] private float _baseSpeed = 2f;
    public Player Player => _player;
    private float _speedMultiplayer = 2f;
    private float _speed;
    public Cell _currentCell { get; private set; }
    private bool _isMoving;
    public Direction direction { get; private set; } = new Direction();
    private Vector3 _distance;
    private Vector3 _currentPlayerPosition, _destinationPosition, _moveVector;
    public void SetPosition(Cell cell)
    {
        direction.SetDirection(1, 0);
        _currentCell = cell;
        _currentCell.PutIn(_player);
    }
    private void Update()
    {
        if (_isMoving)
        {
            _speed = Input.GetKey(KeyCode.LeftShift) ? _baseSpeed * _speedMultiplayer : _baseSpeed;
            var deltaVector = _moveVector * _speed * Time.deltaTime;
            if (_distance.magnitude > deltaVector.magnitude)
            {
                transform.position += deltaVector;
                _distance -= deltaVector;
            }
            else
            {
                transform.position = _currentCell.GetPosition();
                _isMoving = false;
            }
            return;
        }

        if (Input.GetKey(KeyCode.W))
        {
            direction.SetDirection(0, 1);
            _vectorImage.eulerAngles = new Vector3(0f, 0f, 90f);
            if (_currentCell.GetArrayY() + 1 <= EarthGrid.Instance._cellGrid.GetLength(1) - 1
            && EarthGrid.Instance._cellGrid[_currentCell.GetArrayX(), _currentCell.GetArrayY() + 1].isEmpty)
            {
                Debug.Log("Вверх");
                Move(EarthGrid.Instance._cellGrid[_currentCell.GetArrayX(), _currentCell.GetArrayY() + 1]);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction.SetDirection(0, -1);
            _vectorImage.eulerAngles = new Vector3(0f, 0f, -90f);
            if (_currentCell.GetArrayY() - 1 >= 0
            && EarthGrid.Instance._cellGrid[_currentCell.GetArrayX(), _currentCell.GetArrayY() - 1].isEmpty)
            {
                Debug.Log("Вниз");
                Move(EarthGrid.Instance._cellGrid[_currentCell.GetArrayX(), _currentCell.GetArrayY() - 1]);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction.SetDirection(-1, 0);
            _vectorImage.eulerAngles = new Vector3(0f, 0f, 180f);
            if (_currentCell.GetArrayX() - 1 >= 0
            && EarthGrid.Instance._cellGrid[_currentCell.GetArrayX() - 1, _currentCell.GetArrayY()].isEmpty)
            {
                Debug.Log("Влево");
                Move(EarthGrid.Instance._cellGrid[_currentCell.GetArrayX() - 1, _currentCell.GetArrayY()]);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction.SetDirection(1, 0);
            _vectorImage.eulerAngles = new Vector3(0f, 0f, 0f);
            if (_currentCell.GetArrayX() + 1 <= EarthGrid.Instance._cellGrid.GetLength(0) - 1
              && EarthGrid.Instance._cellGrid[_currentCell.GetArrayX() + 1, _currentCell.GetArrayY()].isEmpty)
            {
                Debug.Log("Вправо");
                Move(EarthGrid.Instance._cellGrid[_currentCell.GetArrayX() + 1, _currentCell.GetArrayY()]);
            }
        }


    }

    private void Move(Cell nextCell)
    {
        if (nextCell.PutIn(_player))
        {
            _currentPlayerPosition = _currentCell.GetPosition();
            _destinationPosition = nextCell.GetPosition();
            _moveVector = _destinationPosition - _currentPlayerPosition;
            _distance = _moveVector;
            _currentCell.SetAvalible();
            _currentCell = nextCell;
            _isMoving = true;

            _playerController.CloseSomething();
        }
    }

    public void Teleport(Vector2 to)
    {
        if (_isMoving) return;
        _currentCell.SetAvalible();
        _currentCell = EarthGrid.Instance._cellGrid[(int)to.x, (int)to.y];
        _currentCell.PutIn(_player);
        transform.position = _currentCell.GetPosition();

    }

    public class Direction
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public void SetDirection(int x, int y)
        {
            this.x = x;
            this.y = y;

        }
    }

}

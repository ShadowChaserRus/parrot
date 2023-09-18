using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthGrid : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject _cell;
    [SerializeField] private float _cellSize;
    [SerializeField] private int _gridSizeX, _gridSizeY;
    [SerializeField] private PlayerSpawn _spawn;
    public static EarthGrid Instance;
    public Cell[,] _cellGrid { get; private set; }
    public List<Cell> _emptyCells { get; private set; } = new List<Cell>();
    public static float CellSize { get; private set; }
    private void Awake()
    {
        _cellGrid = new Cell[_gridSizeX, _gridSizeY];

        for (int i = 0; i < _cellGrid.GetLength(0); i++)
        {
            for (int j = 0; j < _cellGrid.GetLength(1); j++)
            {
                _cellGrid[i, j] = new Cell();
                AddEmpty(_cellGrid[i, j]);
                _cellGrid[i, j].SetPosition(_cellSize * i + _cellSize * 0.5f, _cellSize * j + _cellSize * 0.5f, i, j);
                Instantiate(_cell, _cellGrid[i, j].GetPosition(), Quaternion.identity, _parent);
            }
        }

        Instance = this;
        CellSize = _cellSize;
        _spawn.Spawn();
    }

    public void AddEmpty(Cell cell)
    {
        _emptyCells.Add(cell);
    }

    public void RemoveEmpty(Cell cell)
    {
        _emptyCells.Remove(cell);
    }


}

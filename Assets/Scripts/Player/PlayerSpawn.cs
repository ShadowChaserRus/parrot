using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private Movement _playerPrebaf;
    public void Spawn()
    {
        Instantiate(_playerPrebaf, EarthGrid.WorldGrid[0, 0].GetPosition(), Quaternion.identity).SetPosition(EarthGrid.WorldGrid[0, 0]);
    }
}

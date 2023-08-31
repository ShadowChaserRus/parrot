using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private Movement _playerPrebaf;
    [SerializeField] private MonsterMovement _monsterPrebaf;
    public void Spawn()
    {
        Instantiate(_playerPrebaf, EarthGrid.WorldGrid[0, 0].GetPosition(), Quaternion.identity).SetPosition(EarthGrid.WorldGrid[0, 0]);
        MonsterMovement newMonster = Instantiate(_monsterPrebaf, EarthGrid.WorldGrid[3, 3].GetPosition(),Quaternion.identity);
        newMonster.SetPosition(EarthGrid.WorldGrid[3, 3]);
    }
}

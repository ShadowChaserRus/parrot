using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private Movement _playerPrebaf;
    [SerializeField] private MonsterMovement _monsterPrebaf;
    [SerializeField] private ItemOnGround _itemPrefab;
    [SerializeField] private SellerNPC _sellerNPC;
    [SerializeField] private BuildingBase _nestPrebaf;
    [SerializeField] private ItemData[] _itemTypes;
    [SerializeField] private int[] _itemAmounts;
    public void Spawn()
    {
        Instantiate(_playerPrebaf, EarthGrid.Instance._cellGrid[(int)_playerPrebaf.Player._saveData.SavePoint.x, (int)_playerPrebaf.Player._saveData.SavePoint.y].GetPosition(), Quaternion.identity).SetPosition(EarthGrid.Instance._cellGrid[(int)_playerPrebaf.Player._saveData.SavePoint.x, (int)_playerPrebaf.Player._saveData.SavePoint.y]);

        MonsterMovement newMonster = Instantiate(_monsterPrebaf, EarthGrid.Instance._cellGrid[3, 3].GetPosition(), Quaternion.identity);
        newMonster.SetPosition(EarthGrid.Instance._cellGrid[3, 3]);

        EarthGrid.Instance._cellGrid[2, 0].PutIn(Instantiate(_sellerNPC, EarthGrid.Instance._cellGrid[2, 0].GetPosition(), Quaternion.identity));

        EarthGrid.Instance._cellGrid[5, 5].PutIn(Instantiate(_nestPrebaf, EarthGrid.Instance._cellGrid[5, 5].GetPosition(), Quaternion.identity));


        StartCoroutine(ItemSpawn());
    }

    private IEnumerator ItemSpawn()
    {
        while (true)
        {

            if (EarthGrid.Instance._emptyCells.Count >= _itemAmounts.Sum())
                for (int i = 0; i < _itemTypes.Length; i++)
                {
                    for (int j = 0; j < _itemAmounts[i]; j++)
                    {
                        int cellNum = Random.Range(0, EarthGrid.Instance._emptyCells.Count);

                        EarthGrid.Instance._emptyCells[cellNum].PutIn(Instantiate(_itemPrefab, EarthGrid.Instance._emptyCells[cellNum].GetPosition(), Quaternion.identity).SetItem(_itemTypes[i]));



                    }
                }
            yield return new WaitForSeconds(60f);
        }
    }
}

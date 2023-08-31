using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Attack : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    private Coroutine _coolDownCoroutine;
    private bool _coolDown = false;
    private float _weakAttackCD = 0.5f, _strongAttackCD = 2f;
    private void Update()
    {
        if(EventSystem.current.IsPointerOverGameObject()) return;
        if(_coolDown) return;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Слабая атака");
            int x = _movement._currentCell.GetArrayX() + _movement.direction.x;
            int y = _movement._currentCell.GetArrayY() + _movement.direction.y;
            if (EarthGrid.WorldGrid[x, y]._creature != null)
            {
                EarthGrid.WorldGrid[x, y]._creature.TakeDamage(1);
            }
            else
            {
                Debug.Log("Пусто");
            }

            _coolDown = true;
            _coolDownCoroutine = StartCoroutine(CoolDown(_weakAttackCD));

        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Сильная атака");
            int x = _movement._currentCell.GetArrayX() + _movement.direction.x;
            int y = _movement._currentCell.GetArrayY() + _movement.direction.y;
            if (EarthGrid.WorldGrid[x, y]._creature != null)
            {
                EarthGrid.WorldGrid[x, y]._creature.TakeDamage(10);
            }
            else
            {
                Debug.Log("Пусто");
            }

            _coolDown = true;
            _coolDownCoroutine = StartCoroutine(CoolDown(_strongAttackCD));

        }
    }

    private IEnumerator CoolDown(float time)
    {
        yield return new WaitForSeconds(time);
        _coolDown = false;
        _coolDownCoroutine = null;
    }
}

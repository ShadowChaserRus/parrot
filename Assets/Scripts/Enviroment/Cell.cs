using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public IDamageable _creature { get; private set; }
    public IPickable _item { get; private set; }
    public INPC _npc { get; private set; }
    public bool isEmpty { get; private set; } = true;
    private float x;
    private float y;
    private int _arrayX, _arrayY;
    public void SetPosition(float x, float y, int arrayX, int arrayY)
    {
        this.x = x;
        this.y = y;
        _arrayX = arrayX;
        _arrayY = arrayY;
    }
    public Vector2 GetPosition()
    {
        return new Vector2(x, y);
    }
    public Vector2 GetPosition(bool intt)
    {
        return new Vector2(_arrayX, _arrayY);
    }

    public int GetArrayX()
    {
        return _arrayX;
    }

    public int GetArrayY()
    {
        return _arrayY;
    }

    public void SetAvalible()
    {
        isEmpty = true;
        _creature = null;
        _item = null;
        _npc = null;
        EarthGrid.Instance.AddEmpty(this);
    }

    public bool PutIn(IDamageable creature)
    {
        if (!isEmpty)
        {
            return false;
        }
        else
        {
            _creature = creature;
            isEmpty = false;
            EarthGrid.Instance.RemoveEmpty(this);
            return true;
        }
    }

    public bool PutIn(IPickable item)
    {
        if (!isEmpty)
        {
            return false;
        }
        else
        {
            _item = item;
            isEmpty = false;
            EarthGrid.Instance.RemoveEmpty(this);
            return true;
        }
    }

    public bool PutIn(INPC npc)
    {
        if (!isEmpty)
        {
            return false;
        }
        else
        {
            _npc = npc;
            isEmpty = false;
            EarthGrid.Instance.RemoveEmpty(this);
            return true;
        }
    }


}

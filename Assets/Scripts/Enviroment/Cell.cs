using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public IDamageable _creature { get; private set; }
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

    public int GetArrayX()
    {
        return _arrayX;
    }

    public int GetArrayY()
    {
        return _arrayY;
    }

    public void SetAvalible(bool toggle)
    {
        isEmpty = toggle;
        if (toggle) _creature = null;
    }

    public void SetPlayer(IDamageable creature)
    {
        _creature = creature;
        isEmpty = false;
    }


}

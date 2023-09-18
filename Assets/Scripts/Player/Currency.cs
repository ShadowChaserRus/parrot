using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency
{
    private string _name;
    private int _amount;

    public Currency(string name, int amount)
    {
        _name = name;
        _amount = amount;
    }

    public int Add(int amount)
    {
        _amount += amount;
        return _amount;
    }

    public bool Spend(int amount)
    {
        if (_amount - amount < 0)
        {
            return false;
        }
        else
        {
            _amount -= amount;

            return true;
        }
    }

    public bool CheckAmount(int amount)
    {
        if (_amount - amount < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public int Info()
    {
        return _amount;
    }
}

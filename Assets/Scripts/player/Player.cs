using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _maxHP;
    private int _hp;
    private LevelManager levelManger;

    public void GetDamage(int amount)
    {
        _hp -= amount;

        if (_hp <= 0)
            levelManger.GameOver();
    }

    public void GetHeal(int amount)
    {
        if(_hp + amount <= _maxHP)
        _hp += amount;
    }

    private void Start()
    {
        levelManger = LevelManager.levelManager;
        _maxHP = levelManger.PlayerHP;
        _hp = _maxHP;
    }
}

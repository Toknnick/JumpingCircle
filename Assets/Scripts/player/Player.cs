using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _hp;
    private LevelManger levelManger;

    public void GetDamge(int amount)
    {
        _hp -= amount;

        if (_hp <= 0)
            levelManger.GameOver();
    }

    private void Start()
    {
        levelManger = LevelManger.levelManager;
        _hp = levelManger.PlayerHP;
    }
}

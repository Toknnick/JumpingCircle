using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsHasMaxHp { get; private set; }
    private int _maxHP;
    private int _hp;
    private LevelManager levelManger;

    public void GetDamage(int amount)
    {
        _hp -= amount;
        IsHasMaxHp = false;

        if (_hp <= 0)
            levelManger.GameOver();
    }

    public void GetHeal(int amount)
    {
        if (_hp == _maxHP)
            IsHasMaxHp = true;

        if (_hp + amount <= _maxHP)
            _hp += amount;
        else if(!IsHasMaxHp)
            _hp = _maxHP;
    }

    private void Start()
    {
        levelManger = LevelManager.levelManager;
        _maxHP = levelManger.PlayerHP;
        _hp = _maxHP;
        IsHasMaxHp = true;
    }
}

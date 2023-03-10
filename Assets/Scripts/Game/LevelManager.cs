using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;
    #region Player
    [Header("?????")]
    [SerializeField] private Transform _player;
    [SerializeField] private MovingCamera _camera;
    public Transform Player => _player;
    [SerializeField] private int _playerHP = 2;
    public int PlayerHP => _playerHP;
    #region Move
    [SerializeField] private float minForce = 100f;
    public float MinForce => minForce;
    [SerializeField] private float maxForce = 700f;
    public float MaxForce => maxForce;
    [SerializeField] private float timeForMaxForce = 1;
    public float TimeForMaxForce => timeForMaxForce;
    #endregion
    #endregion
    #region Enemies
    #region Spike
    [Header("???")]
    [SerializeField] private int _spikeDamage = 1;
    public int SpikeDamage => _spikeDamage;
    #endregion
    #region Turret
    [Header("??????")]
    [SerializeField] private int _cd = 2;
    public int CD => _cd;
    #endregion
    #region Bullet
    [Header("????")]
    [SerializeField] private int _bulletDamage = 1;
    public int BulletDamage => _bulletDamage;
    [SerializeField] private int _bulletSpeed = 10;
    public int BulletSpeed => _bulletSpeed;
    #endregion
    #region Patroller
    [Header("???????")]
    [SerializeField] private float _maxSpeed = 10;
    public float MaxSpeed => _maxSpeed;
    [SerializeField] private int _patrollDamage = 1;
    public int PatrollDamage => _patrollDamage;

    #endregion
    #region Bomb
    [Header("?????")]
    [SerializeField] private float _timeForBum = 1;
    public float TimeForBum => _timeForBum;
    [SerializeField] private int _damageOfBomb = 1;
    public int DamageOfBomb => _damageOfBomb;
    #endregion
    #region Lava
    [Header("????")]
    [SerializeField] private int _lavaDamage = 1;
    public int LavaDamage => _lavaDamage;
    [SerializeField] private float _timeForLavaForDealDamage = 4;
    public float TimeForLavaForDealDamage => _timeForLavaForDealDamage;
    #endregion
    #region MashineGun
    [Header("???????")]
    [SerializeField] private float _mashineGuntimeBetweenShoot = 0.6f;
    public float MashineGuntimeBetweenShoot => _mashineGuntimeBetweenShoot;
    #endregion
    #region Mace
    [Header("??????")]
    [SerializeField] private int _maceDamage = 1;
    public int MaceDamage => _maceDamage;
    #endregion
    #endregion

    private void Awake()
    {
        if (levelManager == null)
            levelManager = this;
        else
            Destroy(gameObject);

        _player = Instantiate(_player);
        _camera = Instantiate(_camera.gameObject).GetComponent<MovingCamera>();
        _player.transform.position = new Vector2(0, 0);
        _camera.SetTartget(_player);
    }

    public void GameOver()
    {
        Debug.Log("Game over");
    }
}

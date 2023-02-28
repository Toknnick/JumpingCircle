using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;
    #region Player
    [Header("Игрок")]
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
    [Header("Шип")]
    [SerializeField] private int _spikeDamage = 1;
    public int SpikeDamage => _spikeDamage;
    #endregion
    #region Turret
    [Header("Турель")]
    [SerializeField] private int _cd = 2;
    public int CD => _cd;
    [SerializeField] private int _turretDamage = 1;
    public int TurretDamage => _turretDamage;
    [SerializeField] private int _bulletSpeed = 10;
    public int BulletSpeed => _bulletSpeed;
    #endregion
    #region Patroller
    [Header("Патруль")]
    [SerializeField] private float _maxSpeed = 10;
    public float MaxSpeed => _maxSpeed;
    [SerializeField] private int _damage = 1;
    public int Damage => _damage;

    #endregion
    #region Bomb
    [Header("Бомба")]
    [SerializeField] private float _timeForBum = 1;
    public float TimeForBum => _timeForBum;
    [SerializeField] private int _damageOfBomb = 1;
    public int DamageOfBomb => _damageOfBomb;
    #endregion
    #endregion

    private void Awake()
    {
        if (levelManager == null)
            levelManager = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
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

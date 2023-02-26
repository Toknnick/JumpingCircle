using UnityEngine;

public class LevelManger : MonoBehaviour
{
    public static LevelManger levelManager;
    #region Player
    [Header("�����")]
    [SerializeField] private Transform _player;
    [SerializeField] private MovingCamera _camera;
    public Transform Player => _player;
    [SerializeField] private int _playerHP = 2;
    public int PlayerHP => _playerHP;
    #region Move
    [SerializeField] private float minForce = 10f;
    public float MinForce => minForce;
    [SerializeField] private float maxForce = 700f;
    public float MaxForce => maxForce;
    [SerializeField] private float timeForMaxForce = 1.8f;
    public float TimeForMaxForce => timeForMaxForce;
    #endregion
    #endregion
    #region Enemies
    #region Spike
    [Header("���")]
    [SerializeField] private int _spikeDamage = 1;
    public int SpikeDamage => _spikeDamage;
    #endregion
    #region Turret
    [Header("������")]
    [SerializeField] private int _cd = 2;
    public int CD => _cd;
    [SerializeField] private int _turretDamage = 1;
    public int TurretDamage => _turretDamage;
    [SerializeField] private int _bulletSpeed = 10;
    public int BulletSpeed => _bulletSpeed;
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
        _player.transform.position = new Vector2(0, 0);
        _camera.SetTartget(_player);
    }

    public void GameOver()
    {
        Debug.Log("Game over");
    }
}

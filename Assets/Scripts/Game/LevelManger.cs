using UnityEngine;

public class LevelManger : MonoBehaviour
{
    public static LevelManger levelManager;
    #region Player
    [SerializeField] private Transform _player;
    [SerializeField] private MovingCamera _camera;
    public Transform Player => _player;
    [SerializeField] private int _playerHP;
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
    [SerializeField] private int _spikeDamage;
    public int SpikeDamage => _spikeDamage;
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

    }
}

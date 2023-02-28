using UnityEngine;

public class Water : MonoBehaviour
{
    private LevelManager _levelManager;
    private float _maxForce;
    private TouchMovement _touchMovement;

    private void Start()
    {
        _levelManager = LevelManager.levelManager;
        _maxForce = _levelManager.MaxForce;
        _touchMovement = _levelManager.Player.GetComponent<TouchMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _touchMovement.ChangeMaxForce(0.5f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _touchMovement.ChangeMaxForce(2);
    }
}

using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private BoxCollider2D _col;
    [SerializeField] private GameManager _gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyMovement enemy) || ( collision.TryGetComponent(out Bullet bullet)) || (collision.TryGetComponent(out Wall wall)))
        {
            Death();
        }        
    }

    public void Death()
    {
        _gameManager.PlayerDied();
        Destroy(gameObject);        
    }    
}

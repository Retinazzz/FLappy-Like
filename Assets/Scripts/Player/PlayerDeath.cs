using UnityEngine;

public class PlayerDeath : MonoBehaviour, IService
{    
    [SerializeField] private GameObject _player;
    [SerializeField] private BoxCollider2D _col;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IObstacle enemy) || ( collision.TryGetComponent(out Bullet bullet) && bullet._isEnemy == true) || (collision.TryGetComponent(out IObstacle wall)))
        {
            Die();
        }        
    }

    private void Die()
    {        
        ServiceLocator.Get<GameManager>().PlayerDied();
        Destroy(gameObject);        
    }    
}

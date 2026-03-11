using UnityEngine;

public class EnemyDeath : MonoBehaviour , IService
{
    [SerializeField] private int _scoreValue = 1;
    [SerializeField] private BoxCollider2D _col;
    [SerializeField] private Score _score;   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IObstacle wall) || collision.TryGetComponent(out IDamagable player) || (collision.TryGetComponent(out Bullet bullet) && bullet._isEnemy == false))
        {
            Debug.Log("Lomaysa hOmyak");
            Die();
        }        
    }

    private void Die()
    {
        _score.AddScore(_scoreValue);
        Destroy(gameObject);
    }
}

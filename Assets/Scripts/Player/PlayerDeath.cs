using UnityEngine;
using System;

public class PlayerDeath : MonoBehaviour, IService
{    
    [SerializeField] private GameObject _player;
    [SerializeField] private BoxCollider2D _col;

    public static event Action OnPlayerDied;
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamagable>(out _) || ( collision.TryGetComponent(out Bullet bullet) && bullet.IsEnemyBullet == true) || (collision.TryGetComponent<IObstacle>(out _)))
        {            
            Die();
        }        
    }

    private void Die()
    {
        OnPlayerDied?.Invoke();        
        Destroy(gameObject);        
    }    
}

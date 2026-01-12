using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private BoxCollider2D _col;
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || ( collision.CompareTag("EnemyBullet")) || (collision.CompareTag("Wall")))
        {
            Death();
        }
        
    }
    public void Death ()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PlayerDied();
        }
        Destroy(_player);        
    }
    
}

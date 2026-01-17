using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private int _scoreValue = 1;
    [SerializeField] private BoxCollider2D _col;
    [SerializeField] private Score _score;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Wall wall) || collision.TryGetComponent(out PlayerMovement player))
        {
            Debug.Log("Lomaysa hOmyak");
            Death();
        }        
    }

    private void Death()
    {
        _score.AddScore(_scoreValue);
        Destroy(gameObject);
    }
}

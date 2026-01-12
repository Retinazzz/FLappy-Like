using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private int _scoreValue = 1;

    private BoxCollider2D _col;    
    private void Awake ()
    {
        _col = GetComponent<BoxCollider2D>();        
    }
    
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("Player"))
        {
            Debug.Log("Lomaysa hOmyak");
            Death();
        }
        
    }
    private void Death ()
    {
        Score.Instance.AddScore(_scoreValue);
        Destroy(this.gameObject);
    }

}

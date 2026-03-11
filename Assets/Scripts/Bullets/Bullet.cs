using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 100f;
    [SerializeField] private int _shootingDistance;
    [SerializeField] private GameObject _bullet;    
    private Vector2 _target;

    public bool _isEnemy;

    private void Awake ()
    {
        _target = new Vector2(transform.position.x - _shootingDistance, transform.position.y);
    }

    private void Update ()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.TryGetComponent(out IObstacle wall) || (collision.TryGetComponent(out IDamagable player) && _isEnemy == true) || (collision.TryGetComponent(out IDamagable enemy) && _isEnemy == false))
        {
            Destroy(gameObject);
        }        
    }
}


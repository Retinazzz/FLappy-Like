using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 100f;
    [SerializeField] private int _shootingDistance;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private bool _isEnemyBullet;
    private Vector2 _target;

    public bool IsEnemyBullet => _isEnemyBullet;

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
        if (collision.TryGetComponent(out IObstacle wall) || (collision.TryGetComponent(out IDamagable player) && _isEnemyBullet == true) || (collision.TryGetComponent(out IDamagable enemy) && _isEnemyBullet == false))
        {
            Destroy(gameObject);
        }        
    }
}


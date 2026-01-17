using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 100f;
    [SerializeField] private int _shootingDistance;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _transform;
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private EnemyMovement _enemy;
    private Vector2 _target;

    private void Awake()
    {
        _target = new Vector2(_transform.position.x - _shootingDistance, _transform.position.y);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(_transform.position, _target, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Wall wall))
        {
            Destroy(_bullet);
        }
        else if (collision.TryGetComponent(out _player))
        {
            Destroy(_bullet);
        }
        else if (collision.TryGetComponent(out _enemy))
        {
            Destroy(_bullet);
        }
    }
}


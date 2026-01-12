
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 150f;
    [SerializeField] private int _shootingDistance;
    [SerializeField] private GameObject _bullet;
    private Transform _pos;
    private Vector2 _target;
    private void Awake ()
    {
        _pos = GetComponent<Transform>();
        _target = new Vector2(_pos.position.x + _shootingDistance, _pos.position.y);
    }
    void FixedUpdate ()
    {
        transform.position = Vector2.MoveTowards(_pos.position, _target, _speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Wall"))
        {
            Destroy(_bullet);
        }

    }
}

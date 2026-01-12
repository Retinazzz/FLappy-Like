using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private Transform _pos;
    private Vector2 _target;
    private int _distanceToTarget = 1000;
    private void Awake ()
    {
        _pos = GetComponent<Transform>();
    }
    private void Start ()
    {
        _target = new Vector2(_pos.position.x - _distanceToTarget, _pos.position.y);
    }
    void Update ()
    {
        EnemyMove();
    }
    private void EnemyMove ()
    {
        transform.position = Vector2.MoveTowards(_pos.position, _target, speed * Time.deltaTime);
    }
}
    

using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Transform _transform;
    private Vector2 _target;
    private int _distanceToTarget = 1000;    

    private void Start()
    {
        _target = new Vector2(_transform.position.x - _distanceToTarget, _transform.position.y);
    }

    private void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        transform.position = Vector2.MoveTowards(_pos.position, _target, speed * Time.deltaTime);
    }
}
    

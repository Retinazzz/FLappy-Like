using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private float _shootingInterval = 2f;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _shootingPoint;
    private float _timer = 0f;    

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _shootingInterval)
        {
            Shoot();
            _timer = 0;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(_bullet, _shootingPoint);
        bullet.transform.parent = null;
    }
}


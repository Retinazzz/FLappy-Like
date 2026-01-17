using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private  GameObject _playerBullet;
    [SerializeField] Transform _shootingPoint;
    private IInputSystem _inputSystem;
    private void Awake()
    {
        _inputSystem = new InputSystem();
        Init(_inputSystem);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _inputSystem.PressShoot();
        }
    }

    public void Init(IInputSystem inputSystem)
    {
        _inputSystem = inputSystem;
        _inputSystem.FireClicked += OnFireButtonClicked;
    }

    private void OnFireButtonClicked()
    {
        Debug.Log("Fire");
        Fire();
    }

    private void Fire()
    {
        Instantiate(_playerBullet, _shootingPoint);
    }

    private void OnDestroy()
    {
        if (_inputSystem != null)
        {
            _inputSystem.FireClicked -= OnFireButtonClicked;
        }
    }
}

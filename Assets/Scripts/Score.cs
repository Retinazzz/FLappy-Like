using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }

    [SerializeField] private Text _currentScoreText;
    [SerializeField] private Text _maxScoreText;

    private int _score = 0;
    
    private void Awake ()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }                       
    }
    private void Start ()
    {
        UpdateScoreDisplay();
    }

    public void AddScore (int points)
    {
        if (points <= 0) return;

        _score += points;
        UpdateScoreDisplay();
        Debug.Log($"Добавлено {points} очков. Всего: {_score}");
    }

    public void ResetScore ()
    {
        _score = 0;
        UpdateScoreDisplay();       
    }

    private void UpdateScoreDisplay ()
    {
        if (_currentScoreText != null)
        {
            _currentScoreText.text = $"Score: {_score}";
        }
    }
    public void ShowScoreOnDeath ()
    {
        if (_maxScoreText != null)
        {
            _maxScoreText.text = $"Max Score: {_score}";
        }
    }

    public int GetCurrentScore () => _score;
    
}


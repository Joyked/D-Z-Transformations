using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CounterDisplay : MonoBehaviour
{
    [SerializeField] private ButtonCounter _buttonCounter;
    
    private Text _textScore;

    private void Start()
    {
        _textScore = GetComponent<Text>();
    }

    private void ShowScore()
    {
        _textScore.text = "" + _buttonCounter.Score;
    }
    
    private void OnEnable()
    {
        _buttonCounter.ScoreEvent += ShowScore;
    }

    private void OnDisable()
    {
        _buttonCounter.ScoreEvent -= ShowScore;
    }
}

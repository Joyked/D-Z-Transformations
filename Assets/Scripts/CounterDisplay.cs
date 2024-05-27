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

    void Update()
    {
        _textScore.text = "" + _buttonCounter.Score;
    }
}

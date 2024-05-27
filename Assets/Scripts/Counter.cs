using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Text _textScore;

    private Text _textButton;
    private Button _button;
    private bool _isWorkCoroutine;
    private bool _isStartScorer;
    private int _score;

    private void Start()
    {
        _textButton = GetComponentInChildren<Text>();
        _textButton.text = "START";
        _button = GetComponent<Button>();
        _button.onClick.AddListener(HandleButton);
        StartCoroutine(Scorer());
        _isWorkCoroutine = true;
    }

    private IEnumerator Scorer()
    {
        float stepInSeconds = 0.5f;
        var wait = new WaitForSeconds(stepInSeconds);
        
        while (_isWorkCoroutine)
        {
            if (_isStartScorer)
            {
                _score++;
                ShowScore();
            }
            yield return wait;
        }
    }
    
    private void ShowScore()
    {
        _textScore.text = "" + _score;
    }

    private void HandleButton()
    {
        _isStartScorer = !_isStartScorer;
        _textButton.text = _isStartScorer ? "STOP" : "START";
    }

    private void OnDisable()
    {
        StopCoroutine(Scorer());
    }
}

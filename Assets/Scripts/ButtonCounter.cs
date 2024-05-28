using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonCounter : MonoBehaviour
{
    private const string StartCommand = "START";
    private const string StopCommand = "STOP";

    private Coroutine _coroutine;
    private Text _textButton;
    private Button _button;
    private bool _isWork;
    private bool _isWorkScoring;

    public event Action ScoreEvent; 
    
    public int Score { get; private set; }
    
    private void Start()
    {
        _textButton = GetComponentInChildren<Text>();
        _textButton.text = StartCommand;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ClickProcessing);
        _isWorkScoring = true;
    }

    private IEnumerator Scoring()
    {
        float stepInSeconds = 0.5f;
        var wait = new WaitForSeconds(stepInSeconds);
        
        while (_isWorkScoring)
        {
            Score++;
            ScoreEvent?.Invoke();
            yield return wait;
        }
    }
    
    private void ClickProcessing()
    {
        _isWork = !_isWork;

        if (_isWork)
        {
            _coroutine = StartCoroutine(Scoring());
            _textButton.text = StopCommand;
        }
        else
        {
            StopCoroutine(_coroutine);
            _textButton.text = StartCommand;
        }
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ClickProcessing);
        
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }
}

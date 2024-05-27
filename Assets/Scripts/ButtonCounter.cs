using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ButtonCounter : MonoBehaviour
{
    [SerializeField] private Text _textScore;

    private const string _startCommand = "START";
    private const string _stopCommand = "STOP";

    private Coroutine _coroutine;
    private Text _textButton;
    private Button _button;
    private bool _isWork;
    private int _score;

    public int Score => _score;
    
    private void Start()
    {
        _textButton = GetComponentInChildren<Text>();
        _textButton.text = _startCommand;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ClickProcessing);
        _coroutine = StartCoroutine(Scoring());
    }

    private IEnumerator Scoring()
    {
        float stepInSeconds = 0.5f;
        var wait = new WaitForSeconds(stepInSeconds);
        
        while (true)
        {
            if (_isWork)
                _score++;
            
            yield return wait;
        }
    }
    
    private void ClickProcessing()
    {
        _isWork = !_isWork;
        _textButton.text = _isWork ? _stopCommand : _startCommand;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ClickProcessing);
        
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }
}

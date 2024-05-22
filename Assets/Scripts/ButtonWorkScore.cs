using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonWorkScore : MonoBehaviour
{
    private Text _text;
    private bool _isStart = false;
    private Button _button;
    public static event Action<bool> InputButton;

    private void Start()
    {
        _text = GetComponentInChildren<Text>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ReportTouch);
        _text.text = "START";
    }

    private void Update()
    {
        Debug.Log(_isStart);
    }

    public void ReportTouch()
    {
        _isStart = !_isStart;
        InputButton.Invoke(_isStart);
        _text.text = _isStart ? "STOP" : "START";
    }
}

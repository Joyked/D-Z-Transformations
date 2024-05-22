using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    private Text _counter;
    private int _count = 0;
    private Coroutine _coroutine;
    
    private void Start()
    {
        _counter = GetComponent<Text>();
    }

    private void OnEnable()
    {
        ButtonWorkScore.InputButton += ButtonInput;
    }

    private void OnDisable()
    {
        ButtonWorkScore.InputButton -= ButtonInput;
    }

    private void ButtonInput(bool isStartCounter)
    {
        if(_coroutine != null) 
            StopCoroutine(_coroutine);
            
        _coroutine = StartCoroutine(Scoring(isStartCounter));
    }

    private IEnumerator Scoring(bool isStartCounter)
    {
        float stepInSeconds = 0.5f;
        var wait = new WaitForSeconds(stepInSeconds);

        while (isStartCounter)
        {
            Debug.Log(isStartCounter);
            ShowCount(_count++);
            yield return wait;
        }
    }
    
    private void ShowCount(int count)
    {
        _counter.text = "" + count;
    }
}

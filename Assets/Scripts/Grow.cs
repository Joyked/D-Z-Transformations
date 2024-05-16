using System;
using UnityEngine;

public class Grow : MonoBehaviour
{
    [SerializeField] private float _rateOfGrowth;

    private void Update()
    {
        transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * _rateOfGrowth;
    }
}

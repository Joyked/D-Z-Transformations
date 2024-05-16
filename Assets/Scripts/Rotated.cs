using UnityEngine;

public class Rotated : MonoBehaviour
{
   [SerializeField] private float _speedRotation;

   private void Update()
   {
      transform.Rotate(Vector3.up * _speedRotation * Time.deltaTime);
   }
}

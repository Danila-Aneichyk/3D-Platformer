using System;
using UnityEngine;

namespace Player
{
    public class PlayerRotator : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _speed = 3f;

        private Vector3 _previousMousePosition; 

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            _previousMousePosition = Input.mousePosition;
        }

        private void Update()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 delta = _previousMousePosition - mousePosition;
            float rotationDelta = delta.x; 
            transform.Rotate(transform.up, rotationDelta * _speed * Time.deltaTime);
            _previousMousePosition = mousePosition; 
        }

        #endregion
    }
}
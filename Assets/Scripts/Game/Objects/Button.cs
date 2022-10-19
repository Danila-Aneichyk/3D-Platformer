using System;
using UnityEngine;

namespace Platformer3D.Game
{
    public class Button : MonoBehaviour
    {
        #region Variables

        [SerializeField] private MovingObject _movingObject;
        
        private bool _isTouched = false;

        #endregion


        #region Unity lifecycle

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player))
            {
                _movingObject.Move();
                _isTouched = true; 
            }
        }
        
        #endregion
    }
}
using System;
using UnityEngine;

namespace Platformer3D.Game
{
    [RequireComponent(typeof(Rigidbody))]
    public class StandArea : MonoBehaviour
    {
        #region Variables

        private Transform _previousParent; 

        #endregion
        
        #region Unity lifecycle

        private void Awake()
        {
            Collider col = GetComponent<Collider>();
            col.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Tags.Player))
                return;
            _previousParent = other.transform.parent; 
            other.transform.SetParent(transform);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag(Tags.Player))
                return;
            other.transform.SetParent(_previousParent);
            _previousParent = null; 
        }

        #endregion
    }
}
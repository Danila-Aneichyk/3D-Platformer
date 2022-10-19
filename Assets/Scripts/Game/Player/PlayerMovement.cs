using UnityEngine;

namespace Platformer3D.Game
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables

        [Header("Base Settings")]
        [SerializeField] private float _speed = 3f;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _gravityMultiplier = 1f;

        [Header("Grounded")]
        [SerializeField] private Transform _checkGroundTransform;
        [SerializeField] private float _checkGroundedRadius;
        [SerializeField] private LayerMask _checkGroundMask;

        [Header("Jump")]
        [SerializeField] private float _jumpHeight = 2f;

        private Vector3 _fallVector;
        private Transform _cachedTransform;
        private bool _isGrounded; 
        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            _cachedTransform = transform; 
        }

        private void FixedUpdate()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 moveVector = _cachedTransform.right * horizontal + _cachedTransform.forward * vertical;
            moveVector *= (_speed * Time.deltaTime);

            _characterController.Move(moveVector);


            _isGrounded = Physics.CheckSphere(_checkGroundTransform.position, _checkGroundedRadius, _checkGroundMask);
            Debug.Log($"IsGrounded {_isGrounded}");

            if (_isGrounded && _fallVector.y < 0)
            {
                _fallVector.y = 0;
            }
        
            float gravity = Physics.gravity.y * _gravityMultiplier;
        
            if (_isGrounded && Input.GetButtonDown("Jump"))
            {
                _fallVector.y = Mathf.Sqrt(_jumpHeight * -2f * gravity);
            }

            _fallVector.y += gravity * Time.deltaTime;
            _characterController.Move(_fallVector * Time.deltaTime);
        }

        #endregion
    }
}
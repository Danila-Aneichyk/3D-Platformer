using UnityEngine;

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
    #endregion


    #region Unity lifecycle

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveVector = transform.right * horizontal + transform.forward * vertical;
        moveVector *= (_speed * Time.deltaTime);

        _characterController.Move(moveVector);


        bool isGrounded = Physics.CheckSphere(_checkGroundTransform.position, _checkGroundedRadius, _checkGroundMask);
        Debug.Log($"IsGrounded {isGrounded}");
        
        Vector3 fallVector = Vector3.zero;
        float gravity = Physics.gravity.y * _gravityMultiplier;
        fallVector.y += gravity * Time.deltaTime;
        _characterController.Move(fallVector);
    }

    #endregion
}
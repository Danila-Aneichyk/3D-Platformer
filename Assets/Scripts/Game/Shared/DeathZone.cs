using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer3D.Game
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"Collision with: {other.gameObject.name}");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }
    }
}
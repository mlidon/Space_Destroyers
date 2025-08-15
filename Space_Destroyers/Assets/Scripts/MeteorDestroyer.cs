using UnityEngine;

public class MeteorDestroyer : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D other)
    {
        // Destruye cualquier meteorito que choque con el collider
        if (other.CompareTag("Meteor"))
        {
            Destroy(other.gameObject);
        }
    }
}

using UnityEngine;

public class TranslateOnTrigger : MonoBehaviour
{
    public GameObject objectToTranslate; // Reference to the GameObject to translate
    public GameObject meshObjectToDisable; // Reference to the GameObject whose MeshRenderer will be disabled
    public GameObject colliderObject; // Reference to the GameObject with the BoxCollider
    private Vector3 originalPosition; // Store the original position of the object
    private Vector3 downPosition; // Store the position when translated down
    private MeshRenderer meshRendererToDisable; // Reference to the MeshRenderer component of meshObjectToDisable

    private void Start()
    {
        // Store the original position of the object
        originalPosition = objectToTranslate.transform.position;

        // Calculate the position when translated down (e.g., move down by 1 unit)
        downPosition = originalPosition - 6 * Vector3.up;

        // Get the MeshRenderer component of meshObjectToDisable
        meshRendererToDisable = meshObjectToDisable.GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the tag "Player" or "Weight"
        if (other.CompareTag("Player") || other.CompareTag("Weight"))
        {
            // Translate the object down
            objectToTranslate.transform.position = downPosition;
            // Translate the BoxCollider down
            colliderObject.GetComponent<BoxCollider>().center -= Vector3.up;
            // Hide the MeshRenderer of meshObjectToDisable
            meshRendererToDisable.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the colliding object had the tag "Player" or "Weight"
        if (other.CompareTag("Player") || other.CompareTag("Weight"))
        {
            // Translate the object back to its original position
            objectToTranslate.transform.position = originalPosition;
            // Translate the BoxCollider back to its original position
            colliderObject.GetComponent<BoxCollider>().center += Vector3.up;
            // Show the MeshRenderer of meshObjectToDisable
            meshRendererToDisable.enabled = true;
        }
    }
}
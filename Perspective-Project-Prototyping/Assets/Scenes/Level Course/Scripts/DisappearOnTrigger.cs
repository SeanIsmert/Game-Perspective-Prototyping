using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnTrigger : MonoBehaviour
{
    public GameObject objectToDisappear; // Reference to the GameObject to disappear

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Make the referenced object disappear
            objectToDisappear.SetActive(false);

            // Disable the MeshRenderer of the object with this script
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = false;
            }
        }
    }
}
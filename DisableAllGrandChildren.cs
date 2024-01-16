using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAllGrandChildren : MonoBehaviour
{

    public void DeactivateAllGrandchildren()
    {
        foreach (Transform childTransform in transform)
        {
            // Call a separate method to deactivate grandchildren
            DeactivateGrandchildrenOnly(childTransform);
        }
    }

    private void DeactivateGrandchildrenOnly(Transform parentTransform)
    {
        // Iterate through each child of the current Transform
        foreach (Transform childTransform in parentTransform)
        {
            // Deactivate the GameObject
            childTransform.gameObject.SetActive(false);

            // Recursively call this method for each child to deactivate their descendants
            DeactivateGrandchildrenOnly(childTransform);
        }
    }
}
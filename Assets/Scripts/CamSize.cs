using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSize : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Debug.Log("NotVisible");
    }

    private void OnBecameVisible()
    {
        Debug.Log("Visible");
    }

    private void OnGUI()
    {
        float aspectRatioDesign = (16f / 9f);
        float orthographicStartSize = 17f;

        float inverseAspectRatio = 1 / aspectRatioDesign;
        float currentAspectRatio = (float)Screen.width / (float)Screen.height;

        if (currentAspectRatio > aspectRatioDesign)
        {
            currentAspectRatio -= (currentAspectRatio - aspectRatioDesign);
        }
        else if (currentAspectRatio < inverseAspectRatio)
        {
            currentAspectRatio += (currentAspectRatio - inverseAspectRatio);
        }

        Camera.main.orthographicSize = aspectRatioDesign * (orthographicStartSize / currentAspectRatio);
    }
}

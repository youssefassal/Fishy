using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishUI : MonoBehaviour
{
    public Image[] fishSizeImages; // Assign these in the Inspector
    public float[] sizeThresholds; // Assign these in the Inspector to correspond to each fish size
    private int currentSizeIndex = 0;



    public void UpdatePlayerSize(float playerSize)
    {
        for (int i = 0; i < sizeThresholds.Length; i++)
        {
            if (playerSize >= sizeThresholds[i])
            {
                // Enable full alpha for fish sizes the player can eat
                fishSizeImages[i].color = new Color(fishSizeImages[i].color.r, fishSizeImages[i].color.g, fishSizeImages[i].color.b, 1f);
                currentSizeIndex = i;
            }
            else
            {
                // Dim the fish sizes the player cannot eat yet
                fishSizeImages[i].color = new Color(fishSizeImages[i].color.r, fishSizeImages[i].color.g, fishSizeImages[i].color.b, 0.5f);
            }
        }
    }

    private void Update()
    {
        float simulatedPlayerSize = PlayerMovement.FishSize;
        UpdatePlayerSize(simulatedPlayerSize);
    }
}

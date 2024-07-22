using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    public Sprite muteIcon;  // Icon for the mute state
    public Sprite unmuteIcon;  // Icon for the unmute state
    private Button button;
    private Image buttonImage;
    private bool isMuted = false;


    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();

        button.onClick.AddListener(ToggleMute);

        // Initialize the button's icon
        if (AudioListener.volume == 0)
        {
            isMuted = true;
            buttonImage.sprite = muteIcon;
        }
        else
        {
            isMuted = false;
            buttonImage.sprite = unmuteIcon;
        }
    }
    void ToggleMute()
    {
        if (isMuted)
        {
            AudioListener.volume = 1;
            buttonImage.sprite = unmuteIcon;
        }
        else
        {
            AudioListener.volume = 0;
            buttonImage.sprite = muteIcon;
        }

        isMuted = !isMuted;
    }
}


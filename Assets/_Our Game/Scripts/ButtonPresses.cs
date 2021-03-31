using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPresses : MonoBehaviour
{
    public GameObject player;

    public static bool paused = false;
    public static bool volumeOpen = false;

    public Button pauseButton;
    public Sprite[] pauseButtonImages;
    public Slider volumeSlider;
    private float startJumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        if(player != null) startJumpHeight = player.GetComponent<Knight>().jumpForce;
    }

    // Update is called once per frame
    void Update()
    {
        if (volumeOpen && player != null)
        {
            //Change Jump Height
            player.GetComponent<Knight>().jumpForce = startJumpHeight * volumeSlider.value;
        }

        if (Input.GetKey(KeyCode.R)) SceneManager.LoadScene("Environment");
        if (Input.GetKey(KeyCode.Escape)) Application.Quit();
    }

    public void OnPausePress()
    {
        if (!paused)
        {
            pauseButton.image.sprite = pauseButtonImages[1];
            paused = true;

            player.GetComponent<RunnerMovingScripts>().enabled = false;
            player.GetComponent<Knight>().enabled = true;
        }
        else
        {
            pauseButton.image.sprite = pauseButtonImages[0];
            paused = false;

            player.GetComponent<Knight>().enabled = false;
            player.GetComponent<RunnerMovingScripts>().enabled = true;
        }
    }

    public void OnVolumePress()
    {
        if (!volumeOpen)
        {
            volumeSlider.gameObject.SetActive(true);
            volumeOpen = true;
        }
        else
        {
            volumeSlider.gameObject.SetActive(false);
            volumeOpen = false;
        }
    }
}

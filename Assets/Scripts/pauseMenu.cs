using UnityEngine;
using UnityEngine.UI;

public class pauseMenu : MenuScript
{
    public bool pause = false;
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
    }
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pause = !pause;
            Time.timeScale = pause ? 0 : 1;
            this.gameObject.GetComponent<Canvas>().enabled = pause;      
        }
    }

}

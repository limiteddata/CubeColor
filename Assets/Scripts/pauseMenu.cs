using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class pauseMenu : MenuScript
{
    public bool pause = false;
    public Slider volumeSlider;
    
    public GameObject menu;

    private void Awake()
    {
        inputActions = new InputMaster();
        inputActions.New_UI.Pause.performed += ctx => pauseGame();
        inputActions.New_UI.LeftClick.performed += ctx => onClick();
        inputActions.New_UI.Move.performed += ctx => onMove();
    }
    public void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
    }
    public void pauseGame()
    {
        pause = !pause;
        Time.timeScale = pause ? 0 : 1;
        menu.SetActive(pause);
        
    }


}

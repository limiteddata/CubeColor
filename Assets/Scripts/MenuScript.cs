using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    
    public AudioMixer audioMixer;
    public InputMaster inputActions;
    public GameObject selectObject;
    int controller;
    private void Awake()
    {
        inputActions = new InputMaster();
        inputActions.New_UI.LeftClick.performed += ctx => onClick();
        inputActions.New_UI.Move.performed += ctx => onMove();
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void SceneSwitch(string scene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("masterVolume", volume);
        audioMixer.SetFloat("masterMixer", volume);
    }
    public void onMove()
    {
        controller++;
        if (controller == 1)
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(selectObject);
            
    }
    public void onClick()
    {
        EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
        controller = 0;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

}

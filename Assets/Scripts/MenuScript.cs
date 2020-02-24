using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    
    public AudioMixer audioMixer;
    
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
}

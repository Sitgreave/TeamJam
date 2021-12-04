using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SoundOff()
    {
        PlayerPrefs.SetInt("SoundNeed", 0);
    }

    public void SoundOn()
    {
        PlayerPrefs.SetInt("SoundNeed", 1);
    }
}

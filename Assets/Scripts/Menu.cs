using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI currentSpeedText;
    public TextMeshProUGUI currentSizeText;
    public TextMeshProUGUI currentColorText;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Title");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Quit()
    {
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    void Start()
    {
        currentSpeedText.text = "Current Speed: "+ KeepData.playerSpeed;
        currentSizeText.text = "Current Size: "+ KeepData.PlayerSizePassText;
        currentColorText.text = "Current Color: " + KeepData.PlayerColorPassText;
        Debug.Log(KeepData.PlayerSizePassText);
        Debug.Log(KeepData.PlayerColorPassText);
        Debug.Log(KeepData.playerSpeed);
    }
}

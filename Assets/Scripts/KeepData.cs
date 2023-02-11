using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeepData : MonoBehaviour
{
    public TMP_Dropdown SizeDropdown;
    public TextMeshProUGUI SizeText;
    public static int PlayerSizeNumber = 0;
    private float size = 1.0f;
    public static float passSize = 1.0f;

    public TMP_Dropdown ColorDropdown;
    public TextMeshProUGUI ColorText;
    public static int PlayerColor = 0;

    public GameObject PlayerSphere;

    public Slider mySlider;
    public TextMeshProUGUI SpeedText;
    public static float playerSpeed = 1f;


    public static string PlayerColorPassText = "Blue";//for Pass
    public static string PlayerSizePassText = "Small Ball";//for Pass

    // Start is called before the first frame update
    void Start()
    {
        SizeDropdown.value = PlayerSizeNumber;
        SizeText.text = "Size: " + SizeDropdown.options[SizeDropdown.value].text;
        PlayerSizePassText = SizeDropdown.options[SizeDropdown.value].text;
        SetSize(SizeDropdown);

        ColorDropdown.value = PlayerColor;
        ColorText.text = "Color: " + ColorDropdown.options[ColorDropdown.value].text;
        PlayerColorPassText = ColorDropdown.options[ColorDropdown.value].text;
        SetColor(ColorDropdown);

        mySlider.value = playerSpeed;
    }

    public void SetColor(TMP_Dropdown sender)
    {
        switch (sender.value) 
        {
            case 0:
                ColorText.text = "Color: " + sender.options[0].text;
                PlayerSphere.GetComponent<Renderer>().material.color = Color.blue;
                break;
            case 1:
                ColorText.text = "Color: " + sender.options[1].text;
                PlayerSphere.GetComponent<Renderer>().material.color = Color.red;
                break;
            case 2:
                ColorText.text = "Color: " + sender.options[2].text;
                PlayerSphere.GetComponent<Renderer>().material.color = Color.green;
                break;
            case 3:
                ColorText.text = "Color: " + sender.options[3].text;
                PlayerSphere.GetComponent<Renderer>().material.color = Color.black;
                break;
        }
    }

    public void UpdateColor(TMP_Dropdown sender)
    {
        PlayerColor = sender.value;
        SetColor(sender);
        Debug.Log("Color: " + sender.options[sender.value].text);
        sender.value = PlayerColor;
        PlayerColorPassText = ColorDropdown.options[ColorDropdown.value].text;
    }

    public void SetSize(TMP_Dropdown sender)
    {
        switch (sender.value) 
        {
            case 0:
                size = 1.0f;
                SizeText.text = "Size: Small";
                passSize = size;
                break;
            case 1:
                size = 2.0f;
                SizeText.text = "Size: Medium";
                passSize = size;
                break;
            case 2:
                size = 3.0f;
                SizeText.text = "Size: Large";
                passSize = size;
                break;
        }
        PlayerSphere.transform.localScale = new Vector3(size, size, size);
        PlayerSphere.transform.localPosition = new Vector3(PlayerSphere.transform.localPosition.x, 0.5f * size, PlayerSphere.transform.localPosition.z);
    }

    public void UpdateSize(TMP_Dropdown sender)
    {
        PlayerSizeNumber = sender.value;
        SetSize(sender);
        Debug.Log("Size: " + sender.options[sender.value].text);
        sender.value = PlayerSizeNumber;
        PlayerSizePassText = SizeDropdown.options[SizeDropdown.value].text;
    }

    public void SpeedSlider()
    {
        SpeedText.text = "Speed: " + mySlider.value;
        Debug.Log(mySlider.value);
        playerSpeed = mySlider.value;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Title");
    }
}

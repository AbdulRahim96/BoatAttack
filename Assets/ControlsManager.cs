using System.Collections;
using System.Collections.Generic;
using BoatAttack;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class ControlsManager : MonoBehaviour
{
    public static ControlsManager instance;
    public Joystick leftJoyStick, rightJoyStick;
    public Slider leftSlider, rightSlider;
    public Dropdown myDropdown;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        int val = PlayerPrefs.GetInt("controls", 0);
        ChangeControls(val);
        myDropdown.value = val; // Set the second option as default
        myDropdown.RefreshShownValue(); // Update the visual display
    }

    void DisableAll()
    {
        leftJoyStick.gameObject.SetActive(false);
        rightJoyStick.gameObject.SetActive(false);
        leftSlider.gameObject.SetActive(false);
        rightSlider.gameObject.SetActive(false);
    }

    public void ChangeControls(int val)
    {
        DisableAll();
        switch (val)
        {
            case 0:
                rightSlider.gameObject.SetActive(true);
                leftJoyStick.gameObject.SetActive(true);
                break;

            case 1:
                rightJoyStick.gameObject.SetActive(true);
                leftJoyStick.gameObject.SetActive(true);
                break;

            case 2:
                rightSlider.gameObject.SetActive(true);
                leftSlider.gameObject.SetActive(true);
                break;

            case 3:
                rightJoyStick.gameObject.SetActive(true);
                break;

            case 4:
                leftJoyStick.gameObject.SetActive(true);
                break;
        }
        PlayerPrefs.SetInt("controls", val);
        FindObjectOfType<HumanController>().value = val;
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}

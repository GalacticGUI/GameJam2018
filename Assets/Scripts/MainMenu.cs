using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {

    public GameObject startButton;
    public GameObject optionsButton;
    public GameObject creditsButton;
    public GameObject exitButton;
    public GameObject menuBackground;
    public GameObject creditsBackground;
    public GameObject popupScreen;

    private bool isPopup = false;

    void Start () {
        EventSystem.current.SetSelectedGameObject(startButton);
    }
	
	void Update () {
        var selectedObject = EventSystem.current.currentSelectedGameObject;
        if (selectedObject == null) {
            EventSystem.current.SetSelectedGameObject(startButton);
        }

        if (isPopup = true && Input.GetButtonDown("Cancel")) {
            ShowButtons();
        }
    }

    private void OnDisable() {
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame() {
        Debug.Log("Exiting Game!");
        Application.Quit();
    }

    public void Options() {
        HideButtons();
        popupScreen.SetActive(true);
        isPopup = true;
    }

    public void Credits() {
        HideButtons();
        menuBackground.SetActive(false);
        creditsBackground.SetActive(true);
        isPopup = true;
    }

    public void HideButtons() {
        startButton.SetActive(false);
        optionsButton.SetActive(false);
        creditsButton.SetActive(false);
        exitButton.SetActive(false);
    }

    public void ShowButtons() {
        menuBackground.SetActive(true);
        startButton.SetActive(true);
        optionsButton.SetActive(true);
        creditsButton.SetActive(true);
        exitButton.SetActive(true);
        popupScreen.SetActive(false);
        creditsBackground.SetActive(false);
        isPopup = false;
    }

}

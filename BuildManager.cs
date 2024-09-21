using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public List<ItemSlot> itemSlots;
    public List<DragDrop> dragItems;

    public Button buildButton;
    public Button backButton;

    public GameObject winPopupPanel;
    public GameObject tryAgainPopupPanel;

    public Button winPopupNextLevelButton;
    public Button tryAgainPopupBackButton;

    private void Start()
    {
        buildButton.onClick.AddListener(OnBuildButtonClick);
        backButton.onClick.AddListener(OnBackButtonClick);
        winPopupNextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
        tryAgainPopupBackButton.onClick.AddListener(OnBackButtonClick);

        winPopupPanel.SetActive(false); // Ensure the win popup is initially hidden
        tryAgainPopupPanel.SetActive(false); // Ensure the try again popup is initially hidden
    }

    private void OnBuildButtonClick()
    {
        bool allCorrect = true;

        foreach (ItemSlot slot in itemSlots)
        {
            if (!slot.isCorrectItemPlaced)
            {
                allCorrect = false;
                break;
            }
        }

        if (allCorrect)
        {
            ShowWinPopup();
        }
        else
        {
            ShowTryAgainPopup();
        }
    }

    private void OnBackButtonClick()
    {
        foreach (DragDrop item in dragItems)
        {
            item.ResetPosition();
        }

        foreach (ItemSlot slot in itemSlots)
        {
            slot.isCorrectItemPlaced = false;
        }

        winPopupPanel.SetActive(false); // Hide the win popup when resetting
        tryAgainPopupPanel.SetActive(false); // Hide the try again popup when resetting
    }

    private void ShowWinPopup()
    {
        winPopupPanel.SetActive(true);
    }

    private void ShowTryAgainPopup()
    {
        tryAgainPopupPanel.SetActive(true);
    }

    private void OnNextLevelButtonClick()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        switch (currentSceneName)
        {
            case "Level1_DragDrop":
                SceneManager.LoadScene("Level2_DragDrop");
                break;
            case "Level2_DragDrop":
                SceneManager.LoadScene("Level3_DragDrop1");
                break;
            case "Level3_DragDrop1":
                SceneManager.LoadScene("Level4_DragDrop1");
                break;
            case "Level4_DragDrop1":
                // Handle what happens after Level 4 is completed, if needed
                Debug.Log("Game Completed!");
                break;
            default:
                Debug.LogError("Unexpected level name: " + currentSceneName);
                break;
        }
    }
}

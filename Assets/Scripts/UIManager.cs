using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI livesText;

    public void ShowGameOverPanel(int lives)
    {
        gameOverPanel.SetActive(true);
    }

    public void HideGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }

    public void UpdateLiveText(int lives) 
    {
        livesText.text = $"{lives}";
    }
}

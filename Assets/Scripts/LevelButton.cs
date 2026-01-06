using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Button button;

    public void Setup(int levelNumber)
    {
        levelText.text = "Nivel " + levelNumber;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            Debug.Log("Nivel selectat: " + levelNumber);
        });
    }
}
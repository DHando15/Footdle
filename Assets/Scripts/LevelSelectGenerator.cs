using UnityEngine;

public class LevelSelectGenerator : MonoBehaviour
{
    [SerializeField] private LevelButton buttonPrefab;
    [SerializeField] private Transform contentParent;
    [SerializeField] private int totalLevels = 100;

    void Start()
    {
        GenerateLevels();
    }

    void GenerateLevels()
    {
        for (int i = 1; i <= totalLevels; i++)
        {
            LevelButton btn = Instantiate(buttonPrefab, contentParent);
            btn.Setup(i);
        }
    }
}
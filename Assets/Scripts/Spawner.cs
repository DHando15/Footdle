using UnityEngine;
using UnityEngine.UI;

public class GridSpawner : MonoBehaviour
{
    public GameObject prefab;

    public int columns = 5;   // 5 pe linie
    public int rows = 5;      // 5 linii

    public Vector2 startPosition = new Vector2(-400, 300);

    public float offsetX = 100f; // distanța pe X
    public float offsetY = 100f; // distanța pe Y (3.75 -> 3.05)

    public Vector3 objectScale =  Vector3.one;

    void Start()
    {
        SpawnGrid();
    }

    void SpawnGrid()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            { 
                GameObject obj = Instantiate(prefab, transform);
                //RectTransmform rt = obj.GetComponent<RectTransform>();
                obj.transform.position = new Vector3(
                    startPosition.x + col * offsetX,
                    startPosition.y - row * offsetY,0f );

                obj.transform.localScale = objectScale;
            }
        }
    }
}

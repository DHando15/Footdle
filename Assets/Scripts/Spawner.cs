using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public GameObject prefab;

    public int columns = 5;   // 5 pe linie
    public int rows = 5;      // 5 linii

    public Vector2 startPosition = new Vector2(-1.93f, 3.75f);

    public float offsetX = 0.94f; // distanța pe X
    public float offsetY = 0.70f; // distanța pe Y (3.75 -> 3.05)

    public Vector2 objectScale = new Vector2(0.05312836f, 0.05450198f);

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
                Vector3 pos = new Vector3(
                    startPosition.x + col * offsetX,
                    startPosition.y - row * offsetY,
                    0
                );

                GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
                obj.transform.localScale = objectScale;
            }
        }
    }
}

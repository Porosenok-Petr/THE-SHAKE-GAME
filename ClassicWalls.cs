using UnityEngine;

public class ClassicWalls : MonoBehaviour
{
    public GameObject wallPrefab;

    void Start()
    {
        float size = wallPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        Camera cam = Camera.main;

        float h = cam.orthographicSize * 2;
        float w = h * cam.aspect;

        int cols = Mathf.CeilToInt(w / size);
        int rows = Mathf.CeilToInt(h / size);

        Vector3 bottomLeft = cam.transform.position - new Vector3(w / 2, h / 2);

        // Стены (верх/низ)
        for (int x = 0; x < cols; x++)
        {
            float xPos = bottomLeft.x + (x + 0.5f) * (w / cols);
            Instantiate(wallPrefab, new Vector3(xPos, bottomLeft.y + h - size / 2, 0), Quaternion.identity, transform); // верх
            Instantiate(wallPrefab, new Vector3(xPos, bottomLeft.y + size / 2, 0), Quaternion.identity, transform); // низ
        }

        // Стены (лево/право, без углов)
        for (int y = 1; y < rows - 1; y++)
        {
            float yPos = bottomLeft.y + (y + 0.5f) * (h / rows);
            Instantiate(wallPrefab, new Vector3(bottomLeft.x + size / 2, yPos, 0), Quaternion.identity, transform); // лево
            Instantiate(wallPrefab, new Vector3(bottomLeft.x + w - size / 2, yPos, 0), Quaternion.identity, transform); // право
        }
    }
}

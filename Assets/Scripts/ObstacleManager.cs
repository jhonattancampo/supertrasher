using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    void Start()
    {
        LoadObstaclePrefabs();
    }

    void LoadObstaclePrefabs()
    {
        obstaclePrefabs = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            obstaclePrefabs[i] = transform.GetChild(i).gameObject;
        }

        Debug.Log("Obstacle Prefabs Loaded: " + obstaclePrefabs.Length);
    }
}

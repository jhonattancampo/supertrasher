using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 5f;
    private Material backgroundMaterial;
    private Vector2 offset;

    void Start()
    {
        backgroundMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(0, 0);
    }

    void Update()
    {
        offset.x += scrollSpeed * Time.deltaTime;
        backgroundMaterial.mainTextureOffset = offset;
    }
}

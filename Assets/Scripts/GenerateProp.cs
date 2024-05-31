using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateProp : MonoBehaviour
{
    public List<GameObject> props;
    public float propSpeed = 1f;
    public float propSpawnTime = 5f;
    private GameObject instantiatedProp;
    private float timeUntilPropSpawn;

    void Start()
    {
        // No inicies la corutina aquí
    }

    void Update()
    {
        if (GameManager.Instance.isPlaying)
        {
            SpawnLoop();
        }

        if (instantiatedProp != null)
        {
            // Mueve el objeto hacia la izquierda
            instantiatedProp.transform.position += Vector3.left * propSpeed * Time.deltaTime;

            // Elimina el objeto al llegar a la posición asignada
            if (instantiatedProp.transform.position.x < -12)
            {
                Destroy(instantiatedProp);
            }
        }
    }

    private void SpawnLoop()
    {
        timeUntilPropSpawn += Time.deltaTime;
        if (timeUntilPropSpawn >= propSpawnTime)
        {
            StartCoroutine(SpawnProps());
            timeUntilPropSpawn = 0f;
        }
    }

    IEnumerator SpawnProps()
    {
        int rN = Random.Range(0, props.Count);
        instantiatedProp = Instantiate(props[rN], transform.position, transform.rotation);
        Destroy(instantiatedProp, 5f);

        yield return new WaitForSeconds(5);
    }
}
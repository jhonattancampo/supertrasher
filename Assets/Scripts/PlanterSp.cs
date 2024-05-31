using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlanter : MonoBehaviour
{
    public GameObject planterPrefab; 
    public float planterSpeed = 1f; 
    private GameObject instantiatedplanterPrefab; 
    private Coroutine spawnCoroutine;

    void Start()
    {
        // Do not start the coroutine here
    }

    public void StartSpawning()
    {
        if (spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(SpawnPlanterPrefab());
        }
    }

    // Ciclo de spawn
    IEnumerator SpawnPlanterPrefab()
    {
        while (true)
        {
            instantiatedplanterPrefab = Instantiate(planterPrefab, transform.position, transform.rotation);

            // Destruye el objeto después de 5 segundos
            Destroy(instantiatedplanterPrefab, 5f);

            // Genera el objeto en el tiempo asignado
            yield return new WaitForSeconds(5);
        }
    }

    void Update()
    {
        if (instantiatedplanterPrefab != null)
        {
            // Mueve el objeto hacia la izquierda
            instantiatedplanterPrefab.transform.position += Vector3.left * planterSpeed * Time.deltaTime;
        }
    }
}

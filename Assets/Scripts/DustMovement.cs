using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject dustPrefab; 
    public float dustSpeed = 1f; 
    public float destroyTime = 4f; 
    private GameObject instantiatedDustPrefab; 
    private Coroutine spawnCoroutine;

    void Start()
    {
        // Do not start the coroutine here
    }

    public void StartSpawning()
    {
        if (spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(SpawnDustPrefab());
        }
    }

    // Ciclo de spawn
    IEnumerator SpawnDustPrefab()
    {
        while (true)
        {
            instantiatedDustPrefab = Instantiate(dustPrefab, transform.position, transform.rotation);

            // Destruye el objeto después de 'destroyTime' segundos
            Destroy(instantiatedDustPrefab, destroyTime);

            // Tiempo de espera para generar el siguiente sprite
            yield return new WaitForSeconds(4);
        }
    }

    void Update()
    {
        if (instantiatedDustPrefab != null)
        {
            // Mueve el objeto hacia la izquierda
            instantiatedDustPrefab.transform.position += Vector3.left * dustSpeed * Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlanter : MonoBehaviour
{
    public GameObject planterPrefab; 
    public float planterSpeed = 1f; 
    private GameObject instantiatedplanterPrefab; 

    
    void Start()
    {
        StartCoroutine(SpawnPlanterPrefab());
    }

    // Ciclo de spawn
    IEnumerator SpawnPlanterPrefab()
    {
        while (true)
        {
            instantiatedplanterPrefab = Instantiate(planterPrefab, transform.position, transform.rotation);

            // Destruye el objeto después del tiempo asignado
            Destroy(instantiatedplanterPrefab, 5f);
            //genera el objeto en el tiempo asignado
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




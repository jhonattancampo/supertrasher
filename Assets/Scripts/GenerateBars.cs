using System.Collections;
using UnityEngine;

public class GenerateBars : MonoBehaviour
{
    public GameObject barPrefab; 
    public float barSpeed = 1f; 
    private GameObject instantiatedBarPrefab; 

    void Start()
    {
        StartCoroutine(SpawnBarPrefab());
    }

    // Ciclo de spawn
    IEnumerator SpawnBarPrefab()
    {
        while (true)
        {
            instantiatedBarPrefab = Instantiate(barPrefab, transform.position, transform.rotation);

            // Destruye el objeto 
            Destroy(instantiatedBarPrefab, 10f);

            yield return new WaitForSeconds(10); // Espera para general el siguiente
        }
    }

    void Update()
    {
        if (instantiatedBarPrefab != null)
        {
            // Mueve el objeto hacia la izquierda
            instantiatedBarPrefab.transform.position += Vector3.left * barSpeed * Time.deltaTime;
        }
    }
}



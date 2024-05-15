using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateProp : MonoBehaviour
{
    public List<GameObject> props;
    public float propSpeed = 1f;
    private GameObject instantiatedProp; 

    void Start()
    {
        StartCoroutine(SpawnProps());
    }
    //Ciclo de spawn
    IEnumerator SpawnProps()
    {
        while (true)
        {
            int rN = Random.Range(0, props.Count);
            instantiatedProp = Instantiate(props[rN], transform.position, transform.rotation);

            yield return new WaitForSeconds(5); 
        }
    }

    void Update()
    {
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
}
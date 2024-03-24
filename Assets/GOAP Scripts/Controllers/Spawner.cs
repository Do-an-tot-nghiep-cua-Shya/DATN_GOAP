using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject patientPrefab;
    public int numOfPatients;
    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < numOfPatients; i++)
        {
            Instantiate(patientPrefab, this.transform.position, Quaternion.identity);
        }
        Invoke("SpawnPatient", Random.Range(2,8));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPatient()
    {
        Instantiate(patientPrefab,this.transform.position, Quaternion.identity);
        Invoke("SpawnPatient", Random.Range(2, 8));
    }
}

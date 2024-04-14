using UnityEngine;

public class Spawner : MonoBehaviour
{
    private static Spawner instance;
    public GameObject patientPrefab;
    public int numOfPatients;
    [SerializeField]
    private int limitOfPatients = 10;
    public int currentPatients;

    public static Spawner Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<Spawner>();
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        for (int i = 0; i < numOfPatients; i++)
        {
            Instantiate(patientPrefab, this.transform.position, Quaternion.identity);
            currentPatients++;
        }
        Invoke("SpawnPatient", Random.Range(12, 15));
    }

    void SpawnPatient()
    {
        if (currentPatients < limitOfPatients)
        {
            Instantiate(patientPrefab, this.transform.position, Quaternion.identity);
            currentPatients++;
            Invoke("SpawnPatient", Random.Range(12, 15));
        }
    }
}

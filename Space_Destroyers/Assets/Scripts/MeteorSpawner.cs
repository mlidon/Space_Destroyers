using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject[] meteorPrefabs; // Array de meteoritos
    public float spawnMinY = 5f;        // Posición superior de spawn (arriba de la pantalla)
    public float spawnMaxX = 9f;        // Límite horizontal
    public float spawnMinX = -9f;

    public float spawnIntervalMin = 2f; // Tiempo mínimo entre oleadas
    public float spawnIntervalMax = 3f; // Tiempo máximo entre oleadas
    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    System.Collections.IEnumerator SpawnWave()
    {
        while (true)
        {
            int meteorsToSpawn = Random.Range(1,3); // 2 a 3 meteoritos
            for (int i = 0; i < meteorsToSpawn; i++)
            {
                SpawnMeteor();
            }

            float waitTime = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(waitTime);
        }
    }

    void SpawnMeteor()
    {
        // Posición aleatoria en horizontal
        float posX = Random.Range(spawnMinX, spawnMaxX);
        Vector3 spawnPos = new Vector3(posX, spawnMinY, 0);

        // Elegir un meteorito aleatorio del array
        int index = Random.Range(0, meteorPrefabs.Length);
        Instantiate(meteorPrefabs[index], spawnPos, Quaternion.identity);
    }
}

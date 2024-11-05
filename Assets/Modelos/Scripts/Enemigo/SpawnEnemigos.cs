 using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    public GameObject[] enemigos;
    public float tiempoSpawn = 1f;
    public int cantSpawn = 5;
    public float rangoSpawn = 10f;

    private Terrain terreno;

    private void Start()
    {
        terreno = Terrain.activeTerrain;
        InvokeRepeating("Spawn", tiempoSpawn, tiempoSpawn);
    }

    private void Spawn()
    {
        for (int i = 0; i < cantSpawn; i++)
        {
            Vector3 randomPos = posRandom();
            GameObject prefabAletorio = enemigos[Random.Range(0, enemigos.Length)];
            Instantiate(prefabAletorio, randomPos, Quaternion.identity);
        }
    }

    private Vector3 posRandom()
    {
        float posRandomX = Random.Range(0f, terreno.terrainData.size.x);
        float posRandomZ = Random.Range(0f, terreno.terrainData.size.y);
        float alturaTerreno = terreno.SampleHeight(new Vector3(posRandomX, -18.95661f, posRandomZ));

        return new Vector3(posRandomX, alturaTerreno, posRandomZ);
    }
}

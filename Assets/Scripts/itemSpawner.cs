using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    [SerializeField] int checkpointSpawnDelay = 10;//variable que contiene valor de retraso.
    [SerializeField] float spawnRadius = 10;//radio limite para la generacion de instancias.
    [SerializeField] GameObject checkPointPrefab;//esta es la instancia que sera generada.
    [SerializeField] GameObject[] powerUpPrefab;
    [SerializeField] int powerUpSpawnDelay = 12;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCheckponitRoutine());//creamos una especie de funcion de cuenta regresiva con este codigo.
        StartCoroutine(SpawnPowerUpRoutine());
    }

    IEnumerator SpawnCheckponitRoutine()//con esta linea de codigo activamos la cuenta regresiva.
    {
        while (true)//hacemos un ciclo while para que sea infinito.
        {
            yield return new WaitForSeconds(checkpointSpawnDelay);// hacemos un retraso, en este caso es de 10 segunodos.
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;// creamos un radio y al mismo tiempo un hacemos que un funcion aleatoria.
            Instantiate(checkPointPrefab, randomPosition, Quaternion.identity);//  creamos instancia de manera aleatoria gracias el codigo anterior, al mismo tiempo las instancias son limitadas a solo aparecer en el radio creado. Cuando implementamos Quaternion, significa rotacion por defecto.
        }
    }
    IEnumerator SpawnPowerUpRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(powerUpSpawnDelay);
                Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
                int random = Random.Range(0, powerUpPrefab.Length);// esttamos creando una variable llamada random que tendra como valor un numero completamente aleatorio.
                Instantiate(powerUpPrefab[random], randomPosition, Quaternion.identity);
            }
        }
}

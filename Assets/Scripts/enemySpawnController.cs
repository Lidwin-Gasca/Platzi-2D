using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnController : MonoBehaviour
{
    [SerializeField]  GameObject[] enemyPrefab;
    [Range (1, 10)] [SerializeField] float spawnRate = 1;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNewEnemy());
    }

    // Update is called once per frame
    IEnumerator SpawnNewEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1/spawnRate); // cada segundo devidido entre el valor de SpawnRate, dara como resultado los enemigos que apareceran en la pantalla (juego).
            float random = Random.Range(0.0f, 1.0f); //estamos inicializando una vareable llamda random, cuyo valor es el alcance de casi cero pero nunca cero, y casi 1 pero nunca 1, en terminos matematicos saria asi => (0.0, 1.0), alcance significa "range",  usamos el metodo "Random" junto a el metodo "Range".
/// CONDICIONAL if:    en el siguiente ciclo, tomamos
            if (random < gameManager.Instance.difficulty * 0.1f) //Esta es la probabilidad de los enemyPrefab, la probabilidad dependera de el valor de "difilcuty" multiplicado por  "0.1f"
            {
                Instantiate(enemyPrefab[0]);
            }
            else
            {
                Instantiate(enemyPrefab[1]);
            }
        }
    }
}

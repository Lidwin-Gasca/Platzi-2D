using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    [SerializeField] GameObject checkPointPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCheckponitRoutine());
    }

    IEnumerator SpawnCheckponitRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            Vector2 randomPosition = Random.insideUnitCircle * 5;
            Instantiate(checkPointPrefab, randomPosition, Quaternion.identity);
        }
    }
}

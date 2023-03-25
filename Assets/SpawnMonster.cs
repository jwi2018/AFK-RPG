using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnMonster : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;

    private IEnumerator SpawnMonsters()
    {
        while (true)
        {
            int monsterCount = Random.Range(1, 5); // 1~4개의 몬스터를 랜덤하게 스폰합니다.
            for (int i = 0; i < monsterCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f), 0);
                Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
            }
            yield return new WaitForSeconds(5f); // 5초마다 몬스터를 스폰합니다.
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnMonsters());
    }
}


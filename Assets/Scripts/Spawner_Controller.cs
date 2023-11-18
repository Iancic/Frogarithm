using System.Collections;
using System.Drawing;
using TMPro;
using UnityEngine;

public class Spawner_Controller : MonoBehaviour
{
    private float horizontal_Loc;
    private float vertical_Loc;
    public GameObject spawnable, spawnable_quest;
    public float spawnrate, spawnrate_quest;

    void Start()
    {
        StartCoroutine(Spawn_Numbers());
        StartCoroutine(Spawn_Quest());
    }
    IEnumerator Spawn_Numbers()
    {
        while (true)
        {
            horizontal_Loc = UnityEngine.Random.Range(-50f, 50f);
            vertical_Loc = UnityEngine.Random.Range(0f, 60f);

            Instantiate(spawnable, new Vector3(horizontal_Loc, 1f, vertical_Loc), Quaternion.identity);

            spawnrate = UnityEngine.Random.Range(4f, 8f);

            yield return new WaitForSeconds(spawnrate);
        }
    }

    IEnumerator Spawn_Quest()
    {
        while (true)
        {
            horizontal_Loc = UnityEngine.Random.Range(-50f, 50f);
            vertical_Loc = UnityEngine.Random.Range(0f, 60f);

            Instantiate(spawnable_quest, new Vector3(horizontal_Loc, 1f, vertical_Loc), Quaternion.identity);

            spawnrate_quest = 30f;

            yield return new WaitForSeconds(spawnrate_quest);
        }
    }
}

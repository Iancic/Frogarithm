using System.Collections;
using System.Drawing;
using TMPro;
using UnityEngine;

public class Spawner_Controller : MonoBehaviour
{
    private float horizontal_Loc;
    private float vertical_Loc;
    public GameObject spawnable, spawnable_quest, spawnable_solution;
    private float spawnrate = 3.5f, spawnrate_quest = 8f;

    public static Spawner_Controller Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    //Singleton Workflow

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

            yield return new WaitForSeconds(spawnrate);
        }
    }

    public IEnumerator Spawn_Solution()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(1f, 1.5f));

        horizontal_Loc = UnityEngine.Random.Range(-50f, 50f);
        vertical_Loc = UnityEngine.Random.Range(0f, 60f);

        Instantiate(spawnable_solution, new Vector3(horizontal_Loc, 1f, vertical_Loc), Quaternion.identity);
    }

    public void Spawn_3_Numbers()
    {
        for (int i = 0; i < 3; i++)
        {
        horizontal_Loc = UnityEngine.Random.Range(-50f, 50f);
        vertical_Loc = UnityEngine.Random.Range(0f, 60f);

        Instantiate(spawnable, new Vector3(horizontal_Loc, 1f, vertical_Loc), Quaternion.identity);
        }
    }

    IEnumerator Spawn_Quest()
    {
        while (true)
        {
            horizontal_Loc = UnityEngine.Random.Range(-50f, 50f);
            vertical_Loc = UnityEngine.Random.Range(0f, 60f);

            Instantiate(spawnable_quest, new Vector3(horizontal_Loc, 1f, vertical_Loc), Quaternion.identity);

            yield return new WaitForSeconds(spawnrate_quest);
        }
    }
}

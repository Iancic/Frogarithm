using System.Collections;
using System.Drawing;
using TMPro;
using UnityEngine;

public class Spawner_Controller : MonoBehaviour
{
    private float horizontal_Loc;
    private float vertical_Loc;
    public GameObject spawnable;
    public float spawnrate = 6f;

    void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            horizontal_Loc = Random.Range(-50f, 50f);
            vertical_Loc = Random.Range(0f, 60f);

            Instantiate(spawnable, new Vector3(horizontal_Loc, 1f, vertical_Loc), Quaternion.identity);

            spawnrate = Random.Range(1f, 3f);

            yield return new WaitForSeconds(spawnrate);
        }
    }
}

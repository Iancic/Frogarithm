using System.Collections;
using UnityEngine;

public class Spawner_Controller : MonoBehaviour
{
    private float horizontal_Loc;
    private float vertical_Loc;
    public GameObject spawnable;

    public float spawnrate = 2f;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {

    }
    
    IEnumerator Spawn()
    {
        while (true)
        {
            horizontal_Loc = Random.Range(-50f, 50f);
            vertical_Loc = Random.Range(0f, 60f);

            Instantiate(spawnable, new Vector3(horizontal_Loc, 0f, vertical_Loc), Quaternion.identity);

            yield return new WaitForSeconds(spawnrate);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairContainer : MonoBehaviour
{
    /**¶¥±èprefab*/
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateBlock", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateBlock()
    {
        float randomX = Random.Range(-1.5f, 1.5f);
        GameObject block = Instantiate(prefab, new Vector2(randomX, -2), Quaternion.identity);
        block.transform.parent = this.gameObject.transform;
    }
}

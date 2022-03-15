using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemCrative : MonoBehaviour
{
    [SerializeField] GameObject[] ItemPrefab;
    [SerializeField] float seconSpanw = 0.5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;

    void Start()
    {
        StartCoroutine(ItemSpanw());
    }

    IEnumerator ItemSpanw()
    {
        while (true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(ItemPrefab[Random.Range(0, ItemPrefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(seconSpanw);
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}

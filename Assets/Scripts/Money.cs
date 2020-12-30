using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Moneys;
    public int MoneyChance;
    // Start is called before the first frame update
    void Start()
    {
        Moneys.SetActive(Random.Range(0, 101) <= MoneyChance);
    }
}

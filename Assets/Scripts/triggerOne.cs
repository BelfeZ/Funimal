using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerOne : MonoBehaviour
{
    [SerializeField] private GameObject triggerOn;
    [SerializeField] private GameObject objectOne;
    [SerializeField] private GameObject objectTwo;
    [SerializeField] private GameObject objectThree;

    private void Start()
    {
        triggerOn.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            triggerOn.SetActive(true);
            Destroy(objectOne);
            Destroy(objectTwo);
            Destroy(objectThree);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMap : MonoBehaviour
{
    [SerializeField] private int numberMap;
    [SerializeField] private GameObject trigger;
    private EncounterSwap _encounterSwap;
    void Start()
    {
        _encounterSwap = GameObject.FindGameObjectWithTag("Player").GetComponent<EncounterSwap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _encounterSwap.mapNumber = numberMap;
            if (trigger != null)
            {
                trigger.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }
}

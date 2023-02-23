using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private RectTransform checkPointBackGround;

    private SoundManager _soundManager;

    private void Awake()
    {
        checkPointBackGround.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
    }

    private void Start()
    {
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.tag == "Player")
        {
            StartCoroutine(PopUp());
            PlayerManager.lastCheckPointPos = transform.position;
        }
    }

    IEnumerator PopUp()
    {
        SoundManager.instace.Play(SoundManager.SoundName.UseItem);
        checkPointBackGround.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
        yield return new WaitForSeconds(1f);
        checkPointBackGround.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
    }
}

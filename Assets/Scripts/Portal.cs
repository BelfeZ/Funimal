using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public float x,y,z;

    IEnumerator OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            yield return new WaitForSeconds(1f);
            col.gameObject.transform.position = new Vector3(x,y,z);;
        }
    }

    /*private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.gameObject.transform.position = new Vector3(x,y,z);;
        }
    }*/
}

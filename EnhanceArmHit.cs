using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhanceArmHit : MonoBehaviour
{
    public GameObject self;
    public GameObject Explode;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("Enhace Sword hit");
            Destroy(self);
            Instantiate(Explode, transform);
        }
    }
}

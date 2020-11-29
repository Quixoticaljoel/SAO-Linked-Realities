using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileExplode : MonoBehaviour
{
    public GameObject Boom;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        Destroy(this.gameObject);
        Instantiate(Boom, transform.position, transform.rotation);
    }
    private void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enhancement hit");
            Destroy(this.gameObject);
            Instantiate(Boom, transform.position, transform.rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collision))]
public class TargetScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HitByBullet()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        /* hacky way to test if we've been hit by a bullet */
        if (collision.collider.tag == "BULLET")
        {
            HitByBullet();
        } else
        {
            Debug.Log("Collision with ???");
        }
    }
}

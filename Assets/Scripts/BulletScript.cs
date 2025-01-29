using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private int remainingLifespan = -1;

    void Start()
    {
    }

    public void BulletInitTimeout(float lifespanInSeconds)
    {
        remainingLifespan = (int)(lifespanInSeconds / Time.fixedDeltaTime);
    }

    void FixedUpdate()
    {
        if (remainingLifespan > 0)
        {
            remainingLifespan--;
        } else if (remainingLifespan == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet collided with " + collision.collider.gameObject.name);
        //collision.collider.gameObject.SendMessage("HitByBullet", SendMessageOptions.DontRequireReceiver);

        Destroy(gameObject);
    }
}

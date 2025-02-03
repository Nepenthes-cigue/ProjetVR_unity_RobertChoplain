using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int remainingLifespan = -1;

    public void BulletInitTimeout(float lifespanInSeconds)
    {
        /* Compute lifespan in fixed tick count */
        remainingLifespan = (int)(lifespanInSeconds / Time.fixedDeltaTime);
    }

    void FixedUpdate()
    {
        /**
         * On spawn, the remaining lifespan is negative, such that the
         * bullet doesn't do anything (hack to have the "prefab" not
         * destroy itself). The handgun is responsible for invoking
         * BulletInitTimeout() when instancing new bullets, which
         * sets it to a positive amount of fixed ticks.
         * 
         * Each fixed update, lifespan counter is decrement, and
         * the bullet destroys itself once counter reaches zero.
         */
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

        Destroy(gameObject);
    }
}

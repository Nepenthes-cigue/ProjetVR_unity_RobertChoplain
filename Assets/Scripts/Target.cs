using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collision))]
public class BulletTarget : MonoBehaviour
{
    /**
     * Function invoked when a bullet hits this object's collision box
     * This can be overriden by child classes.
     */
    protected virtual void HitByBullet()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        /**
         * Hacky way to check that what hit us is a bullet.
         * The bullet prefab is tagged with this such that
         * all instances will also have this tag.
         */
        if (collision.collider.tag == "BULLET")
        {
            HitByBullet();
        } else
        {
            Debug.Log("Collision with ???");
        }
    }
}

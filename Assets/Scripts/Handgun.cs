using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Handgun : MonoBehaviour
{
    public Transform muzzleTransform;
    public GameObject bulletPrefab;
    public float bulletForce = 10f;
    public float bulletLifespan = 3f;

    public Transform laserStartPoint;
    public LineRenderer laserRenderer;
    private bool laserEnabled = false;

    /* Using Update() to modify a LineRenderer is not recommended */
    private void LateUpdate()
    {
        RaycastHit hit;

        /* Disable / enable laser as required */
        laserRenderer.enabled = laserEnabled;
        if (!laserEnabled)
        {
            /* Laser is off - don't bother updating */
            return;
        }

        /* Set line starting point to laser's start point */
        laserRenderer.SetPosition(0, laserStartPoint.position);

        /* Try to find if we collide with something */
        if (Physics.Raycast(laserStartPoint.position, laserStartPoint.forward, out hit) && hit.collider)
        {
            /* Collided - set end point to object we hit */
            laserRenderer.SetPosition(1, hit.point);
        }
        else
        {
            /* Else there's nothing in front - set end point very far away */
            laserRenderer.SetPosition(1, laserStartPoint.position + laserStartPoint.forward * 1000);
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzleTransform.position, Quaternion.identity);
        bullet.transform.forward = muzzleTransform.forward.normalized;
        bullet.GetComponent<Rigidbody>().AddForce(muzzleTransform.forward.normalized * bulletForce, ForceMode.Impulse);

        /* Start counter for bullet to destroy itself after a while */
        bullet.SendMessage("BulletInitTimeout", bulletLifespan);
    }

    public void OnGrabEnter()
    {
        laserEnabled = true;
    }

    public void OnGrabRelease()
    {
        laserEnabled = false;
    }

    public void OnActivateEvent(ActivateEventArgs eventArgs)
    {
        FireBullet();
    }
}

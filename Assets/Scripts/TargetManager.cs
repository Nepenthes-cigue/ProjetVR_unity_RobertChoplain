using UnityEngine;

/* Inherit from BulletTarget to get the "hit by bullet" logic */
public class TargetManager : BulletTarget
{
    public GameObject targetPrefab;
    public GameObject[] targets;

    /* Respawn coordinates for all targets - saved upon start */
    private Vector3[] respawnPositions;
    private Quaternion[] respawnRotations;
    void Start()
    {
        respawnPositions = new Vector3[targets.Length];
        respawnRotations = new Quaternion[targets.Length];
        for (int i = 0; i < targets.Length; i++)
        {
            respawnPositions[i] = targets[i].transform.position;
            respawnRotations[i] = targets[i].transform.rotation;
        }
    }

    protected override void HitByBullet()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            GameObject target = targets[i];
            if (!target)
            {
                Debug.Log($"Target {i} no longer exists - respawning!");
                /* The target has been destroyed - respawn it */
                targets[i] = Instantiate(targetPrefab, respawnPositions[i], respawnRotations[i]);
            }
        }
    }
}

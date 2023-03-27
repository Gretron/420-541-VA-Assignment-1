using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    [SerializeField]
    GameObject EndPlate;

    public void TriggerEndPlate()
    {
        EndPlate.SetActive(true);
        EndPlate.GetComponent<EndPlate>().enabled = true;

        GameObject[] powerups = GameObject.FindGameObjectsWithTag("YellowPowerup");

        foreach(GameObject powerup in powerups) {
            Destroy(powerup.transform.parent.gameObject);
        }

        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePowerup : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    GameObject bluePowerupParticles;

    public void TriggerPowerup() 
    {
        Instantiate(bluePowerupParticles, transform.position, Quaternion.identity);

        transform.parent.gameObject.SetActive(false);

        Invoke(nameof(Reactivate), 30);
    }

    void Reactivate() {
        transform.parent.gameObject.SetActive(true);
    }
}

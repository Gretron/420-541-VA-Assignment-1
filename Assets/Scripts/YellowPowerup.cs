using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPowerup : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    GameObject yellowPowerupParticles;

    public void TriggerPowerup() 
    {
        Instantiate(yellowPowerupParticles, transform.position, Quaternion.identity);

        GameManager.Instance.IncreaseScore(50);
        Destroy(transform.parent.gameObject);
    }
}

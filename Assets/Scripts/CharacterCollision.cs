using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCollision : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    CharacterMovement characterMovement;

    // Start is called before the first frame update
    void Start()
    {
        characterMovement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "BluePowerup") {
            other.gameObject.GetComponent<BluePowerup>().TriggerPowerup();
            characterMovement.canDoubleJump = true;
        } else if (other.gameObject.tag == "YellowPowerup") {
            other.gameObject.GetComponent<YellowPowerup>().TriggerPowerup();
        } else if (other.gameObject.tag == "Respawn") {
            GameManager.Instance.ResetScore();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "EndGoal") {
            other.gameObject.GetComponent<EndGoal>().TriggerEndPlate();
        } else if (other.gameObject.tag == "EndPlate") {
            GameManager.Instance.ResetScore();
            GameManager.Instance.LoadNextScene();
        }
    }
}

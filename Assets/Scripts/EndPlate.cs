using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlate : MonoBehaviour
{
    [SerializeField]
    GameObject EndPlateScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() 
    {
        EndPlateScore.GetComponent<TextMesh>().text = GameManager.Instance.GetScore().ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

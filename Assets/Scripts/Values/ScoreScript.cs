using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ScoreScript : MonoBehaviour
{
    public static int scoreValue = 0;
    public Text score; // Thay thế TextMeshProUGUI bằng Text

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        if (score == null)
        {
            Debug.LogError("Text component is missing. Please attach a Text component to the GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreValue;
    }
    public static void ResetScore()
    {
        scoreValue=0;
    }
}

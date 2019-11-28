using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{

    public Text scoreTexT;
    public Time timer;
    // Update is called once per frame
    void Update()
    {
        scoreTexT.text = (Time.time * 18).ToString("0");

     
        
    }
}

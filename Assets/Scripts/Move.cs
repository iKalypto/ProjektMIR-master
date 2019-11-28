using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 79.0f;
    private GameObject asteroid2;
   

    // Start is called before the first frame update
    void Start()
    {
        asteroid2 = GetComponent<GameObject>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //x = limks, rechts     y= vorne, hinten    z = oben, unten
        Vector3 position = new Vector3(0,100,0);
        float forward = speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(transform.position, position, forward);
    }

    //Camera.main.transform.position
}


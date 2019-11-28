using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CustomTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    private bool isTracked = false;

    public GameObject asteroid2;
    GameObject asterixClone;
    float nextSpawn = 0f;
    float spawnRate = 5f;
    private Rotator rotator;
    private Move move;


    // Start is called before the first frame update
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        rotator = asteroid2.GetComponent<Rotator>();
        move = asteroid2.GetComponent<Move>();


        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }


    }

    

    // Update is called once per frame
    void Update()
    {
        if (isTracked)
        {

            //nextSpawn = Time.time + Random.Range(1f, 2f);
            // Vector3 position = new Vector3(Random.Range(0f,10f), Random.Range(0f, 10f), Random.Range(0f, 10f));
            if (Time.time > nextSpawn)
                {
                nextSpawn = Time.time + 1.5f;
                asterixClone = Instantiate(asteroid2, transform.position + transform.TransformPoint(Random.Range(-2.5f, 2.5f), 0, Random.Range(-2.5f, 2.5f)), Quaternion.identity);
                }   // asterixClone.transform.position = position;
            //Debug.Log(position);
           // if(asterixClone.transform.position == (0,0,0)){
           //     Debug.Log("BOOM CAMERA");
				
                Destroy(asterixClone, 4);
          //  }
        }
    }
        public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                //Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
                isTracked = true;


            }

            else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                newStatus == TrackableBehaviour.Status.NO_POSE)
            {
                //Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
                isTracked = false;


            }
        }
    
}

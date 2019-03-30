using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour {
    public Catmul[] splines;
    public GameObject splinePrefab;
    public GameObject[] swarmleaderPrefab;
    public string[][] maskNames;

	// Use this for initialization
	void Start () {
        maskNames = new string[5][];

        maskNames[0] = new string[] { "flock1", "flock2", "flock3", "flock4" };
        maskNames[1] = new string[] { "flock0", "flock2", "flock3", "flock4" };
        maskNames[2] = new string[] { "flock0", "flock1", "flock3", "flock4" };
        maskNames[3] = new string[] { "flock0", "flock1", "flock2", "flock4" };
        maskNames[4] = new string[] { "flock0", "flock1", "flock2", "flock3" };

        splines = new Catmul[5]; // TODO - change
        splines[0] = Instantiate(splinePrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Catmul>();
        // TODO add code here
        float space = 30;
        //top right
        splines[1] = Instantiate(splinePrefab, new Vector3(space, 0, space), Quaternion.identity).GetComponent<Catmul>();
        //top left
        splines[2] = Instantiate(splinePrefab, new Vector3(space, 0, -space), Quaternion.identity).GetComponent<Catmul>();
        //bottom right
        splines[3] = Instantiate(splinePrefab, new Vector3(-space, 0, space), Quaternion.identity).GetComponent<Catmul>();
        //bottom left
        splines[4] = Instantiate(splinePrefab, new Vector3(-space, 0, -space), Quaternion.identity).GetComponent<Catmul>();

        for (int i = 0; i < 5; i++) // TO DO - change code
        {
            splines[i].GenerateSpline();
            splines[i].DrawLine();
        }


        //1 You have a prefab for each color of swarm leader.Pick one of them, and start it on 
        //the central track – this is the player.  Since the tracks are created dynamically, 
        //you’ll want to get the leader instantiated as well.The place to do this is in the track generation script.


        // spawn the flocks on the tracks.  Track 0 is where the player begins.
        for (int i = 0; i < 5; i++) // TO DO CHANGE CODE 
        {
            // TO DO - Spawn the swarm leader
            if (i == 0) //spawn player
            {
                //swarmleaderPrefab[0] = Instantiate(swarmleaderPrefab[0], new Vector3(space, 0, space), Quaternion.identity).GetComponent<Catmul>();
            }
            // TODO - Get the follow track script, and tell it about the track manager (so it can find more tracks), and the spline.
            // make sure to set the mask on the flock, and to say which is the player. 
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screeee : MonoBehaviour {

    public string[] pattern;
    private static string[] entry;
    static int a = 0;
    static int b = 0;


    // Use this for initialization
    void Start () {
        entry = new string[] { "n", "n", "n" };
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        entry[a] = gameObject.name;
        Debug.Log(gameObject.name);
        if (!(entry[a].Equals(pattern[a])))
        {
            b = 0;
            a = 0;
        }
        else
        {
            a++;
            b++;
        }
        
        if (b == 3)
            Debug.Log("Door opens");


    }
}

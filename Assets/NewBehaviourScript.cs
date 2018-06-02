using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    [SerializeField]
    private GameObject hint;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Killme()
    {
        this.gameObject.SetActive(false);
        hint.SetActive(false);
    }
}

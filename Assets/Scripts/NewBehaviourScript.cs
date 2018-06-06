using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    [SerializeField]
    private GameObject hint;
    public HintManager manager;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Killme()
    {
        this.gameObject.SetActive(false);
        manager.setRead(0);
        hint.SetActive(false);
    }
}

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
        if (GameManager.player.CurrentLocation.x == 11 && GameManager.player.CurrentLocation.y == 3)
            manager.setRead(0);
        if (GameManager.player.CurrentLocation.x == 22 && GameManager.player.CurrentLocation.y == 18)
            manager.setRead(1);
        if (GameManager.player.CurrentLocation.x == 14 && GameManager.player.CurrentLocation.y == 22)
            manager.setRead(2);
        hint.SetActive(false);
    }
}

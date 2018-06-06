using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse : MonoBehaviour {
    [SerializeField]
    private GameObject hint;
    public HintManager manager;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseDown()
    {
        if(GameManager.player.CurrentLocation.x == 11 && GameManager.player.CurrentLocation.y == 3)
            hint.transform.GetChild(1).GetComponent<Text>().text = manager.getText(0);
        if (GameManager.player.CurrentLocation.x == 22 && GameManager.player.CurrentLocation.y == 18)
            hint.transform.GetChild(1).GetComponent<Text>().text = manager.getText(1);
        if (GameManager.player.CurrentLocation.x == 14 && GameManager.player.CurrentLocation.y == 22)
            hint.transform.GetChild(1).GetComponent<Text>().text = manager.getText(2);
        if (GameManager.player.CurrentLocation.x == 15 && GameManager.player.CurrentLocation.y == 2)
            hint.transform.GetChild(1).GetComponent<Text>().text = manager.getText(3);
        hint.SetActive(true);
    }
}

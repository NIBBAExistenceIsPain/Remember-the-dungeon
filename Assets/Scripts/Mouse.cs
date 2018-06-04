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
        hint.transform.GetChild(1).GetComponent<Text>().text = manager.getText(0);
        hint.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HintManager : MonoBehaviour
{

    [SerializeField]
    private GameObject Hint;

    [SerializeField]
    private Vector2[] HintPositions;

    [SerializeField]
    private bool[] IsRead;

    [SerializeField]
    private string[] HintText;

    [SerializeField]
    private int[] Facing;


    public void ShowHint(Vector2 CurrentLocation, int facing)
    {
        // Debug.Log(CurrentLocation.x + " " + CurrentLocation.y + " " + IsRead.ToString() + " " + facing);
        
        for (int i = 0; i < HintPositions.Length; i++)
        {
            Debug.Log(CurrentLocation.x + " " + CurrentLocation.y + " " + HintPositions[i].x + " " + HintPositions[i].y);
            if (CurrentLocation.Equals(HintPositions[i]) && !IsRead[i] && Facing[i] == facing)
            {
                Hint.SetActive(true);
                break;
            }
            else
            {
                Hint.SetActive(false);
            }
        }
    }

    public string getText(int i)
    {
       return HintText[i];
    }

    public void setRead(int i)
    {
        IsRead[i] = true;
    }
}


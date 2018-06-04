using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {
   
    private enum Tile {Empty, N, S, W, E, NS, NE, NW, SW, SE, WE, NSW, NSE, NWE, SWE, NSWE}
    private Vector2 CurrentLocation;
    private enum Facing { N, W, S, E };
    private Facing f;
    private int[,] Map;

    [SerializeField]
    private HintManager hintManager;


    [SerializeField]
    private Sprites Sprites;

    [SerializeField]
    private GameObject MapSprite;

    [SerializeField]
    private GameObject pword;



    // Use this for initialization
    void Start () {
        Populate();
        LoadNewSprite();
	}

    private void Populate()
    {
        f = Facing.S;
        CurrentLocation = new Vector2(15,2);

        //So umm... You see.... This was done with a...
        // Map generator, YAS!


        Map = new int[,] {{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                          {0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0},
                          {0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0},
                          {0,0,0,0,0,0,0,0,0,0,1,0,1,1,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0},
                          {0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0},
                          {0,0,0,0,0,0,0,0,0,0,1,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0},
                          {0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                          {0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0},
                          {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0},
                          {0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0},
                          {0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0},
                          {0,0,0,1,0,0,0,0,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0},
                          {0,0,0,0,1,1,1,1,1,0,0,1,0,0,0,0,0,0,1,0,0,0,0,1,0,0,1,0,0,0},
                          {0,0,0,0,1,0,0,0,1,0,0,1,0,0,0,0,0,0,1,0,0,0,0,1,0,0,1,0,0,0},
                          {0,0,0,0,1,0,0,0,1,1,1,0,0,1,1,1,1,1,1,0,0,0,1,1,1,0,1,0,0,0},
                          {0,0,1,0,1,0,0,0,1,0,1,1,0,1,0,1,0,0,1,0,0,0,0,1,0,0,1,0,0,0},
                          {0,0,1,0,1,0,0,0,1,0,0,1,1,1,0,1,0,0,1,0,0,0,0,0,0,0,1,0,0,0},
                          {0,0,1,1,1,1,1,1,1,1,0,1,0,0,0,1,0,0,1,0,0,0,1,1,1,1,1,0,0,0},
                          {0,0,1,0,1,0,0,0,0,1,0,1,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0},
                          {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0},
                          {0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,1,0,0,0,1,0,0,0,1,1,1,1,0},
                          {0,0,0,0,0,0,0,0,1,1,1,0,0,0,1,0,0,1,0,0,0,1,0,0,0,1,0,0,1,0},
                          {0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,1,1,1,1,0,0,1,1,1,1,1,0,0,1,0},
                          {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0},
                          {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}};
    }

    public void Move()
    {
        
       
        switch (f)
        {
            case Facing.N:
                if (Map[(int)CurrentLocation.x - 1, (int)CurrentLocation.y] != 0)
                {
                    CurrentLocation.x--;
                  
                    hintManager.ShowHint(CurrentLocation, (int)f);

                }
                    break;
            case Facing.W:
                if (Map[(int)CurrentLocation.x, (int)CurrentLocation.y - 1] != 0 )
                {
                    CurrentLocation.y--;

                        hintManager.ShowHint(CurrentLocation, (int)f);
                }
                break;
            case Facing.S:
                if (Map[(int)CurrentLocation.x + 1, (int)CurrentLocation.y] != 0 )
                {
                    CurrentLocation.x++;

                        hintManager.ShowHint(CurrentLocation, (int)f);

                }
                break;
            case Facing.E:
                if (Map[(int)CurrentLocation.x, (int)CurrentLocation.y + 1] != 0)
                {
                    CurrentLocation.y++;

                        hintManager.ShowHint(CurrentLocation, (int)f);

                }
                break;
        }
        if (CurrentLocation.x == 8 && CurrentLocation.y == 18)
            pword.SetActive(true);
        else
            pword.SetActive(false);
        LoadNewSprite();
        //Debug.Log(CurrentLocation.x + " " + CurrentLocation.y);

    }

    public void RoL()
    {
        //Swap direction Left
        if (f == Facing.E)
            f = Facing.N;
        else
            f++;

        hintManager.ShowHint(CurrentLocation, (int)f);

        LoadNewSprite();
    }

    public void RoR()
    {
        ///Swap direction Left
        if (f == Facing.N)
            f = Facing.E;
        else
            f--;

        hintManager.ShowHint(CurrentLocation, (int)f);

        LoadNewSprite();
    }

    private void LoadNewSprite()
    {
        bool r = false;
        bool u = false;
        bool l = false;
        switch (f)
        {
            case Facing.N:
                l = Map[(int)CurrentLocation.x, (int)CurrentLocation.y -1 ] != 0;
                u = Map[(int)CurrentLocation.x - 1, (int)CurrentLocation.y] != 0;
                r = Map[(int)CurrentLocation.x, (int)CurrentLocation.y + 1] != 0;
                break;
            case Facing.W:
                r = Map[(int)CurrentLocation.x - 1, (int)CurrentLocation.y] != 0;
                u = Map[(int)CurrentLocation.x, (int)CurrentLocation.y - 1 ] != 0;
                l = Map[(int)CurrentLocation.x + 1, (int)CurrentLocation.y ] != 0;
                break;
            case Facing.S:
                l = Map[(int)CurrentLocation.x, (int)CurrentLocation.y + 1] != 0;
                u = Map[(int)CurrentLocation.x + 1, (int)CurrentLocation.y] != 0;
                r = Map[(int)CurrentLocation.x, (int)CurrentLocation.y - 1] != 0;
                break;
            case Facing.E:
                r = Map[(int)CurrentLocation.x + 1, (int)CurrentLocation.y] != 0;
                u = Map[(int)CurrentLocation.x, (int)CurrentLocation.y + 1] != 0;
                l = Map[(int)CurrentLocation.x - 1, (int)CurrentLocation.y] != 0;
                break;
        }
        //Debug.Log(r + " " + u + " " + l);
        //Debug.Log(f);

        //Based on L U and R load new sprite
        if (r && u && l)
            MapSprite.GetComponent<SpriteRenderer>().sprite = Sprites.FLR;
        else if (r && !u && l)
            MapSprite.GetComponent<SpriteRenderer>().sprite = Sprites.LR;
        else if (r && u && !l)
            MapSprite.GetComponent<SpriteRenderer>().sprite = Sprites.FR;
        else if (!r && u && l)
            MapSprite.GetComponent<SpriteRenderer>().sprite = Sprites.FL;
        else if (r && !u && !l)
            MapSprite.GetComponent<SpriteRenderer>().sprite = Sprites.R;
        else if (!r && !u && l)
            MapSprite.GetComponent<SpriteRenderer>().sprite = Sprites.L;
        else if (!r && u && !l)
            MapSprite.GetComponent<SpriteRenderer>().sprite = Sprites.F;
        else if (!r && !u && !l)
            MapSprite.GetComponent<SpriteRenderer>().sprite = null;

        


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {
   
    private enum Tile {Empty, N, S, W, E, NS, NE, NW, SW, SE, WE, NSW, NSE, NWE, SWE, NSWE}
    private int[,] Map;
    private Vector2 CurrentLocation;
    private enum Facing { N, W, S, E };
    private Facing f;

    [SerializeField]
    private Vector2 MapSize;
    [SerializeField]
    private Sprites Sprites;
    [SerializeField]
    private GameObject MapSprite;



    // Use this for initialization
    void Start () {
        Populate();
        LoadNewSprite();
	}

    private void Populate()
    {
        f = Facing.N;
        CurrentLocation = new Vector2(5, 2);
        Map = new int[,] {{0,0,0,0,0},
                          {0,1,1,1,0},
                          {0,1,0,0,0},
                          {0,1,1,0,0},
                          {0,0,1,1,0},
                          {0,0,1,0,0},
                          {0,0,0,0,0}};
    }

    public void Move()
    {
        switch (f)
        {
            case Facing.N:
                CurrentLocation.x--;
                break;
            case Facing.W:
                CurrentLocation.y--;
                break;
            case Facing.S:
                CurrentLocation.x++;
                break;
            case Facing.E:
                CurrentLocation.y++;
                break;
        }
        LoadNewSprite();

    }

    public void RoL()
    {
        //Swap direction Left
        if (f == Facing.E)
            f = Facing.N;
        else
            f++;

        LoadNewSprite();
    }

    public void RoR()
    {
        ///Swap direction Left
        if (f == Facing.N)
            f = Facing.E;
        else
            f--;


        LoadNewSprite();
    }

    private void LoadNewSprite()
    {
        bool r = false;
        bool u = false;
        bool l = false;
        Debug.Log(f);
        Debug.Log(CurrentLocation.x + " " + CurrentLocation.y);
        switch (f)
        {
            case Facing.N:
                l = Map[(int)CurrentLocation.x, (int)CurrentLocation.y -1 ] != 0;
                u = Map[(int)CurrentLocation.x - 1, (int)CurrentLocation.y] != 0;
                r = Map[(int)CurrentLocation.x, (int)CurrentLocation.y + 1] != 0;
                break;
            case Facing.W:
                l = Map[(int)CurrentLocation.x - 1, (int)CurrentLocation.y] != 0;
                u = Map[(int)CurrentLocation.x, (int)CurrentLocation.y - 1 ] != 0;
                r = Map[(int)CurrentLocation.x + 1, (int)CurrentLocation.y ] != 0;
                break;
            case Facing.S:
                l = Map[(int)CurrentLocation.x, (int)CurrentLocation.y + 1] != 0;
                u = Map[(int)CurrentLocation.x + 1, (int)CurrentLocation.y] != 0;
                r = Map[(int)CurrentLocation.x, (int)CurrentLocation.y - 1] != 0;
                break;
            case Facing.E:
                l = Map[(int)CurrentLocation.x + 1, (int)CurrentLocation.y] != 0;
                u = Map[(int)CurrentLocation.x, (int)CurrentLocation.y + 1] != 0;
                r = Map[(int)CurrentLocation.x - 1, (int)CurrentLocation.y] != 0;
                break;
        }

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

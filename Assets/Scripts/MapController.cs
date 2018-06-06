using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Facing { N, W, S, E };

public class MapController : MonoBehaviour {

    private int[,] Map;
    private Player player;

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
        if (!GameManager.started) return;
        Populate();
        SetPlayer(GameManager.player);
        LoadNewSprite();
	}

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    private void Populate()
    { 
       //So umm... You see.... This was done with a...
        // Map generator, YAS!


        Map = new int[,] {{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                          {0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0},
                          {0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0},
                          {0,0,0,0,0,0,0,0,0,0,1,0,1,1,1,1,1,1,1,5,0,1,0,0,0,0,0,0,0,0},
                          {0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0},
                          {0,0,0,0,0,0,0,0,0,0,1,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0},
                          {0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                          {0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0},
                          {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0},
                          {0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0},
                          {0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0},
                          {0,0,0,1,0,0,0,0,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0},
                          {0,0,0,0,1,1,1,1,1,0,0,1,0,0,0,0,0,0,1,0,0,0,0,1,0,0,1,0,0,0},
                          {0,0,0,0,1,0,0,0,1,0,0,3,0,0,0,0,0,0,1,0,0,0,0,1,0,0,1,0,0,0},
                          {0,0,0,0,1,0,0,0,1,1,1,0,0,1,1,1,1,1,1,0,0,0,1,1,1,0,1,0,0,0},
                          {0,0,1,0,1,0,0,0,1,0,1,1,0,1,0,1,0,0,1,0,0,0,0,1,0,0,1,0,0,0},
                          {0,0,1,0,1,0,0,0,1,0,0,1,1,1,0,1,0,0,1,0,0,0,0,0,0,0,1,0,0,0},
                          {0,0,1,1,1,1,1,1,1,1,0,1,0,0,0,1,0,0,1,0,0,0,1,1,1,1,1,0,0,0},
                          {0,0,1,0,1,0,0,0,0,1,0,1,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0},
                          {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0},
                          {0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,1,0,0,0,1,0,0,0,1,1,1,1,0},
                          {0,0,0,0,0,0,0,0,1,2,1,0,0,0,1,0,0,1,0,0,0,1,0,0,0,1,0,0,1,0},
                          {0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,1,1,1,1,0,0,1,1,1,1,1,0,0,4,0},
                          {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0},
                          {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}};
    }

    public void Move()
    {
        var CurrentLocation = player.CurrentLocation;
        var f = player.FacingDirection;
        if (CurrentLocation.x == 8 && CurrentLocation.y == 18 && !Screeee.open && f.Equals(Facing.N))
            return;
        switch (f)
        {
            case Facing.N:
                if (Map[(int)CurrentLocation.x - 1, (int)CurrentLocation.y] != 0)
                {
                    CurrentLocation.x--;
                    player.CurrentLocation = CurrentLocation;
                    CheckSpawn();
                    hintManager.ShowHint(CurrentLocation, (int)f);

                }
                    break;
            case Facing.W:
                if (Map[(int)CurrentLocation.x, (int)CurrentLocation.y - 1] != 0 )
                {
                    CurrentLocation.y--;
                    player.CurrentLocation = CurrentLocation;
                    CheckSpawn();
                    hintManager.ShowHint(CurrentLocation, (int)f);
                }
                break;
            case Facing.S:
                if (Map[(int)CurrentLocation.x + 1, (int)CurrentLocation.y] != 0 )
                {
                    CurrentLocation.x++;
                    player.CurrentLocation = CurrentLocation;

                    hintManager.ShowHint(CurrentLocation, (int)f);
                    CheckSpawn();
                }
                break;
            case Facing.E:
                if (Map[(int)CurrentLocation.x, (int)CurrentLocation.y + 1] != 0)
                {
                    CurrentLocation.y++;
                    player.CurrentLocation = CurrentLocation;

                    hintManager.ShowHint(CurrentLocation, (int)f);
                    CheckSpawn();
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
        if (player.FacingDirection == Facing.E)
            player.FacingDirection = Facing.N;
        else
            player.FacingDirection++;

        hintManager.ShowHint(player.CurrentLocation, (int)player.FacingDirection);

        LoadNewSprite();
    }

    public void RoR()
    {
        ///Swap direction Left
        if (player.FacingDirection == Facing.N)
            player.FacingDirection = Facing.E;
        else
            player.FacingDirection--;

        hintManager.ShowHint(player.CurrentLocation, (int)player.FacingDirection);

        LoadNewSprite();
    }

    private void LoadNewSprite()
    {
        bool r = false;
        bool u = false;
        bool l = false;
        var f = player.FacingDirection;
        var CurrentLocation = player.CurrentLocation;
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
            MapSprite.GetComponent<SpriteRenderer>().sprite = Sprites.deadEnd;

        


    }
    private void CheckSpawn()
    {
        var CurrentLocation = player.CurrentLocation;
        int a = Map[(int)CurrentLocation.x, (int)CurrentLocation.y];
        System.Random rnd = new System.Random();
        if (a > 1)
        {
            switch (a)
            {
                case 2:
                    GameManager.Battle(Enemy.GenerateMiniBoss(EnemyType.BlueBoss));
                    break;
                case 3:
                    GameManager.Battle(Enemy.GenerateMiniBoss(EnemyType.RedBoss));
                    break;
                case 4:
                    GameManager.Battle(Enemy.GenerateMiniBoss(EnemyType.GreenBoss));
                    break;
                case 5:
                    GameManager.Battle(Enemy.GenerateBoss());
                    break;

            }
        }
        else
        {

            if (rnd.Next(1, 100) > 90)
            {
                GameManager.Battle(Enemy.GenerateEnemy());
            }
        }

    }
}

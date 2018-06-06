using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScrip : MonoBehaviour
{
    private Text tutText;
    Image img1;
    Image img2;
    int a;

    private void Start()
    {
        a = 0;
        tutText = FindObjectsOfType<Text>()[1];
        img1 = FindObjectsOfType<Image>()[0];
        img1.gameObject.SetActive(false);
        img2 = FindObjectsOfType<Image>()[0];
        img2.gameObject.SetActive(false);

    }

    public void Next()
    {
        switch(a)
        {
            case 0:
                tutText.text = "The aim of the game is to navigate through a series of dungeons and defeat the guardians by remembering hints given throught you journey.";
                break;
            case 1:
                {
                    tutText.text = "This is exploration mode. You will find 3 directional buttons on the bottom right corner of the screen. Use them to navigate through the maze";
                    img1.gameObject.SetActive(true);
                    break;
                }
            case 2:
                tutText.text = "Use the Rotate Left and Rotate Right Buttons to look around the room.";
                break;
            case 3:
                tutText.text = "Use the Move Button to advance to the next room.";
                break;
            case 4:
                tutText.text = "While exploring random monsters might attack you. You can also find formidable enemies at set locations throughout the dungeon.";
                break;
            case 5:
                tutText.text = "This is cobat mode. You enter it after encountering an enemy.";
                img1.gameObject.SetActive(false);
                img2.gameObject.SetActive(true);
                break;
            case 6:
                tutText.text = "You have to remember the attacks of your opponent and do the exact opposite using the action buttons shown on screen to succed in combat.";
                break;
            case 7:
                tutText.text = "For example if you know that the enemy will attack from above on turn one you have to instead block from the same direction";
                break;
            case 8:
                tutText.text = "Defeat all three key masters to gain entry into the guardian room";
                img2.gameObject.SetActive(false);
                break;
            case 9:
                tutText.text = "This concludes the tutorial";
                FindObjectsOfType<Text>()[0].text = "Finish";
                break;
            case 10:
                GameManager.StartGame();
                break;
        }
        a++;
    }
}

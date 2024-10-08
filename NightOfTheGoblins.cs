using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightOfTheGoblins : MonoBehaviour
{

    //all my Ints and Booleans are declared here, some with values, some without.
    int PlayerEXP = 0;
    int PlayerLVL = 1;
    float PlayerATK = 1f;
    bool PlayerTurn = false;
    bool GoblinBTL = false;
    bool BTLStart = true;
    bool GameWon = false;
    
    float GoblinHealth;
    int GoblinLVL;
    int GoblinEXP;

  
    // Start is called before the first frame update, displaying a quick introduction.
    void Start()
    {

        print("You awaken to Goblins");
        print("Fight for your Village!");

    }


    //This function exists to initialise the Goblin's Stats
    void Battle()
    {

        if (BTLStart == true)
        {
            GoblinLVL = Random.Range(1, 5);
            GoblinHealth = (2 * GoblinLVL);
            print($"This Goblin before you is LVL {GoblinLVL}! It has {Mathf.FloorToInt(GoblinHealth)} Health!");
            print("Strike the goblin before you with SPACE");
            PlayerTurn = true;
            GoblinBTL = true;
            BTLStart = false;
        }   
    }

    //Player can call on this function to reveal vital stats about the player.
    void PlayerStats()
    {
        if (PlayerEXP >= (PlayerLVL * 10))
        {

            PlayerLVL++;
            PlayerATK += (PlayerATK * 1.25f);
            print("Well Done!");
            print($"The player is now LVL {PlayerLVL}");
            print($"Your ATK Damage is now {Mathf.FloorToInt(PlayerATK)}!");
            PlayerEXP = 0;
            GoblinBTL = false;
        }

        else
        {
            print($"Your Attack Damage is {Mathf.FloorToInt(PlayerATK)}");
            print($"Player is LVL {PlayerLVL}");
            print($"You have {PlayerEXP} EXP");
            print($"You need {PlayerLVL * 10} EXP to LVL UP");
        }
    }

    // Update is called once per frame
    void Update()
    {

        //The game runs because this boolean is false. When the player reaches LVL 5 they will make it true, and win. 
        if (GameWon == false)
        {
            //The UP ARROW will display stats at any point in the game.
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                PlayerStats();
            }

            //This is the win condition that will trigger the GameWon boolean.
            if (PlayerLVL == 5)
            {
                print("You defeated the Goblins with your LVL 5 Laser Eyes Ability. You won the Game!");
                GameWon = true;
                return;
            }

            //If there is no battle and it's not the players turn it will hand over control to the player and display what input is required.
            if (GoblinBTL == false && PlayerTurn == false)
            {
                print("So what will it be? Will you press SPACE and fight?");
                PlayerTurn = true;

            }

            //Once the player presses SPACE outside battle, it will trigger a new battle and refresh the Goblin's stats.
            if (Input.GetKeyDown(KeyCode.Space) && GoblinBTL == false && PlayerTurn == true)
            {
                Battle();
                return;
            }
            
            //This is the function for striking the Goblin, triggered by being in battle, pressing Space when it is the player's turn and after the Goblin has been initialised.
            if (Input.GetKeyDown(KeyCode.Space) && PlayerTurn == true && GoblinBTL == true && BTLStart == false)
            {
                GoblinHealth -= Mathf.FloorToInt(PlayerATK);
                print($"You slashed at the goblin for {Mathf.FloorToInt(PlayerATK)} Damage!");

                //If you killed the goblin.
                if (GoblinHealth <= 0)
                {
                    GoblinEXP = (Random.Range(5, 10) * GoblinLVL);
                    PlayerEXP += GoblinEXP;
                    print("You defeated the Goblin!");
                    print($"You gained {GoblinEXP} EXP");
                    PlayerTurn = false;
                    BTLStart = true;

                    if (PlayerEXP > (PlayerLVL * 10))
                    {
                        print("You have enough EXP to LVL UP");
                        print("Press UP!");
                        return;

                    }

                    GoblinBTL = false;
                    return;
                }

                //Otherwise, display its health so the player knows they will need to continue fighting and what input to use.
                else
                {
                    print($"It has {Mathf.FloorToInt(GoblinHealth)} Health left!");
                    print("Press SPACE again to strike!");

                }

            }

        }

    }

}

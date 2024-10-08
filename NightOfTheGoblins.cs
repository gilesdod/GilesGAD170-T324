using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightOfTheGoblins : MonoBehaviour
{
    int PlayerEXP = 0;
    int PlayerLVL = 1;
    float PlayerATK = 1f;
    bool PlayerTurn = false;
    bool GoblinBTL = false;
    bool BTLStart = true;
    bool GameWon = false;
    
    float GoblinHealth;
    int GoblinLVL;

  
    // Start is called before the first frame update
    void Start()
    {

        print("You awaken to Goblins");
        print("Fight for your Village!");

    }

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

    // Update is called once per frame
    void Update()
    {
        if (GameWon == false)
        {

            if (PlayerEXP >= (PlayerLVL * 10))
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {

                    PlayerLVL++;
                    PlayerATK = (PlayerATK * 1.25f);
                    print("Well Done!");
                    print($"The player is now LVL {PlayerLVL}");
                    print($"Your ATK Damage is now {PlayerATK}!");
                    PlayerEXP = 0;
                    
                }
            }

            if (PlayerLVL == 5)
            {
                print("You defeated the Goblins with your LVL 5 Laser Eyes Ability. You won the Game!");
                GameWon = true;
                
            }

            if (GoblinBTL == false && PlayerTurn == false)
            {
                print("So what will it be? Will you press SPACE and fight?");
                PlayerTurn = true;
                

            }

            if (Input.GetKeyDown(KeyCode.Space) && GoblinBTL == false && PlayerTurn == true)
            {               
                Battle();
                PlayerTurn = false;
                
            }
            
            if (Input.GetKeyDown(KeyCode.Space) && PlayerTurn == true && GoblinBTL == true)
            {
                GoblinHealth -= PlayerATK;
                print($"You slashed at the goblin for {Mathf.FloorToInt(PlayerATK)} Damage!");

                if (GoblinHealth <= 0)
                {
                    print("You deafeated the Goblin!");
                    PlayerTurn = false;

                }

                else
                {
                    print($"It has {Mathf.FloorToInt(GoblinHealth)} Health left!");
                    PlayerTurn = false;


                }



            }
        }

    }

}

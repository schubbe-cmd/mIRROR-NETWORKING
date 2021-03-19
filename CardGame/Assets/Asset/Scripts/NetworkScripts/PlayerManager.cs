using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
{
    public GameObject Hand; //ytan för spelarens hand
    public GameObject TableTop; //spelplan
    public GameObject EnemyHand; //motståndarens hand

    //dessa gör det möjligt att sätta in alla kort till player manager prefaben, den skapar listor av dem alla
    public List<GameObject> defensiveCards;
    private List<GameObject> workingList = new List<GameObject>();

    public List<GameObject> attackCards;
    private List<GameObject> workingList2 = new List<GameObject>();

    public List<GameObject> dodgeCards;
    private List<GameObject> workingList3 = new List<GameObject>();


    [Server]
    public override void OnStartServer()
    {
        
    }
    
    public override void OnStartClient()
    {
        base.OnStartClient();

        Hand = GameObject.Find("Hand");
        TableTop = GameObject.Find("Tabletop");
        EnemyHand = GameObject.Find("EnemyHand");
    }
    //kopplat till GetRandom.. tänk inte för mycket på denna
   private void ResetWorkingList()
    {
        workingList.Clear();
        workingList.AddRange(defensiveCards);
        workingList2.Clear();
        workingList2.AddRange(attackCards);
        workingList3.Clear();
        workingList3.AddRange(dodgeCards);

    }
    // alla dessa GetRandom... är gjorda att "shuffla" listorna och ge ut endast 1 exemplar av korten
    private GameObject GetRandomDefensiveCard()
    {
        if (workingList.Count == 0)
            ResetWorkingList();
        int index = Random.Range(0, workingList.Count);
        GameObject res = workingList[index];
        workingList[index] = workingList[workingList.Count - 1];
        workingList.RemoveAt(workingList.Count - 1);
        return res;
    }

    private GameObject GetRandomAttackCard()
    {
        if (workingList2.Count == 0)
            ResetWorkingList();
        int index = Random.Range(0, workingList2.Count);
        GameObject res = workingList2[index];
        workingList2[index] = workingList2[workingList2.Count - 1];
        workingList2.RemoveAt(workingList2.Count - 1);
        return res;
    }

    private GameObject GetRandomDodgeCard()
    {
        if (workingList3.Count == 0)
            ResetWorkingList();
        int index = Random.Range(0, workingList3.Count);
        GameObject res = workingList3[index];
        workingList3[index] = workingList3[workingList3.Count - 1];
        workingList3.RemoveAt(workingList3.Count - 1);
        return res;
    }
    
    [Command]
    public void CmdDealCards()
    {
       //dennes uppgift är att dela ut 4 exemplar per kort till varenda spelare, inte klar
        
        for (int i = 0; i < 4; i++)
        {
            GameObject attackCard = Instantiate(GetRandomAttackCard(), new Vector2(0, 0), Quaternion.identity);
            NetworkServer.Spawn(attackCard, connectionToClient);
            RpcShowCard(attackCard, "Dealt");
        }

        

        for (int i = 0; i < 4; i++)
        {
            GameObject defenseCard = Instantiate(GetRandomDefensiveCard(), new Vector2(0, 0), Quaternion.identity);
            NetworkServer.Spawn(defenseCard, connectionToClient);
            RpcShowCard(defenseCard, "Dealt");

        }



        for (int i = 0; i < 1; i++)
        {
            GameObject dodgeCard = Instantiate(GetRandomDodgeCard(), new Vector2(0, 0), Quaternion.identity);
            NetworkServer.Spawn(dodgeCard, connectionToClient);
            RpcShowCard(dodgeCard, "Dealt");
        }


    }
    
    public void PlayCard(GameObject card)
    {
        CmdPlayCard(card);
    }

    [Command]

    void CmdPlayCard(GameObject card)
    {
        RpcShowCard(card, "Played");
    }

    [ClientRpc]
    void RpcShowCard(GameObject card, string type) //denna skall göra det möjligt att korten far på rätt platser i kanvasen, hur den gör det är ännu magi för mig
    {
        if(type == "Dealt")
        {
            if (hasAuthority)
            {
                card.transform.SetParent(Hand.transform, false);
            }
            else
            {
                card.transform.SetParent(EnemyHand.transform, false);
            }
        }
        else if (type == "Played")
        {
            card.transform.SetParent(TableTop.transform, false);
        }

    }
   
}

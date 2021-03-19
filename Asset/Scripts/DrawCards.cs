using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class DrawCards : NetworkBehaviour
{
    public PlayerManager PlayerManager;

    /**public GameObject Hand;
    public GameObject TableTop;
    public GameObject enemyHand;

    public List<GameObject> defensiveCards;
    private List<GameObject> workingList = new List<GameObject>();

    public List<GameObject> attackCards;
    private List<GameObject> workingList2 = new List<GameObject>();

    public List<GameObject> dodgeCards;
    private List<GameObject> workingList3 = new List<GameObject>();**/

   /** public List<GameObject>[] cardTypes;
    cardTypes = { defensiveCards, attackCards, dodgeCards };**/

   /** private void ResetWorkingList()
    {
        workingList.Clear();
        workingList.AddRange(defensiveCards);
        workingList2.Clear();
        workingList2.AddRange(attackCards);
        workingList3.Clear();
        workingList3.AddRange(dodgeCards);

    }

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
    }**/


    void Start()
    {
       
    }

    public void OnClick()
    {

        NetworkIdentity networkidentity = NetworkClient.connection.identity;
        PlayerManager = networkidentity.GetComponent<PlayerManager>();
        PlayerManager.CmdDealCards();

       /** for (int i = 0; i < 4; i++)
        {
            GameObject attackCard = Instantiate(GetRandomAttackCard(), new Vector3(0, 0, 0), Quaternion.identity);
            attackCard.transform.SetParent(Hand.transform, false);

        }

        for (int i = 0; i < 4; i++)
        {
            GameObject attackCard = Instantiate(GetRandomAttackCard(), new Vector3(0, 0, 0), Quaternion.identity);
            attackCard.transform.SetParent(enemyHand.transform, false);

        }

        for (int i = 0; i < 4; i++)
        {
            GameObject defenseCards = Instantiate(GetRandomDefensiveCard(), new Vector3(0, 0, 0), Quaternion.identity);
            defenseCards.transform.SetParent(Hand.transform, false);
            

        }

        for (int i = 0; i < 4; i++)
        {
            GameObject defenseCards = Instantiate(GetRandomDefensiveCard(), new Vector3(0, 0, 0), Quaternion.identity);
            defenseCards.transform.SetParent(enemyHand.transform, false);

        }

        
        for (int i = 0; i < 1; i++)
        {
            GameObject dodgeCard = Instantiate(GetRandomDodgeCard(), new Vector3(0, 0, 0), Quaternion.identity);
            dodgeCard.transform.SetParent(Hand.transform, false);

        }

        for (int i = 0; i < 1; i++)
        {
            GameObject dodgeCard = Instantiate(GetRandomDodgeCard(), new Vector3(0, 0, 0), Quaternion.identity);
            dodgeCard.transform.SetParent(enemyHand.transform, false);

        }**/


    }

    
}

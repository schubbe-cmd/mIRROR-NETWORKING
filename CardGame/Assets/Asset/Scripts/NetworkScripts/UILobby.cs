using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILobby : MonoBehaviour{

    public static UILobby instance;

    [Header("Host Join")]

    [SerializeField] InputField joinMatchInput;
    [SerializeField] Button joinButton;
    [SerializeField] Button hostButton;
    [SerializeField] Canvas lobbyCanvas;

    [Header("Lobby")]
    [SerializeField] Transform UIPlayerParent;
    [SerializeField] GameObject UIPlayerPrefab;


    private void Start()
    {
        instance = this;
       // lobbyCanvas.enabled = false;
    }



    public void Host ()
    {
        joinMatchInput.interactable = false; //st�nger av knappen
        joinButton.interactable = false; //st�nger av knappen
        hostButton.interactable = false; //st�nger av knappen

        Player.localPlayer.HostGame ();
    }

    public void HostSuccess (bool success)
    {
        if (success)
        {
            lobbyCanvas.enabled = true;
            SpawnPlayerUIPrefab(Player.localPlayer);
        }
        else
        {
            joinMatchInput.interactable = true; //l�gger p� knappen
            joinButton.interactable = true; //l�gger p� knappen
            hostButton.interactable = true; //l�gger p� knappen
        }
    }


    public void Join()
    {
        joinMatchInput.interactable = false; //st�nger av knappen
        joinButton.interactable = false; //st�nger av knappen
        hostButton.interactable = false; //st�nger av knappen

        Player.localPlayer.JoinGame(joinMatchInput.text.ToUpper());
    }

    public void JoinSuccess(bool success)
    {
        if (success)
        {
            lobbyCanvas.enabled = true;
            SpawnPlayerUIPrefab(Player.localPlayer);
        }
        else
        {
            joinMatchInput.interactable = true; //l�gger p� knappen
            joinButton.interactable = true; //l�gger p� knappen
            hostButton.interactable = true; //l�gger p� knappen
        }
    }

    public void SpawnPlayerUIPrefab (Player player)
    {
        GameObject newUIPlayer = Instantiate(UIPlayerPrefab, UIPlayerParent);
        newUIPlayer.GetComponent<UIPlayer>().SetPlayer(player);
    }

}

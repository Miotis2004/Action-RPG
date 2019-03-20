using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ButtonAssignments : NetworkBehaviour
{

    public List<Spell> spell = new List<Spell>();

    [SerializeField]
    GameObject PC;

    public void CastSpell(int buttonNumber)
    {
        PC = FindLocalPlayer();
        TargetedSpell targetedSpell = PC.GetComponent<TargetedSpell>();
        GameObject target = targetedSpell.target;

        Debug.Log("Caused " + spell[buttonNumber].damage + " to " + target.name);
    }

    public GameObject FindLocalPlayer()
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");
        
        
        foreach (GameObject player in players)
        {
            if (isLocalPlayer)
            {
                return player;
            }
        }

        return null;
    }
}

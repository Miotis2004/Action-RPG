using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour {

    public ButtonAssignments buttons;

    private void Awake()
    {
        buttons = FindObjectOfType<ButtonAssignments>();
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedSpell : MonoBehaviour {

    public GameObject target;

    private void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 30))
            {
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    target = hit.transform.gameObject;
                    Debug.Log("Targeting " + target.name);
                }
            }
        }
    }

    
}

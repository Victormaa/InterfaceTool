using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayInteraction : MonoBehaviour
{
    public GameObject UI_InteractablePanel;
    public TMP_Text UI_InteractableText;

    public Camera mainCam;

    public float detectRange = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        InteractByRay();
    }

    private void InteractByRay()
    {
        Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2);
        
        RaycastHit hit;
        bool hitFound = false;
        if(Physics.Raycast(ray, out hit, detectRange))
        {
            IInteractable interactable = (IInteractable)hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                hitFound = true;
                UI_InteractablePanel.SetActive(true);
                UI_InteractableText.text = interactable.GetDescription();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
        }
        else
            UI_InteractablePanel.SetActive(false);
    }
}

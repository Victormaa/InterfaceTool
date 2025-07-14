using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IInteractable2D : MonoBehaviour
{
    public GameObject tipsIcon;

    public virtual string GetDescription()
    {
        return "";
    }

    public virtual void Interact()
    {

    }
}

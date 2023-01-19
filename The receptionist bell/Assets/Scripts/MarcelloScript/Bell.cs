using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : InteractableObject
{
    #region Variables & Properties

    [SerializeField] private AudioClip audioClip;
    [SerializeField] private int startCounter;
    //[SerializeField] private List<ActionToDo> actionToDoList;

    #endregion

    #region Methods

    protected override void OnInteract()
    {
        SoundManager.Instance.PlaySound(audioClip);
    }

    #endregion

}   


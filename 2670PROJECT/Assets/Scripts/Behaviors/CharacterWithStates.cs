using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterWithStates : MonoBehaviour
{
    private CharacterController controller;

    public CharacterStateMachineData characterStates;
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        switch (characterStates.value)
        {
            case CharacterStateMachineData.characterStates.StandardWalk:
                break;
            case CharacterStateMachineData.characterStates.WallCrawl:
                break;
            case CharacterStateMachineData.characterStates.Idle:
                break;
            
        }
    }

    
}

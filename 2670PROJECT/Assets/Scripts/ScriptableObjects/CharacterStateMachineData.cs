using UnityEngine;

[CreateAssetMenu]
public class CharacterStateMachineData : ScriptableObject
{
    public enum characterStates
    {
        StandardWalk,
        WallCrawl,
        Idle
    }
    
    public characterStates value;

    
}

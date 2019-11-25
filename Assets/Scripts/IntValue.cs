using UnityEngine;

[CreateAssetMenu]
public class IntValue : ScriptableObject
{
    public int value;

    public static implicit operator int(IntValue value)
    {
        return value.value;
    }
}

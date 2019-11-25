using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject
{
    public float value;

    public static implicit operator float(FloatValue value)
    {
        return value.value;
    }
}

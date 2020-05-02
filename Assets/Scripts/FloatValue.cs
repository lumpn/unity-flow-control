using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject
{
    [SerializeField] public float value;

    public static implicit operator float(FloatValue value)
    {
        return value.value;
    }
}

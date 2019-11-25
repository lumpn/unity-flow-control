using UnityEngine;

public class FlowController : MonoBehaviour
{
    [SerializeField] private FloatValue rateIn;
    [SerializeField] private FloatValue rateOut;
    [SerializeField] private IntValue bufferCount;

    [SerializeField] private float factorIn;
    [SerializeField] private float factorBuffer;
    [SerializeField] private float drainRate;

    [System.NonSerialized] public float smoothIn;
    [System.NonSerialized] public float smoothBuffer;

    void Update()
    {
        smoothIn = rateIn;
        smoothBuffer = bufferCount * drainRate;
        rateOut.value = (factorIn * smoothIn) + (factorBuffer * smoothBuffer);
    }
}

using UnityEngine;

public class FlowController : MonoBehaviour
{
    [SerializeField] private FloatValue rateIn;
    [SerializeField] private FloatValue rateOut;
    [SerializeField] private IntValue bufferCount;

    [SerializeField] private float factorIn;
    [SerializeField] private float factorBuffer;
    [SerializeField] private float drainRate;

    [SerializeField] private float smoothTimeIn;
    [SerializeField] private float smoothTimeBuffer;
    [SerializeField] private float maxSpeedIn;
    [SerializeField] private float maxSpeedBuffer;

    [System.NonSerialized] public float smoothIn;
    [System.NonSerialized] public float smoothBuffer;
    [System.NonSerialized] public float velIn;
    [System.NonSerialized] public float velBuffer;

    void Update()
    {
        var dt = Time.deltaTime;
        smoothIn = Mathf.SmoothDamp(smoothIn, rateIn, ref velIn, smoothTimeIn, maxSpeedIn, dt);
        smoothBuffer = Mathf.SmoothDamp(smoothBuffer, bufferCount * drainRate, ref velBuffer, smoothTimeBuffer, maxSpeedBuffer, dt);
        rateOut.value = (factorIn * smoothIn) + (factorBuffer * smoothBuffer);
    }
}

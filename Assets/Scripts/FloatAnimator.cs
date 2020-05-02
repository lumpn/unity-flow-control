using UnityEngine;

public class FloatAnimator : MonoBehaviour
{
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private FloatValue target;

    void Update()
    {
        target.value = curve.Evaluate(Time.time);
    }
}

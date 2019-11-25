using UnityEngine;

public class FloatAnimator : MonoBehaviour
{
    [SerializeField] private AnimationClip clip;
    [SerializeField] private float value;
    [SerializeField] private FloatValue target;

    void Update()
    {
        clip.SampleAnimation(gameObject, Time.time);
        target.value = value;
    }
}

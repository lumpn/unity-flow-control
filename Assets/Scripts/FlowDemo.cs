using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowDemo : MonoBehaviour
{
    [SerializeField] private LineRenderer rendererIn;
    [SerializeField] private LineRenderer rendererOut;
    [SerializeField] private LineRenderer rendererBuffer;
    [SerializeField] private LineRenderer rendererLatency;

    [SerializeField] private FloatValue rateIn;
    [SerializeField] private FloatValue rateOut;
    [SerializeField] private IntValue bufferCount;

    [System.NonSerialized] public float fracIn;
    [System.NonSerialized] public float fracOut;

    [System.NonSerialized] private readonly Queue<Element> buffer = new Queue<Element>();

    const int historySize = 1024;
    [System.NonSerialized] private int historyIndex = 0;
    [System.NonSerialized] private readonly int[] historyIn = new int[historySize];
    [System.NonSerialized] private readonly int[] historyOut = new int[historySize];
    [System.NonSerialized] private readonly int[] historyBuffer = new int[historySize];

    [System.NonSerialized] private int latencyIndex = 0;
    [System.NonSerialized] private readonly float[] latencies = new float[historySize];

    [System.NonSerialized] private readonly Vector3[] positions = new Vector3[historySize];

    private struct Element
    {
        public readonly float timeStart;

        public Element(float time)
        {
            this.timeStart = time;
        }

        public float OnComplete(float time)
        {
            return (time - timeStart);
        }
    }

    void Start()
    {
        Application.targetFrameRate = 1;
        rendererIn.positionCount = historySize;
        rendererOut.positionCount = historySize;
        rendererBuffer.positionCount = historySize;
        rendererLatency.positionCount = historySize;
    }

    void Update()
    {
        var time = Time.time;
        var dt = Time.deltaTime;

        // out
        var rawOut = fracOut + rateOut * dt;
        var numOut = (int)rawOut;
        fracOut = rawOut - numOut;
        numOut = Mathf.Clamp(numOut, 0, buffer.Count);
        for (int i = 0; i < numOut; i++)
        {
            var elm = buffer.Dequeue();
            var lat = elm.OnComplete(time);

            latencies[latencyIndex] = lat;
            latencyIndex = (latencyIndex + 1) % historySize;
        }

        // in
        var rawIn = fracIn + rateIn * dt;
        var numIn = (int)rawIn;
        fracIn = rawIn - numIn;
        for (int i = 0; i < numIn; i++)
        {
            var elm = new Element(time);
            buffer.Enqueue(elm);
        }

        // history
        historyIn[historyIndex] = numIn;
        historyOut[historyIndex] = numOut;
        historyBuffer[historyIndex] = buffer.Count;
        historyIndex = (historyIndex + 1) % historySize;
        bufferCount.value = buffer.Count;

        // render
        RenderLine(rendererIn, historyIn, positions);
        RenderLine(rendererOut, historyOut, positions);
        RenderLine(rendererBuffer, historyBuffer, positions);
        RenderLine(rendererLatency, latencies, positions);
    }

    private static void RenderLine(LineRenderer renderer, int[] history, Vector3[] positions)
    {
        for (int i = 0; i < historySize; i++) positions[i] = new Vector3(i, history[i], 0);
        renderer.SetPositions(positions);
    }

    private static void RenderLine(LineRenderer renderer, float[] history, Vector3[] positions)
    {
        for (int i = 0; i < historySize; i++) positions[i] = new Vector3(i, history[i], 0);
        renderer.SetPositions(positions);
    }
}

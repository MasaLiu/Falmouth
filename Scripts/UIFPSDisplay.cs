using UnityEngine;
using UnityEngine.UI;

public class UIFPSDisplay : MonoBehaviour
{
    public Text fpsText;
    public float updateInterval = 1.0f; // Update interval in seconds

    private float frames = 0;
    private float elapsedTime = 0;

    private void Start()
    {
        if (fpsText == null)
        {
            Debug.LogError("Please assign a Text component to display the FPS!");
            enabled = false;
            return;
        }

        // Set initial FPS text
        fpsText.text = "0";
    }

    private void Update()
    {
        // Accumulate frames and elapsed time
        frames++;
        elapsedTime += Time.deltaTime;

        // When elapsed time exceeds the update interval, update the FPS text
        if (elapsedTime >= updateInterval)
        {
            // Calculate average FPS and display it in the text
            float fps = frames / elapsedTime;
            fpsText.text = Mathf.RoundToInt(fps).ToString();

            // Reset counters and elapsed time
            frames = 0;
            elapsedTime = 0;
        }
    }
}

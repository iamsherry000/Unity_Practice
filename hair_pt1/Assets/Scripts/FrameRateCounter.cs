using UnityEngine;
using TMPro;

//best frame rate
//the average
//the worst 

public class FrameRateCounter : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI display = default;

    public enum DisplayMode { FPS, MS }

    [SerializeField]
    DisplayMode displayMode = DisplayMode.FPS;
    
    [SerializeField, Range(0.1f, 2f)]
    float sampleDuration = 1f;
    int frames;
    float duration,bestDuration = float.MaxValue,worstDuration;

    void Start()
    {
        
    }

    void Update()
    {
        // to display the frame rate we need to know how much time has passed between the previous and current frame.//
        // Time.deltaTime 受時間調整的時間刻度限制， 所以使用 Time.unscaledDeltaTime代替//
        float frameDuration = Time.unscaledDeltaTime;
        //display.SetText("FPS\n{0:0}\n000\n000",1f/frameDuration);
        frames += 1;
        duration += frameDuration;
        //display.SetText("FPS\n{0:0}\n000\n000", frames/duration);
        //Average frame rate over one second.//
        if (frameDuration < bestDuration) {
            bestDuration = frameDuration;
        }
        if (frameDuration > worstDuration) {
            worstDuration = frameDuration;
        }
        
        if (duration >= sampleDuration) {
            if (displayMode == DisplayMode.FPS)
            {
                display.SetText("FPS\n{0:0}\n{1:0}\n{2:0}", 1f / bestDuration, frames / duration, 1f / worstDuration);
            }
            else
            {
                display.SetText("MS\n{0:1}\n{1:1}\n{2:1}", 1f /1000f * bestDuration, 1000f * duration/frames,1000f*worstDuration);
            }
            frames = 0;
            duration = 0f;
            bestDuration = float.MaxValue;
            worstDuration = 0f;
        }
        
    }
}

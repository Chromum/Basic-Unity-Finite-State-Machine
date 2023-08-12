[System.Serializable]
public class Countdown
{
    public float totalTime;
    public float remainingTime;
    public bool isRunning;

    // Constructor to create a Countdown with a specified duration
    public Countdown(float duration)
    {
        totalTime = duration;
        remainingTime = duration;
        isRunning = false;
    }

    // Start the countdown
    public void Start()
    {
        isRunning = true;
    }

    // Stop the countdown
    public void Stop()
    {
        isRunning = false;
    }

    // Update the countdown
    public void Update(float deltaTime)
    {
        if (isRunning)
        {
            remainingTime -= deltaTime;
            if (remainingTime <= 0f)
            {
                remainingTime = 0f;
                isRunning = false;
            }
        }
    }

    // Get the remaining time
    public float GetRemainingTime()
    {
        return remainingTime;
    }

    // Get the total duration of the countdown
    public float GetTotalTime()
    {
        return totalTime;
    }

    // Check if the countdown is still running
    public bool IsRunning()
    {
        return isRunning;
    }

    // Check if the countdown has finished
    public bool IsFinished()
    {
        return remainingTime <= 0f;
    }

    // Reset the countdown to its initial duration
    public void Reset()
    {
        remainingTime = totalTime;
        isRunning = false;
    }

    // Get the current state of the time on a 0-1 scale
    public float GetNormalizedTime()
    {
        if (totalTime <= 0f) return 0f;

        return 1f - (remainingTime / totalTime);
    }
}
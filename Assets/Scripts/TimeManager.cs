using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
	public static TimeManager instance;

    private float targetTimeScale;
    private const float fixedDeltaMagnitude = 0.02f;

    public static void Initialize()
    {
        TimeManager me = new GameObject("@TimeManager").AddComponent<TimeManager>();
        me.SetUp();
    }

    private void SetUp()
    {
		if(instance == null)
			instance = this;

        targetTimeScale = 1f;
    }

    void Update()
    {
        Time.timeScale = Mathf.Lerp(Time.timeScale, targetTimeScale, Time.unscaledDeltaTime);
        Time.fixedDeltaTime = Time.timeScale * fixedDeltaMagnitude;
    }

    public void SetTimeScaleTarget(float value)
    {
        targetTimeScale = value;
    }

    public void ResetTimeScale()
    {
        targetTimeScale = 1;
        Time.timeScale = 1;
        Time.fixedDeltaTime = fixedDeltaMagnitude;
    }
}

using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    public Text timer;
    // Update is called once per frame
    private void Update()
    {
        // In order to convert a floating point number into a time the player can understand it must be converted into a TimeSpan object
        // https://learn.microsoft.com/en-us/dotnet/api/system.timespan.fromseconds?view=netframework-4.8
        TimeSpan timeSpan = TimeSpan.FromSeconds(GameManager.Timer);

        // Simply calling timeSpan.ToString() will work, but lack proper formatting, following this documentation:
        // https://learn.microsoft.com/en-us/dotnet/api/system.timespan.tostring?view=net-7.0
        // I see that 'hh,mm,ss' will allow me to properly represent the time as I would like

        // Now for the culture code. In the TimeSpan example they use 'CultureInfo' so I'll use that method too:
        // https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo?view=net-7.0
        // "The format for the culture name based on RFC 4646 is languagecode2-country/regioncode2", this information
        // in combination with this page: "https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-lcid/a9eac961-e77d-41a6-90a5-ce1a8b0cdb9c"
        // means I'm able to see that the culture code I want is 'en-GB'. 
        timer.text = timeSpan.ToString("hh':'mm':'ss", new CultureInfo("en-GB"));
    }
}

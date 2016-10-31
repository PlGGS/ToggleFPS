using GTA;
using System;
using System.Windows.Forms;

class ToggleFPS : Script
{
    bool boolKey = false;
    Keys toggle_fps;
    int update;

    public ToggleFPS()
    {
        ScriptSettings config = ScriptSettings.Load(@"scripts\ToggleFPS.config");
        toggle_fps = config.GetValue<Keys>("SETTINGS", "toggle_fps", Keys.F7);
        update = config.GetValue<int>("SETTINGS", "counter_update_speed", 100);

        KeyUp += OnKeyUp;
        Tick += OnTick;
        Interval = update;
    }
    
    private void OnKeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == toggle_fps)
        {
            if (boolKey)
            {
                boolKey = false;
            } else if (!boolKey)
            {
                boolKey = true;
            }
        }
    }

    private void OnTick(object sender, EventArgs e)
    {
        int fps = Convert.ToInt32(Game.FPS);

        if (boolKey)
        {
            UI.ShowSubtitle("FPS: " + fps, update);
        }
    }
    
}
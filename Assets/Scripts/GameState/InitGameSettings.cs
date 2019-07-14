using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Container for settings to run game.
/// Ex./ Which keys are bound to players?
/// </summary>
public class InitGameSettings
{
    
    public HashSet<KeyCode> playerControls;

    public InitGameSettings()
    {
        playerControls = new HashSet<KeyCode>();
    }
}


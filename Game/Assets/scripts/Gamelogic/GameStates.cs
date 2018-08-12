using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    /// <summary>
    /// The Game is not running and waiting for the player to start the game
    /// </summary>
    Menu,
    /// <summary>
    /// not running but still in a run
    /// </summary>
    PauseMenu,
    /// <summary>
    /// In-Game, but the Game is waiting for the playerinput
    /// </summary>
    Idle,
    /// <summary>
    /// There was userinput and animations have to play out
    /// </summary>
    Processing,
    /// <summary>
    /// There is currently nothing todo for the Player except wait, so the game starts to skip turns (short state, few frames to change to Processing)
    /// </summary>
    /// <remarks>
    /// this is just a temporary Step to skip the player input step
    /// </remarks>
    Skipping
}
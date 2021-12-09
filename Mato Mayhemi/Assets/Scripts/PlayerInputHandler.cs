using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Player player;

    void Awake() 
    {
        playerInput = GetComponent<PlayerInput>();

        var players = FindObjectsOfType<Player>();
        var index = playerInput.playerIndex;

        player = players.FirstOrDefault(p => p.GetPlayerIndex() == index);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if(player != null)
            player.moveHor = ctx.ReadValue<float>();
    }

    public void OnAdjustRope(InputAction.CallbackContext ctx)
    {
        if(player != null)
            player.moveVer = ctx.ReadValue<float>();
    }

    public void OnAimHor(InputAction.CallbackContext ctx)
    {
        if(player != null)
            player.aimHor = ctx.ReadValue<float>();
    }
    public void OnAimVer(InputAction.CallbackContext ctx)
    {
        if(player != null)
            player.aimVer = ctx.ReadValue<float>();
    }

    public void OnShoot(InputAction.CallbackContext ctx)
    {
        if(player != null)
            player.isShoot = ctx.action.triggered;
    }
        

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if(player != null)
            player.isJump = ctx.action.triggered;
    }

    public void OnRope(InputAction.CallbackContext ctx)
    {
        if(player != null)
            player.isRope = ctx.action.triggered;
    }

    public void OnSwitch(InputAction.CallbackContext ctx)
    {
        if(player != null)
            player.isSwitch = ctx.action.triggered;
    }
}

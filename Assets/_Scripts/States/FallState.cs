using System.Net.Security;
using System.Runtime.InteropServices;
using UnityEngine;

public class FallState : MovementState //to move when falling
{
    [SerializeField]
    protected State ClimbState;
    
    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.fall);

    }

    protected override void HandleJumpPressed() 
    { 
        //Don't allow jumping in fall state
    }
    public override void StateUpdate()
    {
        movementData.currentVelocity = agent.rb2d.velocity;
        movementData.currentVelocity.y += agent.agentData.gravityModifier * Physics2D.gravity.y
            * Time.deltaTime;
        agent.rb2d.velocity = movementData.currentVelocity;

        CalculateVelocity();
        SetPlayerVelocity();

        if(agent.groundDetector.isGrounded)
        {
            agent.TransitionToState(IdleState);
        }
        else if(agent.climbingDetector.CanClimb && 
            Mathf.Abs(agent.agentInput.MovementVector.y) > 0)
        {
            agent.TransitionToState(ClimbState);
        }
    }





}

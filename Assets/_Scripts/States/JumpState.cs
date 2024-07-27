using UnityEngine;
using UnityEngine.UIElements;

public class JumpState : MovementState
{

    private bool jumpPressed = false;
    [SerializeField]
    protected State ClimbState;

    protected override void EnterState()
    {
        agent.animationManager.PlayAnimation(AnimationType.jump);
        //to stop from sliding after jumping:
        if (agent.groundDetector.isGrounded)
        {
            //when transitioning from falling to idle, refresh movement
            agent.rb2d.velocity = Vector2.zero; //this could be stopping the player too much after jumping tho.
            //maybe create somethng here for slippery ground
        }

        movementData.currentVelocity = agent.rb2d.velocity;
        movementData.currentVelocity.y = agent.agentData.jumpForce;
        agent.rb2d.velocity = movementData.currentVelocity;

        jumpPressed = true;
    }
    protected override void HandleJumpPressed()
    {
        jumpPressed = true;
    }
    protected override void HandleJumpReleased()
    {
        jumpPressed = false;
    }
    public override void StateUpdate()
    {
        ControlJumpHeight();
        CalculateVelocity(); //for movement
        SetPlayerVelocity(); //for movement
        if (agent.rb2d.velocity.y <= 0)
        {
            agent.TransitionToState(FallState);
        }
        else if(agent.climbingDetector.CanClimb &&
            Mathf.Abs(agent.agentInput.MovementVector.y) > 0)
        {
            agent.TransitionToState(ClimbState);
        }

    }

    private void ControlJumpHeight()
    {
        if (jumpPressed == false) //for falling faster
        {
            movementData.currentVelocity = agent.rb2d.velocity;
            movementData.currentVelocity.y += agent.agentData.lowJumpMultiplier * Physics2D.gravity.y
                * Time.deltaTime;
            agent.rb2d.velocity = movementData.currentVelocity;
        }
    }
}

using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public Collider2D agentCollider;
    public LayerMask groundMask;
    public bool isGrounded = false;
    [Header("Gizmos parameters:")]
    [Range(-2f, 2f)]
    public float boxCastYOffset = -0.1f;
    [Range(-2f, 2f)]
    public float boxCastXOffset = -0.1f;
    [Range(0, 2)]
    public float boxCastWidth = 1, boxCastHeight = 1;
    public Color gizmoColorNotGrounded = Color.red, gizmosColorIsGrounded = Color.green;

    private void Awake()
    {
        if (agentCollider == null)
            agentCollider = GetComponent<Collider2D>();
    }

    public void CheckIsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(agentCollider.bounds.center + new Vector3(boxCastXOffset, boxCastYOffset, 0),
            new Vector2(boxCastWidth, boxCastHeight), 0, Vector2.down, 0, groundMask);

        if (raycastHit.collider != null)
        {
            if (raycastHit.collider.IsTouching(agentCollider) == true)
            {
                isGrounded = true; //wrap in this nested if statement for Platform Effector checks
                //now the red won't go green at the bottom of the platform tile.
            }
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (agentCollider == null)
            return;
        Gizmos.color = gizmoColorNotGrounded;
        if (isGrounded)
        {
            Gizmos.color = gizmosColorIsGrounded;
        }

        Gizmos.DrawWireCube(agentCollider.bounds.center +
            new Vector3(boxCastXOffset, boxCastYOffset, 0),
            new Vector3(boxCastWidth, boxCastHeight));
    }
}

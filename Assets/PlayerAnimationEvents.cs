using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }

    public void DamageEnemies() => player.DamageEnemies();

    private void EnableMovementAndJump()
    {
        player.EnableMovementAndJump();
    }

    private void DisableMovementAndJump() => player.EnableMovementAndJump(false);

}

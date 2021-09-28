public class ShootCommand : Command
{

    PlayerShooting playerShooting;

    public ShootCommand(PlayerShooting _playerShooting)
    {
        playerShooting = _playerShooting;
    }

    public override void Execute()
    {
        //Player menembak
        playerShooting.Shoot();
    }

    public override void UnExecute()
    {

    }
}
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] ProjectPlayer player;

    public override void InstallBindings()
    {
        InstallPlayerComponent();
        InstallPlayerStates();
        InstallCamera();
    }

    private void InstallPlayerComponent()
    {
        Container
            .Bind<ProjectPlayer>()
            .FromInstance(player)
            .AsSingle()
            .NonLazy();
    }

    private void InstallPlayerStates()
    {
        Container.Bind<IdleState>().AsSingle();
        Container.Bind<MoveState>().AsSingle();
        Container.Bind<JumpState>().AsSingle();
        Container.Bind<DashState>().AsSingle();
        Container.Bind<LongRangeAttackState>().AsSingle();
        Container.Bind<DrainState>().AsSingle();
    }

    private void InstallCamera()
    {

    }
}
namespace IAMPM.Services.Interfaces
{
    public interface IConfigurationService
    {
        int MaxPlayersCount { get; }
        int MinPlayersCount { get; }
        int DefStartDevCardsCount { get; }
        int DefStartProjectWorkload { get; }
        int DefStartProjectPeriod { get; }
    }
}
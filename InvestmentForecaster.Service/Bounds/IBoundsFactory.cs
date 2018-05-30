namespace InvestmentForecaster.Service.Bounds
{
    public interface IBoundsFactory
    {
        IBounds GetBounds(string riskLevel);
    }
}
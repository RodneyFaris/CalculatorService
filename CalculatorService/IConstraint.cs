namespace CalculatorService
{
    public interface IConstraint
    {
        bool IsValid(int value);
    }
}
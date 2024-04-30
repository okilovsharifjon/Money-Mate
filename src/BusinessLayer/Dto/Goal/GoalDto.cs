

namespace BusinessLayer
{
    public readonly record struct GoalDto
        (
        int UserId,
        string Name,
        decimal AmountOfMoney,
        DateTime Term
        );
}

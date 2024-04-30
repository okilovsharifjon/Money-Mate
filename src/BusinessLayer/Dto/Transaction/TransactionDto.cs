using DataAccess;


namespace BusinessLayer
{
    public readonly record struct TransactionDto
        (
        int UserId,
        DateTime Time,
        TransactionType Type,
        decimal Amount,
        string Category,
        string Description
        );
}

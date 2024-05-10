using DataAccess;


namespace BusinessLayer
{
    public readonly record struct TransactionDto
        (
        int UserId,
        int AccountId,
        DateTime Time,
        TransactionType Type,
        decimal Amount,
        string Category,
        string Description
        );
}

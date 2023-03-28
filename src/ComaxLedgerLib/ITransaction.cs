namespace CommunAxiom.Ledger.ComaxProcessor
{
    public interface ITransaction<in TEntity>
        where TEntity:class, new()
    {
        byte[] CreateTransaction(TEntity data);
    }
}
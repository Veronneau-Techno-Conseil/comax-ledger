using CommunAxiom.Ledger.Api.Contracts;
using CommunAxiom.Ledger.ComaxProcessor;

namespace ComaxLedgerApi
{
    public class HttpClientHelper
    {
        private readonly ITransaction<IntKeyEntity> _transaction;
        public HttpClientHelper(ITransaction<IntKeyEntity> transaction)
        {
            _transaction = transaction;
        }
    
        public ByteArrayContent CreateContent(IntKeyEntity data)
        {
            var payload = _transaction.CreateTransaction(data);
            var content = new ByteArrayContent(payload);
            content.Headers.Add("Content-Type", "application/octet-stream");
            return content;
        }
    }
}
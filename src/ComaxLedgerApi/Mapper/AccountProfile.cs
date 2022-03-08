using AutoMapper;

namespace ComaxLedgerApi.Mapper
{
    public class AccountProfile: AutoMapper.Profile, IValueConverter<CommunAxiom.Ledger.Api.Contracts.Account, CommunAxiom.Ledger.Contracts.Account.Types.AccountDetail>
    {
        public AccountProfile(): base()
        {
            this.CreateMap<CommunAxiom.Ledger.Api.Contracts.Account, CommunAxiom.Ledger.Contracts.Account>()
                .ForMember(x => x.PublicKey, y => y.Ignore())
                .ForMember(x => x.Assets, y => y.Ignore())
                .ForMember(x => x.Details, y => y.ConvertUsing<AccountProfile, CommunAxiom.Ledger.Api.Contracts.Account>(x => x));

        }

        public CommunAxiom.Ledger.Contracts.Account.Types.AccountDetail Convert(CommunAxiom.Ledger.Api.Contracts.Account sourceMember, ResolutionContext context)
        {
            return new CommunAxiom.Ledger.Contracts.Account.Types.AccountDetail
            {
                DateOfBirth = sourceMember.BirthDate.Ticks.ToString()

            };
        }
    }
}

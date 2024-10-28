using DigitalKabadiApp.Core.Models.Response;

namespace DigitalKabadiApp.Infrastructure.Repositories
{
    public interface IMasterDataRepository
    {
        List<MasterData> GetMasterData();
        List<PincodeDetails> GetPincodeDetails(string pincode);
    }
}
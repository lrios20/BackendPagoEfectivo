using System.Threading.Tasks;
using PagoEfectivoApi.Models;
using PagoEfectivoApi.Requests;

namespace PagoEfectivoApi.Interfaces
{
    public interface ICodePromotionWriteable
    {
         Task CreateCodePromotion(CodePromotionRequestCreate obj);
         Task RedeemCodePromotion(CodePromotionRequestRedeemed obj);
    }
}
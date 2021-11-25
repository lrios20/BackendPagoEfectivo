using System.Collections.Generic;
using System.Threading.Tasks;
using PagoEfectivoApi.Models;

namespace PagoEfectivoApi.Interfaces
{
    public interface ICodePromotionReadable
    {
         Task<IEnumerable<codePromotion>> GetAll();
    }
}
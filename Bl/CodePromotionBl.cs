using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PagoEfectivoApi.Enums;
using PagoEfectivoApi.Interfaces;
using PagoEfectivoApi.Models;
using PagoEfectivoApi.Requests;
using PagoEfectivoApi.Resources;

namespace PagoEfectivoApi.Bl
{
    public class CodePromotionBl : ICodePromotionReadable, ICodePromotionWriteable
    {
        private readonly DbPagoEfectivoContext _dbContext;
        public CodePromotionBl(DbPagoEfectivoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateCodePromotion(CodePromotionRequestCreate obj)
        {
            try
            {
                var codePromotion = await _dbContext.codePromotions.SingleOrDefaultAsync(x => x.mail == obj.mail);

                if (codePromotion != null) throw new Exception($"Ya se genero un codigo con el email ingresado.");
                var entidad = obj.MapTo<codePromotion>();
                entidad.insertDate = DateTime.Now;
                entidad.statusId = (int)StatusCodePromotion.Generated;
                entidad.code = $"{Constants.SiglaPg}{Utils.GetLetters(obj.mail)}{Utils.GenerateRandoNumbers()}";

                _dbContext.codePromotions.Add(entidad);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<codePromotion>> GetAll()
        {
            try
            {
                return await _dbContext.codePromotions.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task RedeemCodePromotion(CodePromotionRequestRedeemed obj)
        {
            try
            {
                var codePromotion = await _dbContext.codePromotions.SingleOrDefaultAsync(x => x.code == obj.code);

                if (codePromotion == null) throw new Exception($"El codigo {obj.code} no existe.");
                if (codePromotion.statusId == (int)StatusCodePromotion.Redeemed) throw new Exception($"El codigo ya fue canjeado.");

                codePromotion.statusId = (int)StatusCodePromotion.Redeemed;
                codePromotion.updateDate = DateTime.Now;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
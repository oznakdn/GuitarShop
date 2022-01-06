using System.Collections.Generic;
using GuitarShop.WebApi.Models.Entities;
using GuitarShop.WebApi.Models.ViewModels.GuitarViewModels;

namespace GuitarShop.WebApi.DataAccess.Abstract
{
    public interface IGuitarRepo:IRepository<Guitar>
    {
         void SoftDelete(int id);
         List<GetAllGuitarsModel>GetAllGuitars();
         List<Guitar>GetAllGuitarsModel();
         public Guitar GetGuitar(string code);
    }
}
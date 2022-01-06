using System.Collections.Generic;
using GuitarShop.WebApi.Models.Entities;
using GuitarShop.WebApi.Models.ViewModels.GuitarViewModels;

namespace GuitarShop.WebApi.Business.Abstract
{
    public interface IGuitarService
    {

        Guitar Add(Guitar entity);
        Guitar Update (Guitar entity);
        void SoftDelete(int id);
        List<GetAllGuitarsModel>GetAllGuitars();
        List<Guitar>GetAllGuitarsModel();
        Guitar GetGuitar(string code);
        GetGuitarModel GetGuitarByCode(string code);

        void AddGuitar(CreateGuitarModel model);
        void UpdateGuitar(UpdateGuitarModel model, string code);
    }
}
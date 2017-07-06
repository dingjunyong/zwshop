using System.Collections.Generic;

namespace ZwShop.Services.Directory
{

    public partial interface IStateProvinceService
    {
        void DeleteStateProvince(int stateProvinceId);

        StateProvince GetStateProvinceById(int stateProvinceId);

        StateProvince GetStateProvinceByAbbreviation(string abbreviation);
        
        List<StateProvince> GetStateProvincesByCountryId(int countryId);

        void InsertStateProvince(StateProvince stateProvince);

        void UpdateStateProvince(StateProvince stateProvince);
    }
}

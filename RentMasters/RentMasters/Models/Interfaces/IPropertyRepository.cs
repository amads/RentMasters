using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentMasters.Models.Interfaces
{
    public interface IPropertyRepository
    {
        List<Property> GetAll();
        Property GetPropertyById(int propertyId);
        void AddNewProperty(Property property);
        void DeleteProperty(int propertyId);
        void EditProperty(Property property);
    }
}

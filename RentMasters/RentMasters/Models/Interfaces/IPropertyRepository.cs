using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RentMasters.Models.Interfaces
{
    public interface IPropertyRepository
    {
        List<Property> GetAllProperties();
        Property GetPropertyById(int propertyId);
        int AddNewProperty(Property property, Address address, Owner owner);
        void DeleteProperty(Property property, Owner owner, Address address);
        int EditProperty(Property property);
    }
}

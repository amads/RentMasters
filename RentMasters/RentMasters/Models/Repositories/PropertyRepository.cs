using RentMasters.Models.Database;
using RentMasters.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentMasters.Models.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DatabaseContext _databaseContext;

        public PropertyRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Property> GetAll()
        {
            return _databaseContext.Properties.ToList();
        }

        public Property GetPropertyById(int propertyId)
        {
            return _databaseContext.Properties.Where(property => property.Id == propertyId).FirstOrDefault();
        }

        public void AddNewProperty(Property property)
        {
            Property p = new Property();
            p.Type = property.Type;
            p.Description = property.Description;
            p.Rooms = property.Rooms;
            p.Area = property.Area;
            p.Washer = property.Washer;
            p.Refrigerator = p.Refrigerator;
            p.Iron = property.Iron;

            p.OwnerId = p.OwnerId;
            p.Owner = property.Owner;

            p.AddressId = property.AddressId;
            p.Address = property.Address;

            _databaseContext.Add(p);
            _databaseContext.SaveChanges();
        }

        public void DeleteProperty(int propertyId)
        {
            _databaseContext.Properties.Remove(GetPropertyById(propertyId));
        }

        public void EditProperty(Property property)
        {
            // sie dorobi
        }

    }
}

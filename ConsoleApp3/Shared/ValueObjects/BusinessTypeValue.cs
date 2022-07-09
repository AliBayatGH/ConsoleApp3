using Hasti.Framework.Domain;
using System.Collections.Generic;

namespace HIT.Hastim.IDR.Domain.Shared.ValueObjects
{
    public class BusinessTypeValue : ValueObject
    {
        private BusinessTypeValue()
        {

        }
        public BusinessTypeValue(string businessTypeCode, long businessTypeValueCode, string name)
        {
            TypeCode = businessTypeCode;
            ValueCode = businessTypeValueCode;
            ValueName = name;
        }

        /// <summary>
        /// The parent of general data. example : "1000005" which is for GeoTypes
        /// </summary>
        public string TypeCode { get; set; }

        /// <summary>
        /// The code for value of general data. example : 1 for Country in GeoType 
        /// </summary>
        public long ValueCode { get; set; }

        /// <summary>
        /// The string value of general data. example : Counrty  in Geo
        /// </summary>
        public string ValueName { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return TypeCode;
            yield return ValueCode;
        }
    }
}
/* example:

public class Geo : AggregateRoot<long>
{
   public BusinessTypeValue Gender { get; private set; }
} 


*/


/*  EntityConfiguration
 *  
 *  
 *  
 *   {
 *      "businessTypeCode": "1000003",
 *       "code": 2,
 *       "name": "زن",
 *       }
 *      
               
           
        builder.OwnsOne(p => p.Gender, o =>
        {
            o.Property(q => q.TypeCode)
            .HasColumnName(nameof(Geo.Gender) + nameof(BusinessTypeValue.TypeCode))
            .HasColumnType(SqlDbType.NVarChar.ToString())
            .HasMaxLength(20)
            .IsRequired(false);

            o.Property(q => q.ValueCode)
             .HasColumnName(nameof(Geo.Gender) + nameof(BusinessTypeValue.ValueCode))
             .HasColumnType(SqlDbType.BigInt.ToString())
             .IsRequired(false);

            o.Property(q => q.ValueName)
            .HasColumnName(nameof(Geo.Gender) + nameof(BusinessTypeValue.ValueName))
            .HasColumnType(SqlDbType.NVarChar.ToString())
            .HasMaxLength(150)
            .IsRequired(false);

        });
 
 
 
 */
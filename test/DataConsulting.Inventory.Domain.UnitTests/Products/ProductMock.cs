using DataConsulting.Inventory.Domain.Products.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Domain.UnitTests.Products
{
    internal class ProductMock
    {





        public static readonly AdjustmentFactors AdjustmentFactors = new AdjustmentFactors(
            WeightFactor: 1.2m,
            UsageFactor: 0.9m,
            ConditioningFactor: 1.1m,
            LossFactor: 0.8m
        );

        public static readonly Expiration Expiration = new Expiration(
            HasExpiration: true,
            DurationDays: 1,
            PreExpirationDays: 2
        );

        public static readonly GeneralProperties GeneralProperties = new GeneralProperties(
            isImported: true,        
            hasDrawback: false,      
            isCompositeProduct: true  
        );


        public static readonly LogisticsProperties LogisticsProperties = new LogisticsProperties(
            TrackingType: "String",
            CatalogType: "String"
        );


        public static readonly PhysicalProperties PhysicalProperties = new PhysicalProperties(
            Weight: 1.2m,
            Volume: 0.9m
       );

        public static readonly Taxation Taxation = new Taxation(
            ForeignVAT: true,
            ICBPERApplicable: true,
            VATApplicable: true,
            VATPercentage: 1.2m,
            ISCApplicable: true,
            ISCPercentage: 1.2m,
            Perception: 1.2m,
            Withholding: 1.2m
      );

    }
}

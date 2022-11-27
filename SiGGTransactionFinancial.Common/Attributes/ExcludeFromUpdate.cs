using System;

namespace SiGGTransactionFinancial.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ExcludeFromUpdate : Attribute
    {

    }
}
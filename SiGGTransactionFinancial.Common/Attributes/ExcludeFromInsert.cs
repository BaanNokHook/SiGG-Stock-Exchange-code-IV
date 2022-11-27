using System;

namespace SiGGTransactionFinancial.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ExcludeFromInsert : Attribute
    {

    }
}
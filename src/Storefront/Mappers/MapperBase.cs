using System.Globalization;

namespace Cabify.Storefront.Mappers
{
    public abstract class MapperBase
    {
        protected static readonly CultureInfo Portugal = new CultureInfo("pt-PT");

        protected string ToPriceString(decimal? price)
        {
            // Prices assume PT location/format/currency for simplicity
            return price?.ToString("C", Portugal);
        }
    }
}
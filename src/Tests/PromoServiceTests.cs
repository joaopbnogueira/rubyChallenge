using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Cabify.DataRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cabify.DomainModels;
using Cabify.Storefront.Services;

namespace Cabify.Tests
{
    [TestClass]
    public class PromoServiceTests
    {
        static readonly IPromoEngine PromoEngine = new PromoEngine();
        static readonly IMapper Mapper;
        private readonly DataRepository.Entities.Product _tshirtEntity;
        private readonly DataRepository.Entities.Product _voucherEntity;

        static PromoServiceTests()
        {
            AutoMapper.Mapper.Initialize(expression => expression.AddProfiles(typeof(MapperProfile)));
            Mapper = AutoMapper.Mapper.Instance;
        }

        public PromoServiceTests()
        {            
            _tshirtEntity = UseDataRepositoryExtension.BaseProducts.FirstOrDefault(p => p.Id == "TSHIRT");
            _voucherEntity = UseDataRepositoryExtension.BaseProducts.FirstOrDefault(p => p.Id == "VOUCHER");
        }

        [TestMethod]
        public void PromoPriceAppliedForBulkTshirtOrders()
        {
            var products = GetTshirts(3);
            var promoProducts = PromoEngine.ApplyPromos(products);
            Assert.IsTrue(promoProducts.All(p => p.PromoPrice == 19.00m));
        }

        [TestMethod]
        public void NormalPriceAppliedForRegularTshirtOrders()
        {
            var products = GetTshirts(2);
            var promoProducts = PromoEngine.ApplyPromos(products);
            Assert.IsTrue(promoProducts.All(p => p.PromoPrice == null));
        }

        [TestMethod]
        public void PromoPriceAppliedForForVoucherOrders()
        {
            var products = GetVouchers(75);
            var promoProducts = PromoEngine.ApplyPromos(products);
            Assert.IsTrue(promoProducts.Count(p => p.PromoPrice == 0.00m) == 37);
            Assert.IsTrue(promoProducts.Count(p => p.PromoPrice == null) == 38);
        }

        private IReadOnlyCollection<Product> GetTshirts(int qty)
        {
            return Enumerable.Range(0, qty).Select(i => Mapper.Map<DataRepository.Entities.Product, Product>(_tshirtEntity)).ToArray();
        }

        private IReadOnlyCollection<Product> GetVouchers(int qty)
        {
            return Enumerable.Range(0, qty).Select(i => Mapper.Map<DataRepository.Entities.Product, Product>(_voucherEntity)).ToArray();
        }
    }
}

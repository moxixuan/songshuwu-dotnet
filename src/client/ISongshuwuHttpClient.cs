using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace songshuwu.client
{
    public interface ISongshuwuHttpClient
    {
        Task<BaseOutput<ShopAddOutput>> ShopAdd(ShopAddInput input);
        Task<BaseOutput<bool>> ShopUpdate(ShopUpdateInput input);
        Task<BaseOutput<List<ShopQueryOutput>>> ShopQuery(ShopQueryInput input);
        Task<BaseOutput<ShopDetailOut>> ShopDetail(ShopDetailInput input);
        Task<BaseOutput<MerchantBalanceOutput>> MerchantBalance(SongshuwuOptions options = null);

        Task<BaseOutput<OrderPriceOutput>> OrderPrice(OrderPriceInput input);
        Task<BaseOutput<OrderAddWithoutShopOutput>> AddWithoutShop(OrderAddWithoutShopInput input, SongshuwuOptions options = null);
        Task<BaseOutput<OrderCancelOutput>> OrderCancel(OrderCancelInput input, SongshuwuOptions options = null);

        Task<BaseOutput<List<ConfigCityOutput>>> ConfigCity();
        Task<BaseOutput<List<ConfigLogisticOutput>>> ConfigLogistic(ConfigLogisticInput input);

        bool VerifySign(object input, string sign, SongshuwuOptions options = null);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace songshuwu.client
{
    public interface ISongshuwuHttpClient
    {
        Task<BaseOutput<OrderAddWithoutShopOutput>> AddWithoutShop(OrderAddWithoutShopInput input);
    }
}

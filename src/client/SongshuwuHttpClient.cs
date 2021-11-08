using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace songshuwu.client
{
    public class SongshuwuHttpClient : ISongshuwuHttpClient
    {
        /// <summary>
        /// The default name used to register the typed HttpClient with the <see cref="IServiceCollection"/>
        /// </summary>
        public const string DefaultName = "SongshuwuHttpClient";

        readonly HttpClient _client;
        readonly ILogger<SongshuwuHttpClient> _logger;
        readonly SongshuwuOptions _options;

        public SongshuwuHttpClient(HttpClient client, ILogger<SongshuwuHttpClient> logger, IOptions<SongshuwuOptions> options)
        {
            _client = client;
            _logger = logger;
            _options = options.Value;
        }

        #region 门店管理

        /// <summary>
        /// 门店创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<BaseOutput<ShopAddOutput>> ShopAdd(ShopAddInput input)
        {
            return await PostAsync<BaseOutput<ShopAddOutput>>("/shop/add/", input);
        }

        /// <summary>
        /// 门店更新
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<BaseOutput<bool>> ShopUpdate(ShopUpdateInput input)
        {
            return await PostAsync<BaseOutput<bool>>("/shop/update/", input);
        }

        /// <summary>
        /// 门店查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<BaseOutput<List<ShopQueryOutput>>> ShopQuery(ShopQueryInput input)
        {
            return await PostAsync<BaseOutput<List<ShopQueryOutput>>>("/shop/query/", input);
        }

        /// <summary>
        /// 余额查询
        /// </summary>
        /// <returns></returns>
        public async Task<BaseOutput<MerchantBalanceOutput>> MerchantBalance(SongshuwuOptions options = null)
        {
            return await PostAsync<BaseOutput<MerchantBalanceOutput>>("/merchant/balance/");
        }

        /// <summary>
        /// 门店详情
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<BaseOutput<ShopDetailOut>> ShopDetail(ShopDetailInput input)
        {
            return await PostAsync<BaseOutput<ShopDetailOut>>("/shop/detail/", input);
        }

        #endregion

        #region 订单管理

        /// <summary>
        /// 计算运费
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<BaseOutput<OrderPriceOutput>> OrderPrice(OrderPriceInput input)
        {
            return await PostAsync<BaseOutput<OrderPriceOutput>>("/order/price/", input);
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<BaseOutput<OrderAddOutput>> OrderAdd(OrderAddInput input)
        {
            return await PostAsync<BaseOutput<OrderAddOutput>>("/order/add/", input);
        }

        /// <summary>
        /// 创建订单【无需建店】
        /// </summary>
        /// <returns></returns>
        public async Task<BaseOutput<OrderAddWithoutShopOutput>> AddWithoutShop(OrderAddWithoutShopInput input, SongshuwuOptions options = null)
        {
            return await PostAsync<BaseOutput<OrderAddWithoutShopOutput>>("/order/addWithoutShop/", input, options);
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="input"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<BaseOutput<OrderCancelOutput>> OrderCancel(OrderCancelInput input, SongshuwuOptions options = null)
        {
            return await PostAsync<BaseOutput<OrderCancelOutput>>("/order/cancel/", input, options);
        }

        #endregion

        #region 附录说明

        /// <summary>
        /// 城市列表
        /// </summary>
        /// <returns></returns>
        public async Task<BaseOutput<List<ConfigCityOutput>>> ConfigCity()
        {
            return await PostAsync<BaseOutput<List<ConfigCityOutput>>>("/config/city/");
        }

        /// <summary>
        /// 城市运力
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<BaseOutput<List<ConfigLogisticOutput>>> ConfigLogistic(ConfigLogisticInput input)
        {
            return await PostAsync<BaseOutput<List<ConfigLogisticOutput>>>("/config/logistic/", input);
        }
        #endregion

        public bool VerifySign(object input, string sign, SongshuwuOptions options = null)
        {
           var param = JsonSerializer.Serialize(input,
                new JsonSerializerOptions()
                {
                    IgnoreNullValues = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });

            string _sign;
            if (options is null)
            {
                _sign = Sign.GetInput(_options.app_key, _options.app_secret, param);
            }
            else
            {
                _sign = Sign.GetInput(options.app_key, options.app_secret, param);
            }

            return _sign == sign;
        }

        private async Task<T> PostAsync<T>(string requestUri, object input = null, SongshuwuOptions options = null)
        {
            var param = JsonSerializer.Serialize(input,
                new JsonSerializerOptions()
                {
                    IgnoreNullValues = true,
                    //Converters = { new JsonStringEnumConverter() },
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });

            StringContent content;
            if (options is null)  {
                content = new StringContent(Sign.GetInput(_options.app_key, _options.app_secret, param));
            }
            else {
                content = new StringContent(Sign.GetInput(options.app_key, options.app_secret, param));
            }
            var httpResponse = await _client.PostAsync(requestUri, content);
            // todo polly
            httpResponse.EnsureSuccessStatusCode();
            var result = await httpResponse.Content.ReadAsStringAsync();
            result = Regex.Unescape(result);
            _logger.LogInformation("songshuwu http" + content.ToString() + param + " " + result);

            return JsonSerializer.Deserialize<T>(result/*, new JsonSerializerOptions() { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping }*/);
        }
    }
}

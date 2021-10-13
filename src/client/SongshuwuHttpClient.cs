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

        /// <summary>
        /// 创建订单【无需建店】
        /// </summary>
        /// <returns></returns>
        public async Task<BaseOutput<OrderAddWithoutShopOutput>> AddWithoutShop(OrderAddWithoutShopInput input)
        {
            var output = await PostAsync<BaseOutput<OrderAddWithoutShopOutput>>("/order/addWithoutShop/", input);
            return output;
        }

        private async Task<T> PostAsync<T>(string requestUri, object input)
        {
            var param = JsonSerializer.Serialize(input, new JsonSerializerOptions() { IgnoreNullValues = true });
            var content = new StringContent(Sign.GetInput(_options.app_key, _options.app_secret, param));
            var httpResponse = await _client.PostAsync(requestUri, content);
            // todo polly
            httpResponse.EnsureSuccessStatusCode();
            var result = await httpResponse.Content.ReadAsStringAsync();
            result = Regex.Unescape(result);
            _logger.LogInformation(param + " " + result);

            return JsonSerializer.Deserialize<T>(result/*, new JsonSerializerOptions() { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping }*/);
        }
    }
}

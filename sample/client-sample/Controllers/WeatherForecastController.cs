using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using songshuwu.client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace client_sample.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        public async Task<object> ShopAdd([FromServices] ISongshuwuHttpClient client)
        {
            var a = await client.ShopAdd(new ShopAddInput()
            {
                origin_id = "GD_1111",
                name = "GD_1111",
                city = "632500",
                phone = "15622992174",
                address = "海南省海口市美兰区南宝路9号欣安花园A座一层东边2号商铺",
                longitude = 110.35m,
                latitude = 20.03m,
                category = Category.超市,
                map_type = MapType.百度,
                config = new ShopConfig()
                {
                    dispatch_mode = 2
                }
            });
            return a;
        }

        [HttpGet]
        public async Task<object> ShopUpdate([FromServices] ISongshuwuHttpClient client)
        {
            var a = await client.ShopUpdate(new ShopUpdateInput()
            {
                origin_id = "GD_1111",
                name = "GD_1111",
                city = "632500",
                phone = "15622992174",
                address = "海南省海口市美兰区南宝路9号欣安花园A座一层东边2号商铺",
                longitude = 110.35m,
                latitude = 20.03m,
                category = Category.超市,
                map_type = MapType.百度,
                config = new ShopConfig()
                {
                    dispatch_mode = 1
                }
            });
            return a;
        }

        [HttpGet]
        public async Task<object> ShopQuery([FromServices] ISongshuwuHttpClient client)
        {
            var a = await client.ShopQuery(new ShopQueryInput()
            {
                offset = 2,
                count = 50
            });
            return a;
        }

        [HttpGet]
        public async Task<object> ShopDetail([FromServices] ISongshuwuHttpClient client)
        {
            var a = await client.ShopDetail(new ShopDetailInput()
            {
                origin_id = "GD_1111"
            });
            return a;
        }

        [HttpGet]
        public async Task<object> MerchantBalance([FromServices] ISongshuwuHttpClient client)
        {
            var a = await client.MerchantBalance();
            return a;
        }

        [HttpGet]
        public async Task<object> AddWithoutShop([FromServices] ISongshuwuHttpClient client)
        {
            var a = await client.AddWithoutShop(new OrderAddWithoutShopInput()
            {
                dispatch_mode = 1,
                shop_id = "HS_琼00369",
                shop_name = "HS_琼00369",
                origin_id = "123",
                order_source = "meituan",
                source_order_no = "27056063581107015",
                order_sn = "2",
                is_subscribe = 0,
                subscribe_time = 0,
                city = "632500",
                sender_longitude = "110.35",
                sender_latitude = "20.03",
                sender_address = "海南省海口市美兰区南宝路9号欣安花园A座一层东边2号商铺",
                sender_phone = "15622992174",
                receiver_longitude = "110.36",
                receiver_latitude = "20.0296",
                receiver_address = "海南省海口市美兰区南宝路10号欣安花园C座三层",
                receiver_address_detail = "海南省海口市美兰区南宝路10号欣安花园C座三层",
                receiver_name = "莫锡轩",
                receiver_phone = "18024333865",
                map_type = ((byte)MapType.百度).ToString(),
                callback_url = "https://cwhadmintest.myj.com.cn/",
                return_price = "1",
                auto_resend = 1
            });
            return a;
        }

        [HttpGet]
        public async Task<object> OrderPrice([FromServices] ISongshuwuHttpClient client)
        {
            var a = await client.OrderPrice(new OrderPriceInput()
            {
                dispatch_mode = 1,
                shop_id = "GD_1111",
                origin_id = "12341234",
                receiver_longitude = "110.36",
                receiver_latitude = "20.0296",
                receiver_address = "海南省海口市美兰区南宝路10号欣安花园C座三层",
                receiver_name = "莫锡轩",
                receiver_phone = "15622992174"
            });
            return a;
        }

        [HttpGet]
        public async Task<object> ConfigCity([FromServices] ISongshuwuHttpClient client)
        {
            var a = await client.ConfigCity();
            return a;
        }

        [HttpGet]
        public async Task<object> ConfigLogistic([FromServices] ISongshuwuHttpClient client)
        {
            var a = await client.ConfigLogistic(new ConfigLogisticInput() 
            {
                city = "632500"
            });
            return a;
        }
    }
}

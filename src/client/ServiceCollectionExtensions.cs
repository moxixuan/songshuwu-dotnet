using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using songshuwu.client;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        //private static readonly Action<HttpClient> DefaultConfigureClientFunction = client =>
        //{
        //    client.BaseAddress = new Uri("http://open.test.maiyatian.com");
        //    client.DefaultRequestHeaders.Add("User-Agent", nameof(SongshuwuHttpClient));
        //};

        /// <summary>
        /// Adds the <see cref="IHttpClientFactory"/> and related services to the <see cref="IServiceCollection"/>
        /// and configures a binding between the <see cref="ISongshuwuHttpClient"/> and a named <see cref="HttpClient"/>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="name">The logical name of the <see cref="HttpClient"/> to configure.</param>
        /// <param name="configureClient">A delegate that is used to configure the <see cref="HttpClient"/> used by <see cref="ISongshuwuHttpClient"/></param>
        /// <returns>An <see cref="IHttpClientBuilder"/>that can be used to configure the client.</returns>
        /// <remarks>
        ///  <see cref="HttpClient"/> instances that apply the provided configuration can
        ///  be retrieved using <see cref="IHttpClientFactory.CreateClient(System.String)"/>
        ///  and providing the matching name.
        ///  <see cref="ISongshuwuHttpClient"/> instances constructed with the appropriate <see cref="HttpClient"/>
        ///  can be retrieved from <see cref="System.IServiceProvider.GetService(System.Type)"/> (and related
        ///  methods) by providing <see cref="ISongshuwuHttpClient"/> as the service type.
        /// </remarks>
        public static IHttpClientBuilder AddSongshuwuHttpClient(this IServiceCollection services, string name, Action<HttpClient> configureClient)
        {
            return services.AddSongshuwuHttpClient(name, configureClient, options => { });
        }

        /// <summary>
        /// Adds the <see cref="IHttpClientFactory"/> and related services to the <see cref="IServiceCollection"/>
        /// and configures a binding between the <see cref="ISongshuwuHttpClient"/> and a named <see cref="HttpClient"/>
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="name">The logical name of the <see cref="HttpClient"/> to configure.</param>
        /// <param name="configureClient">A delegate that is used to configure the <see cref="HttpClient"/> used by <see cref="ISongshuwuHttpClient"/></param>
        /// <param name="configureOptions">A delegate that is used to configure the <see cref="SongshuwuHttpClientOptions"/></param>
        /// <returns>An <see cref="IHttpClientBuilder"/>that can be used to configure the client.</returns>
        /// <remarks>
        ///  <see cref="HttpClient"/> instances that apply the provided configuration can
        ///  be retrieved using <see cref="IHttpClientFactory.CreateClient(System.String)"/>
        ///  and providing the matching name.
        ///  <see cref="ISongshuwuHttpClient"/> instances constructed with the appropriate <see cref="HttpClient"/>
        ///  can be retrieved from <see cref="System.IServiceProvider.GetService(System.Type)"/> (and related
        ///  methods) by providing <see cref="ISongshuwuHttpClient"/> as the service type.
        /// </remarks>
        public static IHttpClientBuilder AddSongshuwuHttpClient(this IServiceCollection services, string name,
            Action<HttpClient> configureClient, Action<SongshuwuOptions> configureOptions)
        {
            services.Configure(configureOptions);
            return services.AddHttpClient<ISongshuwuHttpClient, SongshuwuHttpClient>(name, configureClient);
        }

        /// <summary>
        /// Adds the <see cref="IHttpClientFactory"/> and related services to the <see cref="IServiceCollection"/>
        /// and configures a binding between the <see cref="ISongshuwuHttpClient"/> and an <see cref="HttpClient"/>
        /// named <see cref="SongshuwuHttpClient.DefaultName"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="configureClient">A delegate that is used to configure the <see cref="HttpClient"/> used by <see cref="ISongshuwuHttpClient"/></param>
        /// <returns>An <see cref="IHttpClientBuilder"/>that can be used to configure the client.</returns>
        /// <remarks>
        ///  <see cref="HttpClient"/> instances that apply the provided configuration can
        ///  be retrieved using <see cref="IHttpClientFactory.CreateClient(System.String)"/>
        ///  and providing the matching name.
        ///  <see cref="ISongshuwuHttpClient"/> instances constructed with the appropriate <see cref="HttpClient"/>
        ///  can be retrieved from <see cref="System.IServiceProvider.GetService(System.Type)"/> (and related
        ///  methods) by providing <see cref="ISongshuwuHttpClient"/> as the service type.
        /// </remarks>
        public static IHttpClientBuilder AddSongshuwuHttpClient(this IServiceCollection services, Action<HttpClient> configureClient)
        {
            return services.AddSongshuwuHttpClient(SongshuwuHttpClient.DefaultName, configureClient, options => { });
        }

        /// <summary>
        /// Adds the <see cref="IHttpClientFactory"/> and related services to the <see cref="IServiceCollection"/>
        /// and configures a binding between the <see cref="ISongshuwuHttpClient"/> and an <see cref="HttpClient"/>
        /// named <see cref="SongshuwuHttpClient.DefaultName"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="configureClient">A delegate that is used to configure the <see cref="HttpClient"/> used by <see cref="ISongshuwuHttpClient"/></param>
        /// <param name="configureOptions">A delegate that is used to configure the <see cref="SongshuwuHttpClientOptions"/></param>
        /// <returns>An <see cref="IHttpClientBuilder"/>that can be used to configure the client.</returns>
        /// <remarks>
        ///  <see cref="HttpClient"/> instances that apply the provided configuration can
        ///  be retrieved using <see cref="IHttpClientFactory.CreateClient(System.String)"/>
        ///  and providing the matching name.
        ///  <see cref="ISongshuwuHttpClient"/> instances constructed with the appropriate <see cref="HttpClient"/>
        ///  can be retrieved from <see cref="System.IServiceProvider.GetService(System.Type)"/> (and related
        ///  methods) by providing <see cref="ISongshuwuHttpClient"/> as the service type.
        /// </remarks>
        public static IHttpClientBuilder AddSongshuwuHttpClient(this IServiceCollection services,
            Action<HttpClient> configureClient, Action<SongshuwuOptions> configureOptions)
        {
            return services.AddSongshuwuHttpClient(SongshuwuHttpClient.DefaultName, configureClient, configureOptions);
        }

        ///// <summary>
        ///// Adds the <see cref="IHttpClientFactory"/> and related services to the <see cref="IServiceCollection"/>
        ///// and configures a binding between the <see cref="ISongshuwuHttpClient"/> and an <see cref="HttpClient"/>
        ///// named <see cref="SongshuwuHttpClient.DefaultName"/> to use the public HaveIBeenPwned API 
        ///// at "https://api.pwnedpasswords.com"
        ///// </summary>
        ///// <param name="services">The <see cref="IServiceCollection"/>.</param>
        ///// <returns>An <see cref="IHttpClientBuilder"/>that can be used to configure the client.</returns>
        ///// <remarks>
        /////  <see cref="HttpClient"/> instances that apply the provided configuration can
        /////  be retrieved using <see cref="IHttpClientFactory.CreateClient(System.String)"/>
        /////  and providing the matching name.
        /////  <see cref="ISongshuwuHttpClient"/> instances constructed with the appropriate <see cref="HttpClient"/>
        /////  can be retrieved from <see cref="System.IServiceProvider.GetService(System.Type)"/> (and related
        /////  methods) by providing <see cref="ISongshuwuHttpClient"/> as the service type.
        ///// </remarks>
        //public static IHttpClientBuilder AddSongshuwuHttpClient(this IServiceCollection services)
        //{
        //    return services.AddSongshuwuHttpClient(SongshuwuHttpClient.DefaultName, DefaultConfigureClientFunction);
        //}
    }
}

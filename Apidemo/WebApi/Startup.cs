using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Provider;

namespace WebApi
{
	public class Startup
	{
		public OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

		public void Configuration(IAppBuilder app)
		{
			HttpConfiguration config = new HttpConfiguration();

			ConfigureOAuth(app);

			WebApiConfig.Register(config);
			//config.EnableCors(new EnableCorsAttribute(Properties.Settings.Default.Cors, "", ""));
			app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
			app.UseWebApi(config);
		}

		
		public void ConfigureOAuth(IAppBuilder app)
		{
			OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
			OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
			{
				//For Dev enviroment only (on production should be AllowInsecureHttp = false)
				AllowInsecureHttp = true,
				//TokenEndpointPath = new PathString("/oauth2/token"),
				TokenEndpointPath = new PathString("/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromHours(5),
				Provider = new SimpleAuthorizationServerProvider(),
				//RefreshTokenProvider = new SimpleRefreshTokenProvider(),
				//AccessTokenFormat = new CustomJwtFormat(URL_AS_API)
			};

			// OAuth 2.0 Bearer Access Token Generation
			app.UseOAuthAuthorizationServer(OAuthServerOptions);
			app.UseOAuthBearerAuthentication(OAuthBearerOptions);

			//use a cookie to temporarily store information about a user logging in with a third party login provider            
			app.UseExternalSignInCookie(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ExternalCookie);
		}
	}
}
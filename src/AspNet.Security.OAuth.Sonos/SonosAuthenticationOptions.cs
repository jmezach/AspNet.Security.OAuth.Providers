/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using static AspNet.Security.OAuth.Sonos.SonosAuthenticationConstants;

namespace AspNet.Security.OAuth.Sonos
{
    /// <summary>
    /// Defines a set of options used by <see cref="SonosAuthenticationHandler"/>.
    /// </summary>
    public class SonosAuthenticationOptions : OAuthOptions
    {
        public SonosAuthenticationOptions()
        {
            ClaimsIssuer = SonosAuthenticationDefaults.Issuer;
            Scope.Add("playback-control-all");

            CallbackPath = new PathString(SonosAuthenticationDefaults.CallbackPath);

            AuthorizationEndpoint = SonosAuthenticationDefaults.AuthorizationEndpoint;
            TokenEndpoint = SonosAuthenticationDefaults.TokenEndpoint;
            UserInformationEndpoint = SonosAuthenticationDefaults.UserInformationEndpoint;

            ClaimActions.MapCustomJson(ClaimTypes.NameIdentifier, payload => payload.Value<JArray>("households")?.First?.Value<string>("id"));
        }
    }
}

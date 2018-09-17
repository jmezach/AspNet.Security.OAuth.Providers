/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using System;
using AspNet.Security.OAuth.Sonos;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authentication;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods to add Sonos authentication capabilities to an HTTP application pipeline.
    /// </summary>
    public static class SonosAuthenticationExtensions
    {
        /// <summary>
        /// Adds <see cref="SonosAuthenticationHandler"/> to the specified
        /// <see cref="AuthenticationBuilder"/>, which enables Sonos authentication capabilities.
        /// </summary>
        /// <param name="builder">The authentication builder.</param>
        /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
        public static AuthenticationBuilder AddSonos([NotNull] this AuthenticationBuilder builder)
        {
            return builder.AddSonos(SonosAuthenticationDefaults.AuthenticationScheme, options => { });
        }

        /// <summary>
        /// Adds <see cref="SonosAuthenticationHandler"/> to the specified
        /// <see cref="AuthenticationBuilder"/>, which enables Sonos authentication capabilities.
        /// </summary>
        /// <param name="builder">The authentication builder.</param>
        /// <param name="configuration">The delegate used to configure the OpenID 2.0 options.</param>
        /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
        public static AuthenticationBuilder AddSonos(
            [NotNull] this AuthenticationBuilder builder,
            [NotNull] Action<SonosAuthenticationOptions> configuration)
        {
            return builder.AddSonos(SonosAuthenticationDefaults.AuthenticationScheme, configuration);
        }

        /// <summary>
        /// Adds <see cref="SonosAuthenticationHandler"/> to the specified
        /// <see cref="AuthenticationBuilder"/>, which enables Sonos authentication capabilities.
        /// </summary>
        /// <param name="builder">The authentication builder.</param>
        /// <param name="scheme">The authentication scheme associated with this instance.</param>
        /// <param name="configuration">The delegate used to configure the Sonos options.</param>
        /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
        public static AuthenticationBuilder AddSonos(
            [NotNull] this AuthenticationBuilder builder, [NotNull] string scheme,
            [NotNull] Action<SonosAuthenticationOptions> configuration)
        {
            return builder.AddSonos(scheme, SonosAuthenticationDefaults.DisplayName, configuration);
        }

        /// <summary>
        /// Adds <see cref="SonosAuthenticationHandler"/> to the specified
        /// <see cref="AuthenticationBuilder"/>, which enables Sonos authentication capabilities.
        /// </summary>
        /// <param name="builder">The authentication builder.</param>
        /// <param name="scheme">The authentication scheme associated with this instance.</param>
        /// <param name="caption">The optional display name associated with this instance.</param>
        /// <param name="configuration">The delegate used to configure the Sonos options.</param>
        /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
        public static AuthenticationBuilder AddSonos(
            [NotNull] this AuthenticationBuilder builder,
            [NotNull] string scheme, [CanBeNull] string caption,
            [NotNull] Action<SonosAuthenticationOptions> configuration)
        {
            return builder.AddOAuth<SonosAuthenticationOptions, SonosAuthenticationHandler>(scheme, caption, configuration);
        }
    }
}

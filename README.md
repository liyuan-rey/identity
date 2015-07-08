# identity
A demo application shows usage about [OAuth](http://oauth.net/2/) in both server and client side, based on IdentityServer.

# Specification
[OAuth 2 specification](http://tools.ietf.org/html/rfc6749)

[OpenID Connect specification](http://openid.net/specs/openid-connect-core-1_0.html)

# Frameworks, Components, Libraries and Utilities
This application is coding with [Visual Studio Code](https://www.visualstudio.com/en-us/products/code-vs.aspx) and use many frameworks/components/libraries/utilities, see below:

ASP.Net 5 - You can check the [WebSite](http://www.asp.net/vnext), [Document](http://docs.asp.net/en/latest/) and [codes](https://github.com/aspnet/Home).

Katana Project - Many components of Katana Project are used in the demo, check [WebSite](https://katanaproject.codeplex.com/), [Document](http://katanaproject.codeplex.com/documentation) and [codes](http://katanaproject.codeplex.com/SourceControl/latest).

* Microsoft.Owin - Provides a set of helper types and abstractions for simplifying the creation of OWIN components.

* Microsoft.Owin.Hosting - Provides default infrastructure types for hosting and running OWIN-based applications.

* Microsoft.Owin.Host.HttpListener - OWIN server built on the .NET Framework's HttpListener class. Currently the default server used for self-hosting. See [NuGet](http://www.nuget.org/packages/Microsoft.Owin.Host.HttpListener/).

* Microsoft.Owin.Diagnostics - Provides middleware components to assist in developing OWIN-based applications, i.e., IAppBuilder.UseWelcomePage() and IAppBuilder.UseErrorPage(). The UseWelcomePage extensions can be used to add a simple html page to your application to verify the site is up and running. The UseErrorPage extensions can be used to add an Exception filter to the request pipeline that will display exception and request details. Note that the ErrorPage can only show exceptions that happen in the OWIN pipeline, if error occur in MVC or WebAPI routine, ErrorPage is not applicable.

* Microsoft.Owin.SelfHost - Includes components needed to host an OWIN-based application in a custom process. This is not a component itself, but a combine package of Microsoft.Owin.Hosting, Microsoft.Owin.Host.HttpListener and Microsoft.Owin.Diagnostics.

* OwinHost - Provides a stand-alone executable (OwinHost.exe) which can be used to host an OWIN-based application, use Microsoft.Owin.Host.HttpListener(below) internally. See [NuGet](http://www.nuget.org/packages/OwinHost/).

Note:
You can also use Microsoft.Owin.SelfHost, it is NOT a component itself, but a combine package of Owin, Microsoft.Owin, Microsoft.Owin.Hosting, Microsoft.Owin.Host.HttpListener and Microsoft.Owin.Diagnostics, that makes life easier.

For other option of a webserver which hosts WebAPI as well, you can check [KestrelHttpServer](https://github.com/aspnet/KestrelHttpServer) from ASP.Net.

IdentityServer 3 - Here is the [WebSite](https://github.com/IdentityServer), [Document](https://identityserver.github.io/Documentation/) and [codes](https://github.com/IdentityServer/IdentityServer3)

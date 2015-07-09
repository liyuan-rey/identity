# server-owinhost
server-owinhost is a dummy ASP.Net project, it use OwinHost component (from Katana).

Since OwinHost is a stand-alone executable hosting environment for OWIN-capable application, there is no need for server-owinhost to add actually any code to the project, but only add reference to server-core which obtains application logic and config OwinHost execution params in the project file.

OwinHost use Microsoft.Owin.Host.HttpListener as the default server factory TYPE (use `-s,--server` option to specify custom one) and referenced with Microsoft.Owin.Hosting. For more information about how to use OwinHost, Check `owinhost.exe /?`.

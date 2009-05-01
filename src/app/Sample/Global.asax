<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Mvc"%>
<%@ Import Namespace="Alanta.Mvc"%>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
       // Enable routing of existing files to allow requests to / to be routed
       RouteTable.Routes.RouteExistingFiles = true;
       // Strong typed route to the Home controller
       RouteTable.Routes.MapRoute<Alanta.Mvc.Sample.Home>( "home", "Default.aspx", new {action = "Index"}, null );
    }
  
</script>

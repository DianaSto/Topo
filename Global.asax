﻿<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="System.Web.Http" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    { 

        RouteTable.Routes.MapHttpRoute(
	    name: "DefaultApi",
	    routeTemplate:"api/{controller}/{id}/{date_start}/{date_finish}",
	    defaults: new{id=System.Web.Http.RouteParameter.Optional, date_start=System.Web.Http.RouteParameter.Optional, date_finish=System.Web.Http.RouteParameter.Optional} 
                  
	    );
        

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }


</script>

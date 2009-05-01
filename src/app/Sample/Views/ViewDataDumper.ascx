<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
<div class="block">
<h2>ViewData</h2>
<ul>
<% foreach ( var item in ViewData )
   { %>
   <li> <%= item.Key %> = <%= item.Value %></li>
<% } %>
</ul>
</div>
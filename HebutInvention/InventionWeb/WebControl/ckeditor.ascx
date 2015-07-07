<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ckeditor.ascx.cs" Inherits="InventionWeb.WebControl.ckeditor" %>
    <script type="text/javascript" src="<%=ResolveUrl("~/editor/ckeditor/ckeditor.js")%>"></script>
       <asp:TextBox ID="txtContent" CssClass="ckeditor" TextMode="MultiLine" 
    runat="server" Height="300px" Width="800px"></asp:TextBox>
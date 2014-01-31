<%@ Page Title="Admin" Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Inner.master" CodeFile="default.aspx.cs" Inherits="membership_admin_default" %>

<%@ Register Src="~/UserControl/Membership/Admin/List.ascx" TagName="List" TagPrefix="admin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="Server">
	<h1>System Members</h1>
	<admin:List ID="adminList" runat="server" />
</asp:Content>
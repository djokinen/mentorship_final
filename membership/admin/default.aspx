<%@ Page Title="Admin" Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Inner.master" CodeFile="default.aspx.cs" Inherits="membership_admin_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" Runat="Server">
	<style type="text/css">
		body {
			font-family: arial,sans-serif;
			font-size: 83%;
		}
		h2, h3 {
			text-transform: capitalize;
		}
	</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">

	<h1>Admin Tools</h1>
	<h2>All Members</h2>
	<asp:GridView ID="gridViewAll" runat="server"></asp:GridView>

	<h2>Members by Role</h2>
	<asp:PlaceHolder ID="placeHolder" runat="server"></asp:PlaceHolder>

</asp:Content>
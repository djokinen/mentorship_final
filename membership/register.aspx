<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Inner.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="membership_register" %>

<%@ Register Src="~/UserControl/Membership/Create.ascx" TagName="Create" TagPrefix="membership" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
	<h1>Register</h1>
	<membership:Create ID="membershipCreate" runat="server" />
</asp:Content>
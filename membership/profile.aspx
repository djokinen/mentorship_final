<%@ Page ClientIDMode="Static" Title="Profile" MasterPageFile="~/MasterPage/Inner.master" Language="C#" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="membership_profile" %>

<%@ Register Src="~/UserControl/Membership/Detail.ascx" TagName="Detail" TagPrefix="membership" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
	<h1>Profile</h1>
	<membership:Detail ID="membershipDetail" runat="server" />
</asp:Content>
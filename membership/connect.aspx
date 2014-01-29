<%@ Page ClientIDMode="Static" Title="" Language="C#" MasterPageFile="~/MasterPage/Inner.master" AutoEventWireup="true" CodeFile="connect.aspx.cs" Inherits="membership_connect" %>

<%@ Register Src="~/UserControl/MenteeMentor/Connect.ascx" TagName="Connect" TagPrefix="menteeMentor" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="Server">
	<h1>Connection Requests</h1>
	<menteeMentor:Connect ID="menteeMentorConnect" runat="server" />
</asp:Content>
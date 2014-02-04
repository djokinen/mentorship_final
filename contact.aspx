<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Inner.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="Server">
	<script>
		//$(function () {
		//	$(".btn.accept").click(function () {
		//		if ($(".error, .empty").is(':visible')) {
		//			alert('showing at least one error');
		//		}
		//		else {
		//			alert('no errors showing');
		//		}
		//	});
		//});
	</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="Server">

	<div class="grid_10 prefix_1">
		<h1>Get In Touch</h1>
		<div id="form">

			<div id="success_wrapper" runat="server" class="success_wrapper" visible="false">
				<%--<div class="success">--%>
					Contact form submitted!<br>
					<strong>We will be in touch soon.</strong>
				<%--</div>--%>
			</div>

			<fieldset id="contact_form" runat="server">

				<label for="textName" class="name">
					<asp:TextBox AutoCompleteType="DisplayName" placeholder="Name:" ID="textName" runat="server"></asp:TextBox>
					<br class="clear">
					<asp:RequiredFieldValidator CssClass="error error-empty" ControlToValidate="textName" Display="Dynamic" ErrorMessage="* Required" ID="required_name" runat="server" Text="* Required" ToolTip="* Required" ValidationGroup="validate-contact"></asp:RequiredFieldValidator>
				</label>

				<label for="textEmail" class="name">
					<%--<asp:TextBox placeholder="Email:" ID="textEmail" runat="server" TextMode="Email"></asp:TextBox>--%>
					<asp:TextBox type="email" AutoCompleteType="Email" placeholder="Email:" ID="textEmail" runat="server"></asp:TextBox>
					<br class="clear">
					<asp:RequiredFieldValidator CssClass="error error-empty" ControlToValidate="textEmail" Display="Dynamic" ErrorMessage="* Required" ID="required_email" runat="server" Text="* Required" ToolTip="* Required" ValidationGroup="validate-contact"></asp:RequiredFieldValidator>
					<asp:RegularExpressionValidator Display="Dynamic" CssClass="error error-empty" ControlToValidate="textEmail" ID="emailAddressValidator" runat="server" ValidationGroup="validate-contact">Invalid email address</asp:RegularExpressionValidator>
				</label>

				<label for="textMessage" class="message">
					<asp:TextBox placeholder="Message:" ID="textMessage" runat="server" TextMode="MultiLine" AutoCompleteType="Notes"></asp:TextBox>
					<br class="clear">
					<asp:RequiredFieldValidator CssClass="error error-empty" ControlToValidate="textMessage" Display="Dynamic" ErrorMessage="* Required" ID="required_message" runat="server" Text="* Required" ToolTip="* Required" ValidationGroup="validate-contact"></asp:RequiredFieldValidator>
				</label>

				<div class="clear"></div>
				<div class="btns">					
					<asp:LinkButton  ID="buttonOk" runat="server" CssClass="btn accept" Text="submit" ToolTip="submit" ValidationGroup="validate-contact"></asp:LinkButton>
					<%--<a data-type="reset" class="btn reject">clear</a>--%>
					<div class="clear"></div>
				</div>
			</fieldset>
		</div>
	</div>
</asp:Content>


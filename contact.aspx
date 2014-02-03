﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Inner.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>

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

			<div class="success_wrapper">
				<div class="success">
					Contact form submitted!<br>
					<strong>We will be in touch soon.</strong>
				</div>
			</div>

			<fieldset>

				<label for="textName" class="name">
					<asp:TextBox placeholder="Name:" ID="textName" runat="server"></asp:TextBox>
					<br class="clear">
					<asp:RequiredFieldValidator CssClass="error error-empty" ControlToValidate="textName" Display="Dynamic" ErrorMessage="required" ID="required_name" runat="server" Text="required" ToolTip="required"></asp:RequiredFieldValidator>
				</label>

				<label class="name">
					<input type="text" value="Name:">
					<br class="clear">
					<span class="error error-empty">*This is not a valid name.</span><span class="empty error-empty">* This field is required.</span>
				</label>
				<label class="email">
					<input type="text" value="E-mail:">
					<br class="clear">
					<span class="error error-empty">*This is not a valid email address.</span><span class="empty error-empty">* This field is required.</span>
				</label>
				<label class="phone">
					<input type="tel" value="Phone:">
					<br class="clear">
					<span class="error error-empty">*This is not a valid phone number.</span><span class="empty error-empty">* This field is required.</span>
				</label>
				<label class="message">
					<textarea>Message:</textarea>
					<br class="clear">
					<span class="error">*The message is too short.</span> <span class="empty">* This field is required.</span>
				</label>
				<div class="clear"></div>
				<div class="btns">					
					<a data-type="submit" class="btn accept">submit</a>
					<a data-type="reset" class="btn reject">clear</a>
					<div class="clear"></div>
				</div>
			</fieldset>
		</div>
	</div>
</asp:Content>


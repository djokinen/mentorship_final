<%@ Page Title="Admin" Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/Inner.master" CodeFile="default.aspx.cs" Inherits="membership_admin_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" runat="Server">
	<script>
		var btn;
		$(function () {
			$("#mentee-mentor-list .right a").click(function () {
				_updateUser($(this));
			});
		});

		function _updateUser(button) {
			btn = button;
			var uid = btn.closest("li").data("userid");
			if (btn.hasClass("accept")) {
				if (confirm("Enable this user account?")) {
					WebService.UpdateUser(uid, true, _updateUserCallback);
				}
			}
			else {
				if (confirm("Disable this user account?")) {
					WebService.UpdateUser(uid, false, _updateUserCallback);
				}
			}
		}

		function _updateUserCallback(retval) {
			if (retval) {
				btn.toggleClass("accept reject");
				if (btn.hasClass('accept')) {
					btn.text('enable');
				} else {
					btn.text('disable');
				}
			}
		}

	</script>

	<style>

	</style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="Server">
	<h1>System Members</h1>
	<h2>Enable/Disable Accounts</h2>
	<ul id="mentee-mentor-list">
		<asp:Literal ID="literal" runat="server"></asp:Literal>
	</ul>
</asp:Content>
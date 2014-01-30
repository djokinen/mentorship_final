<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Inner.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="membership_admin_dashboard" %>

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

		/*	int retval = connection status id
		*	None = 0, Pending = 1, Accepted = 2	*/
		function _updateUserCallback(retval) {
			btn.toggleClass("accept reject");
			if (btn.hasClass('accept')) {
				btn.text('enable');
			} else {
				btn.text('disable');
			}
		}

	</script>

	<style>
		li:hover {
			background-color:#eee;
		}
	</style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="Server">
	<h1>System Members</h1>
	<%--<h2>Mentee Connections</h2>--%>
	<ul id="mentee-mentor-list">
		<asp:Literal ID="literal" runat="server"></asp:Literal>
	</ul>

</asp:Content>
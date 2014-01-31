<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List.ascx.cs" Inherits="UserControl_Membership_Admin_List" %>

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

<h2>Enable/Disable Accounts</h2>
<ul id="mentee-mentor-list">
	<asp:Literal ID="literal" runat="server"></asp:Literal>
</ul>
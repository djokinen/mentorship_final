<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Inner.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="membership_admin_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">

<h1>System Members</h1>
<script>
	var btn;
	$(function () {
		$("#mentee-mentor-list a").click(function () {
			_connectWithMentee($(this));
		});
	});

	function _connectWithMentee(button) {
		btn = button;
		var uid = btn.closest("li").data("userid");
		if (btn.hasClass("accept")) {
			if (confirm("Connect with this mentee?")) {
				WebService.ConnectWithMentee(uid, 2, _connectWithMenteeCallback);
			}
		}
		else {
			if (confirm("Remove this mentee from your connection list?")) {
				WebService.ConnectWithMentee(uid, 0, _connectWithMenteeCallback);
			}
		}
	}

	/*	int retval = connection status id
	*	None = 0, Pending = 1, Accepted = 2	*/
	function _connectWithMenteeCallback(retval) {
		btn.toggleClass("accept reject");
		if (btn.hasClass('accept')) {
			// btn.text('connect');
			// TODO: remove this row
			var li = btn.closest("li");
			btn.closest("li").remove();
			// check if there's any items left
			if ($("ul#mentee-mentor-list li").length == 0) {
				$("<strong>You have no pending connections</strong>").appendTo("ul#mentee-mentor-list");
			}
		} else {
			btn.text('disconnect');
		}
	}

</script>

<h2>Mentee Connections</h2>
<ul id="mentee-mentor-list">
	<asp:Literal ID="literal" runat="server"></asp:Literal>
</ul>

</asp:Content>


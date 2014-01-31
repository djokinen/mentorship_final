<%@ Control ClientIDMode="Static" EnableViewState="false" Language="C#" AutoEventWireup="true" CodeFile="Connect.ascx.cs" Inherits="UserControl_MenteeMentor_Connect" %>

<script>
	var btn;
	$(function () {

		$("#button").click(function () {
			_canConnect();
			return false;
		});

		$("#mentee-mentor-list a").click(function () {
			_connectWithMentee($(this));
		});
	});

	function _connectWithMentee(button) {
		btn = button;
		var uid = btn.closest("li").data("userid");
		if (btn.hasClass("accept")) {
			var canConnect = $("ul#mentee-mentor-list a.reject").length < 2;
			if (canConnect) {
				if (confirm("Connect with this mentee?")) {
					WebService.ConnectWithMentee(uid, 2, _connectWithMenteeCallback);
				}
			}
			else {
				alert("You can not have more than 2 connections.");
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
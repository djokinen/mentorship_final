<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List.ascx.cs" Inherits="UserControl_MenteeMentor_List" %>

<script src="/js/jquery.mixitup.min.js"></script>
<script>
	$(function () {
		// init filtering
		$('#mixitup-container').mixitup();

		// add click event to mentor list
		$(".mentor-list.left a").click(function () {
			$(".mentor-list ul li").removeClass("active");
			$(this).parent("li").addClass("active");

			// hide connection request form
			$("#cxn-request-form").hide();

			// show mentor detail form
			var mentorAsJson = $(this).data("user");
			$("#mentor-detail").data("userid", mentorAsJson["UserId"]);
			$("#mentor-detail").data("connectionstatusid", mentorAsJson['ConnectionStatusId']);
			$("#mentor-detail .title").html(mentorAsJson['Name']);
			$("#mentor-detail #cnx-request-button").html("Connect with " + mentorAsJson['Name']);
			$("#mentor-detail .subtitle em").html(mentorAsJson['Company']);
			$("#mentor-detail div strong").html(mentorAsJson['Industries']);
			$("#mentor-detail #mentor-bio").html(mentorAsJson['Bio']);

			_setConnectionStatusInDetailForm(mentorAsJson['ConnectionStatusId']);
		});

		$("#mentor-detail #cnx-request-button").click(function () {
			$(this).hide();
			$("#cxn-request-form").show();
		});

		$("#cxn-send-button").click(function () {
			var userid = $("#mentor-detail").data("userid");
			var message = $("#cxn-request-form textarea").val();
			WebService.ConnectWithMentor(userid, message, _connectWithMentorCallback);
		});

		$("#cxn-cancel-button").click(function () {
			$("#mentor-detail #cnx-request-button").show();
			$("#cxn-request-form").hide();
		});
	});

	function _setConnectionStatusInDetailForm(connectionStatusId) {
		/* None = 0, Pending = 1, Accepted = 2 */
		switch (connectionStatusId) {
			case 1: // pending
				$("#mentor-detail #cnx-request-button").hide();
				$("#mentor-detail .status").html("Awaiting approval from mentor");
				break;
			case 2: // accepted
				$("#mentor-detail #cnx-request-button").hide();
				$("#mentor-detail .status").html("You are connected with this mentor");
				break;
			default: // none
				$("#mentor-detail #cnx-request-button").show();
				$("#mentor-detail .status").html("Connection available");
		}
	}

	function _connectWithMentorCallback(retval) {
		// int retval = connection status id
		// None = 0, Pending = 1, Accepted = 2
		switch (retval) {
			case 0:
				break;
			case 1:
				// hide connection request form
				$("#cxn-request-form").hide();

				// hide connection request button in detail form
				$("#mentor-detail #cnx-request-button").hide();

				// update connection status message [title]
				_setConnectionStatusInDetailForm(retval);

				// update csid for current li
				$(".mentor-list li.active").toggleClass("csid0 csid" + retval);
				$(".mentor-list li.active a").data("user").ConnectionStatusId = retval;
				break;
			default:
		}
	}
</script>

<h2>Connect with a Mentor</h2>
<asp:Repeater ID="repeaterFilter" runat="server">
	<ItemTemplate>
		<a href="javascript://;" class="btn filter" data-filter="<%# Eval("ID") %>"><%# Eval("Name") %></a>
	</ItemTemplate>
</asp:Repeater>

<h3>Available Mentors</h3>

<fieldset id="mixitup-container">

	<div class="mentor-list left">
		<ul><asp:Literal ID="literalMentorList" runat="server"></asp:Literal></ul>
	</div>

	<div class="mentor-list right">
		<asp:Literal ID="literalMentorDetail" runat="server"></asp:Literal>
	</div>

</fieldset>
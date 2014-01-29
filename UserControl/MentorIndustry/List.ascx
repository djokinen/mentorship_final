<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List.ascx.cs" Inherits="UserControl_MentorIndustry_List" %>

<script type="text/javascript" src="/js/dwj-industry.js"></script>

<fieldset>
	<h2>My Industries</h2>
	<p>All available industries are listed in the left-hand column.</p>
	<div class="member_list left">
		<label>Available Industries:</label>
		<ul class="all_industries">
			<asp:Repeater ID="repeaterAvailable" runat="server">
				<ItemTemplate>
					<li>
						<input type="checkbox" value="<%# Eval("ID") %>" id='<%# Eval("ID") %>' name="<%# Eval("ID") %>">
						<label for="<%# Eval("ID") %>"><%# Eval("Name") %></label>
					</li>
				</ItemTemplate>
			</asp:Repeater>
		</ul>
	</div>
	<div class="member_list right">
		<label>My Industries:</label>
		<asp:HiddenField ID="groupMembers" runat="server" />
		<ul class="group_industries">
			<asp:Repeater ID="repeaterSelected" runat="server">
				<ItemTemplate>
					<li>
						<input type="checkbox" value="<%# Eval("ID") %>" id='<%# Eval("ID") %>' name="<%# Eval("ID") %>">
						<label for="<%# Eval("ID") %>"><%# Eval("Name") %></label>
					</li>
				</ItemTemplate>
			</asp:Repeater>
		</ul>
	</div>
	<div class="list_controls">
		<p><input type="button" id="buttonRight" value="→"></p>
		<p><input type="button" id="buttonLeft" value="←"></p>
	</div>

</fieldset>
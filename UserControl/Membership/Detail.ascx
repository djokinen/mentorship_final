<%@ Control ClientIDMode="Static" Language="C#" AutoEventWireup="true" CodeFile="Detail.ascx.cs" Inherits="UserControl_Membership_Detail" %>

<%@ Register Src="~/UserControl/MentorIndustry/List.ascx" TagName="List" TagPrefix="mentorIndustry" %>
<%@ Register Src="~/UserControl/MenteeMentor/List.ascx" TagName="List" TagPrefix="menteeMentor" %>
<%@ Register Src="~/UserControl/MenteeMentor/Connect.ascx" TagName="Connect" TagPrefix="menteeMentor" %>

<%-- http://24ways.org/2009/have-a-field-day-with-html5-forms/ --%>

<section class="form">

	<div>
		<span class="error"><asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal></span>
	</div>

	<fieldset>

		<ol>

			<asp:LoginView ID="loginView" runat="server">
				<RoleGroups>
					<asp:RoleGroup Roles="mentor">
						<ContentTemplate>
							<li>
								<menteeMentor:Connect ID="menteeMentorConnect" runat="server" />
							</li>						
						</ContentTemplate>
					</asp:RoleGroup>
				</RoleGroups>
			</asp:LoginView>

			<li>
				<h2>General Information</h2>
				<label>User Name (<em>email address</em>)</label>
				<span id="spanUserName"><asp:Literal ID="literalUserName" runat="server"></asp:Literal></span>
			</li>

			<li>
				<label for="spanRoleType">Role Type</label>
				<span id="spanRoleType" class="capitalize"><asp:Literal ID="literalRoleType" runat="server"></asp:Literal></span>
			</li>

			<li>
				<label for="FullName">Name</label>
				<asp:RequiredFieldValidator Display="Dynamic" CssClass="error" ID="FullNameRequired" runat="server" ControlToValidate="FullName" ErrorMessage="First and last name are required." ToolTip="First and last name are required." ValidationGroup="required-info">* Required</asp:RequiredFieldValidator>
				<asp:TextBox ID="FullName" runat="server" placeholder="First and Last Name"></asp:TextBox>
				<asp:Literal ID="literalFullName" runat="server"></asp:Literal>
			</li>

			<!-- mentee -->
			<asp:PlaceHolder ID="panelMentee" runat="server">
				<li>
					<label for="MenteePhone">Phone</label>
					<asp:TextBox ID="MenteePhone" runat="server" placeholder="Phone Number"></asp:TextBox>
					<asp:Literal ID="literalMenteePhone" runat="server"></asp:Literal>
				</li>

				<li>
					<label for="MenteeCommunity">Community</label>
					<asp:TextBox ID="MenteeCommunity" runat="server" placeholder="Community"></asp:TextBox>
					<asp:Literal ID="literalMenteeCommunity" runat="server"></asp:Literal>
				</li>

				<li>
					<label for="MenteeDob">D.O.B.</label>
					<asp:TextBox ID="MenteeDob" runat="server" placeholder="Date of Birth"></asp:TextBox>
					<asp:Literal ID="literalMenteeDob" runat="server"></asp:Literal>
					<%--<ajaxToolkit:CalendarExtender ID="calendarExtender" runat="server" TargetControlID="MenteeDob" Format="MMM dd, yyyy"></ajaxToolkit:CalendarExtender>--%>
				</li>

				<li>
					<label for="MenteeOccupation">Occupation</label>
					<asp:TextBox ID="MenteeOccupation" runat="server" placeholder="Occupation"></asp:TextBox>
					<asp:Literal ID="literalMenteeOccupation" runat="server"></asp:Literal>
				</li>

				<li>
					<div class="commands">
						<asp:LinkButton CssClass="btn accept" ID="buttonUpdateMentee" runat="server" CommandArgument="update" Text="Update Profile" ValidationGroup="required-info" />
						<asp:Label ID="labelStatusMentee" runat="server" EnableViewState="false" CssClass="status"></asp:Label>
					</div>
				</li>

				<li>
					<menteeMentor:List ID="menteeMentorList" runat="server" />
				</li>
			</asp:PlaceHolder>

			<!-- mentor -->
			<asp:PlaceHolder ID="panelMentor" runat="server">

				<li>
					<label for="MentorPhone">Phone</label>
					<asp:TextBox ID="MentorPhone" runat="server" placeholder="Phone Number"></asp:TextBox>
					<asp:Literal ID="literalMentorPhone" runat="server"></asp:Literal>
				</li>

				<li>
					<label for="MentorCompanyName">Company Name</label>
					<asp:TextBox ID="MentorCompanyName" runat="server" placeholder="Company Name"></asp:TextBox>
					<asp:Literal ID="literalMentorCompanyName" runat="server"></asp:Literal>
				</li>

<%--			<li>
					<label for="MentorIndustry">Industry</label>
					<asp:TextBox ID="MentorIndustry" runat="server" placeholder="Industry"></asp:TextBox>
					<asp:Literal ID="literalMentorIndustry" runat="server"></asp:Literal>
				</li>
--%>

				<li>
					<label for="MentorBio">Bio</label>
					<asp:TextBox TextMode="MultiLine" Rows="3" ID="MentorBio" runat="server" placeholder="Bio"></asp:TextBox>
					<asp:Literal ID="literalMentorBio" runat="server"></asp:Literal>
				</li>

				<li>
					<mentorIndustry:List ID="mentorIndustryList" runat="server" />
				</li>

				<li>
					<div class="commands">
						<asp:LinkButton CssClass="btn accept" ID="buttonUpdateMentor" runat="server" CommandArgument="update" Text="Update Profile" ValidationGroup="required-info"></asp:LinkButton>
						<asp:Label ID="labelStatusMentor" runat="server" EnableViewState="false" CssClass="status"></asp:Label>
					</div>
				</li>

			</asp:PlaceHolder>

		</ol>
	</fieldset>

</section>
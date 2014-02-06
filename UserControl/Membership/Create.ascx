<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Create.ascx.cs" Inherits="UserControl_Membership_Create" %>

<%-- http://24ways.org/2009/have-a-field-day-with-html5-forms/ --%>

<section class="form">

	<div>
		<span class="error"><asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal></span>
	</div>

	<asp:Panel ID="panelStep1_create" runat="server" DefaultButton="buttonCreateUser">

		<fieldset id="required-info">
			<legend>Required Info</legend>
			<ol>
				<li>
					<label id="RoleTypeLabel" for="RoleTypeContainer" runat="server" associatedcontrolid="RoleTypeContainer">Role Type</label>

					<div id="RoleTypeContainer">
						<asp:RadioButtonList ID="radioList" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
							<asp:ListItem Text="Mentee" Value="mentee" Selected="True"></asp:ListItem>
							<asp:ListItem Text="Mentor" Value="mentor"></asp:ListItem>
						</asp:RadioButtonList>
					</div>
				</li>

				<li>
					<asp:Label ID="FullNameLabel" runat="server" AssociatedControlID="FullName">Name</asp:Label>
					<asp:RequiredFieldValidator Display="Dynamic" CssClass="error" ID="FullNameRequired" runat="server" ControlToValidate="FullName" ErrorMessage="First and last name are required." ToolTip="First and last name are required." ValidationGroup="required-info">* Required</asp:RequiredFieldValidator>
					<asp:TextBox AutoCompleteType="DisplayName" ID="FullName" runat="server" placeholder="First and Last Name"></asp:TextBox>
				</li>

				<li>
					<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name (<em>email address</em>)</asp:Label>
					<asp:RequiredFieldValidator Display="Dynamic" CssClass="error" ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Email is required." ToolTip="Email is required." ValidationGroup="required-info">* Required</asp:RequiredFieldValidator>
					<asp:RegularExpressionValidator Display="Dynamic" CssClass="error" ControlToValidate="UserName" ID="emailAddressValidator" runat="server" ValidationGroup="required-info">invalid email</asp:RegularExpressionValidator>
					<asp:TextBox type="email" AutoCompleteType="Email" placeholder="Email Address" ID="UserName" runat="server"></asp:TextBox>
				</li>

				<li>
					<asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password (<em>must be at least 6 characters long</em>)</asp:Label>
					<asp:RequiredFieldValidator Display="Dynamic" CssClass="error" ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="required-info">* Required</asp:RequiredFieldValidator>
					<asp:TextBox placeholder="Password" ID="Password" runat="server" TextMode="Password"></asp:TextBox>
				</li>

				<li>
					<asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password</asp:Label>
					<asp:RequiredFieldValidator Display="Dynamic" CssClass="error" ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword" ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required." ValidationGroup="required-info">* Required</asp:RequiredFieldValidator>
					<asp:CompareValidator Display="Dynamic" CssClass="error" ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" ErrorMessage="Passwords must match" ValidationGroup="required-info">Passwords must match</asp:CompareValidator>
					<asp:TextBox placeholder="Confirm Password" ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
				</li>

				<li>
					<div class="commands">
						<asp:LinkButton ID="buttonCreateUser" CssClass="btn accept" CommandArgument="create" runat="server" Text="Create" ValidationGroup="required-info"></asp:LinkButton>
					</div>
				</li>
			</ol>
		</fieldset>

	</asp:Panel>

	<asp:Panel ID="panelStep2_mentee" runat="server" DefaultButton="buttonUpdateProfile_mentee" Visible="false">

		<fieldset id="mentee-info">
			<legend>Mentee Info</legend>
			<ol>
				<li>
					<asp:Label ID="MenteePhoneLabel" runat="server" AssociatedControlID="MenteePhone">Phone</asp:Label>
					<asp:TextBox AutoCompleteType="HomePhone" type="tel" ID="MenteePhone" runat="server" placeholder="Phone Number"></asp:TextBox>
				</li>

				<li>
					<asp:Label ID="MenteeCommunityLabel" runat="server" AssociatedControlID="MenteeCommunity">Community</asp:Label>
					<asp:TextBox ID="MenteeCommunity" runat="server" placeholder="Community"></asp:TextBox>
				</li>

				<li>
					<asp:Label ID="MenteeDobLabel" runat="server" AssociatedControlID="MenteeDob">D.O.B.</asp:Label>
					<asp:TextBox type="date" ID="MenteeDob" runat="server" placeholder="Date of Birth"></asp:TextBox>
					<%--<ajaxToolkit:CalendarExtender ID="calendarExtender" runat="server" TargetControlID="MenteeDob" Format="MMM dd, yyyy"></ajaxToolkit:CalendarExtender>--%>
				</li>

				<li>
					<asp:Label ID="MenteeOccupationLabel" runat="server" AssociatedControlID="MenteeOccupation">Occupation</asp:Label>
					<asp:TextBox AutoCompleteType="JobTitle" ID="MenteeOccupation" runat="server" placeholder="Occupation"></asp:TextBox>
				</li>
				<li>
					<div class="commands">
						<asp:LinkButton CssClass="btn accept" ID="buttonUpdateProfile_mentee" runat="server" CommandArgument="update" Text="Update" />
					</div>
				</li>
			</ol>
		</fieldset>

	</asp:Panel>

	<asp:Panel ID="panelStep2_mentor" runat="server" DefaultButton="buttonUpdateProfile_mentor" Visible="false">

		<fieldset id="mentor-info">
			<legend>Mentor Info</legend>
			<ol>
				<li>
					<asp:Label ID="MentorPhoneLabel" runat="server" AssociatedControlID="MentorPhone">Phone</asp:Label>
					<asp:TextBox AutoCompleteType="HomePhone" type="tel" ID="MentorPhone" runat="server" placeholder="Phone Number"></asp:TextBox>
				</li>

				<li>
					<asp:Label ID="MentorCompanyNameLabel" runat="server" AssociatedControlID="MentorCompanyName">Company Name</asp:Label>
					<asp:TextBox AutoCompleteType="Company" ID="MentorCompanyName" runat="server" placeholder="Company Name"></asp:TextBox>
				</li>

<%--				<li>
					<asp:Label ID="MentorIndustryLabel" runat="server" AssociatedControlID="MentorIndustry">Industry</asp:Label>
					<asp:TextBox ID="MentorIndustry" runat="server" placeholder="Industry"></asp:TextBox>
				</li>--%>

				<li>
					<asp:Label ID="MentorBioLabel" runat="server" AssociatedControlID="MentorBio">Bio</asp:Label>
					<asp:TextBox AutoCompleteType="Notes" TextMode="MultiLine" Rows="3" ID="MentorBio" runat="server" placeholder="Bio"></asp:TextBox>
				</li>

				<li>
					<div class="commands">
						<asp:LinkButton CssClass="btn accept" ID="buttonUpdateProfile_mentor" runat="server" CommandArgument="update" Text="Update" />
					</div>
				</li>
			</ol>
		</fieldset>

	</asp:Panel>

	<asp:Panel ID="panelStep3_confirm" runat="server" Visible="false">

			<h2>Welcome!</h2>
			<h3>Account Status</h3>
			<p>Thank you for registering, an e-mail will be sent to you within 48hrs with confirmation.</p>
			<%--<ul><li><a class="btn accept" href="/membership/profile.aspx">View your profile</a></li></ul>--%>

	</asp:Panel>

</section>
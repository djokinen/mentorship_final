<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="UserControl_Header" %>

<header>
	<div class="container_16">
		<div class="grid_16">
			<h6>
				<a href="/default.aspx">
					<img src="/images-2/logo3.png" alt="CREE Logo">
				</a>
			</h6>
			<div class="menu_block">
				<nav class="horizontal-nav full-width horizontalNav-notprocessed">
					<ul class="sf-menu">
						<li class="current "><a href="/default.aspx">About</a>
							<ul>
								<li><a href="/mentoring.aspx">Mentoring</a></li>
								<li><a href="/mentee.aspx">What Is A Mentee?</a></li>
								<li><a href="/mentor.aspx">What Is A Mentor?</a></li>
							</ul>
						</li>
						<li>
							<asp:LoginView ID="loginView" runat="server">
								<AnonymousTemplate>
									<a href="/membership/register.aspx" title="sign up">Register</a>
								</AnonymousTemplate>
								<LoggedInTemplate>
									<a href="/membership/profile.aspx" title="my profile">My Profile</a>
								</LoggedInTemplate>
							</asp:LoginView>
						</li>
						<li><a href="/contact.aspx">Contact</a></li>
						<li><asp:LoginStatus ID="loginStatus" runat="server" /></li>
					</ul>
				</nav>
				<div class="clear"></div>
			</div>
			<div class="clear"></div>
		</div>
	</div>
</header>
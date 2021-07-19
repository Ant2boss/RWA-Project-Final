<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RWA_WebForms.Login.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link href="../CSS/Default.css" rel="stylesheet" />
	<link href="../CSS/LoginMain.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="my-center-content">
		<h1 class="my-header">
			<asp:Label Text="Registracija" runat="server" />
		</h1>
		<hr />

		<div class="my-grouper">
			<asp:Label Text="Korisničko ime:" runat="server" />
			<asp:RequiredFieldValidator ErrorMessage="Korisničko ime je obavezno" Text="*" CssClass="text-danger" ControlToValidate="tbUsername" runat="server" />
			<asp:CustomValidator ErrorMessage="Korisničko ime je iskorišteno" Text="*" OnServerValidate="CustomValidator_ServerValidate" ID="CustomValidator" runat="server" />
			<div class="my-form-group">
				<div>
					<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-person-fill" viewBox="0 0 16 16">
						<path d="M3 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H3zm5-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6z" />
					</svg>
				</div>
				<asp:TextBox CssClass="form-control" ID="tbUsername" runat="server" />
			</div>
		</div>
		<div class="my-grouper">
			<asp:Label Text="Lozinka:" runat="server" />
			<asp:RequiredFieldValidator ErrorMessage="Lozinka je obavezna" Text="*" CssClass="text-danger" ControlToValidate="tbPassword" runat="server" />
			<div class="my-form-group">
				<div>
					<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-shield-lock" viewBox="0 0 16 16">
						<path d="M5.338 1.59a61.44 61.44 0 0 0-2.837.856.481.481 0 0 0-.328.39c-.554 4.157.726 7.19 2.253 9.188a10.725 10.725 0 0 0 2.287 2.233c.346.244.652.42.893.533.12.057.218.095.293.118a.55.55 0 0 0 .101.025.615.615 0 0 0 .1-.025c.076-.023.174-.061.294-.118.24-.113.547-.29.893-.533a10.726 10.726 0 0 0 2.287-2.233c1.527-1.997 2.807-5.031 2.253-9.188a.48.48 0 0 0-.328-.39c-.651-.213-1.75-.56-2.837-.855C9.552 1.29 8.531 1.067 8 1.067c-.53 0-1.552.223-2.662.524zM5.072.56C6.157.265 7.31 0 8 0s1.843.265 2.928.56c1.11.3 2.229.655 2.887.87a1.54 1.54 0 0 1 1.044 1.262c.596 4.477-.787 7.795-2.465 9.99a11.775 11.775 0 0 1-2.517 2.453 7.159 7.159 0 0 1-1.048.625c-.28.132-.581.24-.829.24s-.548-.108-.829-.24a7.158 7.158 0 0 1-1.048-.625 11.777 11.777 0 0 1-2.517-2.453C1.928 10.487.545 7.169 1.141 2.692A1.54 1.54 0 0 1 2.185 1.43 62.456 62.456 0 0 1 5.072.56z" />
						<path d="M9.5 6.5a1.5 1.5 0 0 1-1 1.415l.385 1.99a.5.5 0 0 1-.491.595h-.788a.5.5 0 0 1-.49-.595l.384-1.99a1.5 1.5 0 1 1 2-1.415z" />
					</svg>
				</div>
				<asp:TextBox CssClass="form-control" TextMode="Password" ID="tbPassword" runat="server" />
			</div>
		</div>
		<div class="my-grouper">
			<asp:Label Text="Ponovljena lozinka:" runat="server" />
			<asp:RequiredFieldValidator ErrorMessage="Ponovni unos lozinke je obavezan" Text="*" CssClass="text-danger" ControlToValidate="tbRepeatPassword" runat="server" />
			<asp:CompareValidator ErrorMessage="Lozinke se ne poklapaju" Text="*" CssClass="text-danger" ControlToValidate="tbRepeatPassword" ControlToCompare="tbPassword" runat="server" />
			<div class="my-form-group">
				<div>
					<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-shield-lock" viewBox="0 0 16 16">
						<path d="M5.338 1.59a61.44 61.44 0 0 0-2.837.856.481.481 0 0 0-.328.39c-.554 4.157.726 7.19 2.253 9.188a10.725 10.725 0 0 0 2.287 2.233c.346.244.652.42.893.533.12.057.218.095.293.118a.55.55 0 0 0 .101.025.615.615 0 0 0 .1-.025c.076-.023.174-.061.294-.118.24-.113.547-.29.893-.533a10.726 10.726 0 0 0 2.287-2.233c1.527-1.997 2.807-5.031 2.253-9.188a.48.48 0 0 0-.328-.39c-.651-.213-1.75-.56-2.837-.855C9.552 1.29 8.531 1.067 8 1.067c-.53 0-1.552.223-2.662.524zM5.072.56C6.157.265 7.31 0 8 0s1.843.265 2.928.56c1.11.3 2.229.655 2.887.87a1.54 1.54 0 0 1 1.044 1.262c.596 4.477-.787 7.795-2.465 9.99a11.775 11.775 0 0 1-2.517 2.453 7.159 7.159 0 0 1-1.048.625c-.28.132-.581.24-.829.24s-.548-.108-.829-.24a7.158 7.158 0 0 1-1.048-.625 11.777 11.777 0 0 1-2.517-2.453C1.928 10.487.545 7.169 1.141 2.692A1.54 1.54 0 0 1 2.185 1.43 62.456 62.456 0 0 1 5.072.56z" />
						<path d="M9.5 6.5a1.5 1.5 0 0 1-1 1.415l.385 1.99a.5.5 0 0 1-.491.595h-.788a.5.5 0 0 1-.49-.595l.384-1.99a1.5 1.5 0 1 1 2-1.415z" />
					</svg>
				</div>
				<asp:TextBox CssClass="form-control" TextMode="Password" ID="tbRepeatPassword" runat="server" />
			</div>
		</div>

		<div>
			<asp:ValidationSummary CssClass="my-valid-summary-css" runat="server" />
		</div>

		<hr />

		<asp:Button Text="Registriraj se" CssClass="btn btn-success btn-sm w-50 m-auto" runat="server" />
		<asp:HyperLink NavigateUrl="~/Default.aspx" Text="Povratak" CssClass="btn btn-outline-secondary btn-sm w-25 m-auto mt-3" runat="server" />

	</div>
</asp:Content>

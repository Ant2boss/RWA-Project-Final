<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Gradovi.aspx.cs" Inherits="RWA_WebForms.Profile.Gradovi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link href="../CSS/Default.css" rel="stylesheet" />
	<link href="../CSS/LoginMain.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="container my-bg">
		<h1 class="my-header">
			<asp:Label Text="Gradovi" runat="server" />
		</h1>
		<hr />
		<div>
			<div class="my-grouper w-75">
				<asp:Label Text="Država:" runat="server" />
				<div class="my-form-group">
					<div>
						<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-flag-fill" viewBox="0 0 16 16">
							<path d="M14.778.085A.5.5 0 0 1 15 .5V8a.5.5 0 0 1-.314.464L14.5 8l.186.464-.003.001-.006.003-.023.009a12.435 12.435 0 0 1-.397.15c-.264.095-.631.223-1.047.35-.816.252-1.879.523-2.71.523-.847 0-1.548-.28-2.158-.525l-.028-.01C7.68 8.71 7.14 8.5 6.5 8.5c-.7 0-1.638.23-2.437.477A19.626 19.626 0 0 0 3 9.342V15.5a.5.5 0 0 1-1 0V.5a.5.5 0 0 1 1 0v.282c.226-.079.496-.17.79-.26C4.606.272 5.67 0 6.5 0c.84 0 1.524.277 2.121.519l.043.018C9.286.788 9.828 1 10.5 1c.7 0 1.638-.23 2.437-.477a19.587 19.587 0 0 0 1.349-.476l.019-.007.004-.002h.001" />
						</svg>
					</div>
					<asp:DropDownList CssClass="form-select" ID="ddlStatesFilter" AutoPostBack="true" runat="server" />
				</div>
			</div>
		</div>
		<asp:Repeater ID="Repeater" runat="server">
			<HeaderTemplate>
				<table class="table table-striped table-sm">
					<thead>
						<tr>
							<th>
								<asp:Label Text="Naziv grada" runat="server" />
							</th>
							<th>
								<asp:Label Text="Naziv drzave" runat="server" />
							</th>
							<th></th>
							<th></th>
						</tr>
					</thead>
					<tbody>
			</HeaderTemplate>
			<ItemTemplate>
				<tr>
					<td>
						<%#Eval("Grad.Naziv") %>
					</td>
					<td>
						<%#Eval("DrzavaNaziv") %>
					</td>
					<td>
						<asp:LinkButton Text="Uredi" CommandArgument='<%#Eval("Grad.IDGrad") %>' CssClass="btn btn-sm btn-secondary" ID="btnEdit" OnClick="btnEdit_Click" runat="server" />
					</td>
					<td>
						<asp:LinkButton Text="Obriši" CommandArgument='<%#Eval("Grad.IDGrad") %>' CssClass="btn btn-sm btn-danger" ID="btnDelete" OnClick="btnDelete_Click" runat="server" />
					</td>
				</tr>
			</ItemTemplate>
			<FooterTemplate>
				</tbody>
				</table>
			</FooterTemplate>
		</asp:Repeater>

		<hr />

		<div class="d-flex justify-content-center">
			<asp:HyperLink Text="Dodaj grad" CssClass="btn btn-sm btn-primary" NavigateUrl="~/Editors/GradEditor.aspx" runat="server" />
		</div>

		<div style="height: 40px;" />
	</div>
</asp:Content>

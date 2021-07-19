<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Drzave.aspx.cs" Inherits="RWA_WebForms.Profile.Drzave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link href="../CSS/Default.css" rel="stylesheet" />
	<link href="../CSS/LoginMain.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="container my-bg">
		<h1 class="my-header">
			<asp:Label Text="Države" runat="server" />
		</h1>
		<hr />

		<asp:Repeater ID="Repeater" runat="server">
			<HeaderTemplate>
				<table class="table table-striped table-sm">
					<thead>
						<tr>
							<th>
								<asp:Label Text="Naziv države" runat="server" />
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
						<%#Eval("Naziv") %>
					</td>
					<td>
						<asp:LinkButton Text="Uredi" CommandArgument='<%#Eval("IDDrzava") %>' CssClass="btn btn-sm btn-secondary" ID="btnEdit" OnClick="btnEdit_Click" runat="server" />
					</td>
					<td>
						<asp:LinkButton Text="Obriši" CommandArgument='<%#Eval("IDDrzava") %>' CssClass="btn btn-sm btn-danger" ID="btnDelete" OnClick="btnDelete_Click" runat="server" />
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
			<asp:HyperLink Text="Dodaj državu" CssClass="btn btn-sm btn-primary" NavigateUrl="~/Editors/DrzavaEditor.aspx" runat="server" />
		</div>

		<div style="height: 40px;" />

	</div>
</asp:Content>

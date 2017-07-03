<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Verify.aspx.cs" Inherits="Account_Verify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <h5>Please verify that you're human before proceeding!</h5>
    <li>
        <asp:Image ID="Image1" runat="server"/> <br />
        <asp:Button ID="btn_newIMG" runat="server" Text="New image" Height="34px" Width="117px" OnClick="btn_newIMG_Click" /> 
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="lblVerify" runat="server">Enter the characters in the image:</asp:Label> 
        <asp:TextBox ID="txtVerify" style='width:110px' runat="server"></asp:TextBox>
         <asp:Button ID="btn_verify" runat="server" Text="Verify" Height="34px" Width="117px" OnClick="btn_verify_Click"/>
    </li>
    <li>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </li>
</asp:Content>


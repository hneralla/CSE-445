<%@ Page Title="Verification Service" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Verification.aspx.cs" Inherits="WebApplication.Verification" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Verification</h2>
    <h4>Takes the URL of an XML (.xml) file and the URL of the corresponding
XMLS (.xsd) file as inputs and validates the XML file against the corresponding XMLS (XSD) file. </h4>
    <p>Enter the URL for the XML file (ends with .xml)</p>
<p>
    <asp:TextBox ID="txt_xml" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
</p>
<p>Enter the URL for the XMLS file (ends with .xsd)</p>
<p>
    <asp:TextBox ID="txt_xsd" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
</p>
<p>
    <asp:Button ID="btn_verify" runat="server" OnClick="btn_verify_Click" Text="Verify" />
</p>
<p>
    <asp:Label ID="lbl_output" runat="server"></asp:Label>
</p>
</asp:Content>

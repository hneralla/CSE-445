<%@ Page Title="Transformation Service" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transformation.aspx.cs" Inherits="WebApplication.Transformation" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Transformation</h2>
    <h4>Takes the URL of an XML (.xml) file and the URL of the XSL file
as inputs and generates the HTML file based on the XML and XSL files.</h4>
     Enter the URL for the XML file (ends with .xml)
    <p>
    <asp:TextBox ID="txt_xml" runat="server" Width="1000px"></asp:TextBox>
    </p>
    <p>Enter the URL for the XSL file (ends with .xsl)</p>
    <p>
    <asp:TextBox ID="txt_xsl" runat="server" Width="1000px"></asp:TextBox>
    </p>
    <p>
    <asp:Button ID="btn_transform" runat="server" OnClick="btn_transform_Click" Text="Transform" />
    </p>
    <p>
    <asp:Label ID="lbl_output" runat="server"></asp:Label>
    </p>
</asp:Content>

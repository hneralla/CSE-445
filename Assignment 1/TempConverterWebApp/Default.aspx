<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Temperature Converter</h1>
        <p>Celsius to Fahrenheit and Fahrenheit to Celsius</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h3>&nbsp;Enter temperatures to convert:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h3>
            <p>
                C to F&nbsp;&nbsp; <asp:TextBox ID="textBox1" runat="server"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" Text="° C"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="label1" runat="server"></asp:Label>
            </p>
            <p>
                F to C &nbsp;
                <asp:TextBox ID="textBox2" runat="server"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" Text="° F"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="label2" runat="server"></asp:Label>
            </p>
        </div>
        <div class="col-md-4">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
               <asp:Button ID="button1" runat="server" Text="Convert" OnClick="button1_Click"  />
        </div>

    </div>

</asp:Content>

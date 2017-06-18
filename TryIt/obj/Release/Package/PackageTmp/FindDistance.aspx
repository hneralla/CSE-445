<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FindDistance.aspx.cs" Inherits="TryIt.FindDistance" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h3>Find Distance Service</h3>
        <h4>Finds the distance between two locations. Returns the distance and the travel time in a string array.</h4>
        <p class="absolute">
            Method name: findDistance(...)<br />
            Input parameters: string[] (origin}, string[] (destination) <br />
            Return type: Array of string 
        </p>
        <p class="absolute">
            &nbsp;</p>
        <p class="absolute">
            Origin:</p>
        <p class="absolute"> 
            <asp:RadioButton ID="rdio_btn_address" runat="server" Text="Address" AutoPostBack="True" OnCheckedChanged="rdio_btn_address_CheckedChanged" /> <br />
            <asp:RadioButton ID="rdio_btn_ZIP" runat="server" Text="ZIP code" AutoPostBack="True" OnCheckedChanged="rdio_btn_ZIP_CheckedChanged" />
        </p>
        <p class="absolute"> 
            <asp:Label ID="lbl_1" runat="server"></asp:Label>
&nbsp; 
            <asp:TextBox ID="txtBox_1" runat="server" Visible="False"></asp:TextBox>&nbsp;<br />
            <asp:Label ID="lbl_2" runat="server"></asp:Label>
&nbsp; <asp:TextBox ID="txtBox_2" runat="server" OnTextChanged="txtBox_2_TextChanged" Visible="False"></asp:TextBox>
        &nbsp;</p>
        <p class="absolute"> 
            <asp:Label ID="lbl_info" runat="server"></asp:Label>
        </p>
        <p class="absolute"> 
            Destination:</p>
        <p class="absolute"> 
            <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" Text="Address" OnCheckedChanged="RadioButton1_CheckedChanged" /> <br />
            <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" Text="ZIP Code" OnCheckedChanged="RadioButton2_CheckedChanged" />
        </p>
        <p class="absolute"> 
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox> <br />
             <asp:Label ID="Label2" runat="server"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
        </p>
        <p class="absolute"> 
            <asp:Label ID="Label3" runat="server"></asp:Label>
        </p>
        <p class="absolute"> 
            <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />
        </p>
        <p class="absolute"> 
            &nbsp;</p>
        <p class="absolute"> 
            <asp:Label ID="lbl_result" runat="server"></asp:Label>
        </p>
    </div>

    </asp:Content>